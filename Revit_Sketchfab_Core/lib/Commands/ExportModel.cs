using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revit_Sketchfab_Core.lib.Commands
{
    public class ExportModel : IExternalCommand
    {

        public async Task<Result> Execute()
        {
            View activeView = AppState.CurrentUIApplication.ActiveUIDocument.ActiveView;

            Export(activeView);

            return Result.Succeeded;

        }
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            return Execute().Result;
        }

        public void Export(View view, bool selected=false)
        {
            Document doc = view.Document;

            if (selected)
            {
                // Apply temporary isolation to the selected elements in the active view
            }

            ViewSet viewSet = new ViewSet();
            viewSet.Insert(view);

            FBXExportOptions options = new FBXExportOptions()
            {
                LevelsOfDetailValue = 15,
                StopOnError = true,
                UseLevelsOfDetail = true,
                WithoutBoundaryEdges = true,
            };

            doc.Export("F:\\Ricardo Salas\\Arquitectura\\Programas\\Autodesk\\Revit\\Scripts\\NET\\Sketchfab Exporter\\Revit_Sketchfab\\",
                "exportTest.fbx",
                viewSet,
                options);
        }
    }
}
