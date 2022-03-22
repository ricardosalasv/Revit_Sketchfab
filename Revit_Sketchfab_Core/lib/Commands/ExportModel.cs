using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Revit_Sketchfab_Core.lib.Commands
{
    public class ExportModel
    {
        private bool exportSel = false;
        private string modelName { get; set; }
        public ExportModel(bool exportSelected, string ModelName)
        {
            exportSel = exportSelected;
            modelName = ModelName;
        }

        public async Task<bool> Execute()
        {
            UIDocument uidoc = AppState.CurrentUIApplication.ActiveUIDocument;

            await Export(uidoc);

            return true;
        }

        public async Task<bool> Export(UIDocument uidoc)
        {
            View view = uidoc.ActiveView;
            if (!(view is View3D))
            {
                TaskDialog.Show("Error", "You must be in the 3D View you want to export elements from.");
                return false;
            }

            Document doc = view.Document;

            Transaction tt = new Transaction(doc, "Adjust View Settings");
            tt.Start();

            // Setting base adjustments to the view for export
            view.AreAnnotationCategoriesHidden = true;

            foreach (ElementId id in GetCategoriesToHide())
            {
                view.SetCategoryHidden(id, true);
            }

            if (exportSel)
            {
                TaskDialog.Show("Info", "Please select the elements you want to export");

                IList<Reference> selSet = uidoc.Selection.PickObjects(ObjectType.Element);

                // Apply temporary isolation to the selected elements in the active view
                IList<ElementId> selectedElementsIds = selSet.Select(x => doc.GetElement(x).Id).ToList();

                view.IsolateElementsTemporary(selectedElementsIds);

                view.ConvertTemporaryHideIsolateToPermanent();
            }

            ViewSet viewSet = new ViewSet();
            viewSet.Insert(view);

            string zipfile = FBXExport(doc, viewSet, modelName);

            // Returns the active view to its original state
            tt.RollBack();

            // Starts uploading the model to Sketchfab
            await AppState.client.UploadModel(zipfile, modelName);

            return true;
        }

        private string FBXExport(Document doc, ViewSet viewSet, string modelName)
        {
            FBXExportOptions options = new FBXExportOptions()
            {
                LevelsOfDetailValue = 15,
                StopOnError = true,
                UseLevelsOfDetail = true,
                WithoutBoundaryEdges = true,
            };

            try
            {
                string tempPath = Environment.GetEnvironmentVariable("TEMP");
                DirectoryInfo dir = Directory.CreateDirectory(tempPath + "\\sketchfabExportDir");

                string fileName = $"{modelName}.fbx";
                string exportDir = dir.FullName;
                string zipPath = tempPath + $"\\{modelName}.zip";
                doc.Export(exportDir, fileName, viewSet, options);

                ZipFile.CreateFromDirectory(exportDir, zipPath);

                return zipPath;
            }
            catch (Exception ex)
            {
                string test = ex.Message;
            }

            return "";
        }

        private IList<ElementId> GetCategoriesToHide()
        {
            IList<BuiltInCategory> categories = new List<BuiltInCategory>()
            {
                BuiltInCategory.OST_Levels,
                BuiltInCategory.OST_Grids
            };

            IList<ElementId> categoriesIds = categories.Select(x => new ElementId(x)).ToList();

            return categoriesIds;
        }
    }
}
