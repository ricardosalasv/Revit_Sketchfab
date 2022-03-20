using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Revit_Sketchfab_Core;
using Revit_Sketchfab_UI.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revit_Sketchfab.Entrypoints
{
    [Transaction(TransactionMode.Manual)]
    public class Start_ExportModel : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            AppState.CurrentUIApplication = commandData.Application;

            // Initializing all windows
            Window_Login windowLogin = new Window_Login();
            Window_Menu windowMenu = new Window_Menu();
            Window_Export windowExport = new Window_Export();
            Window_Library windowLibrary = new Window_Library();
            Window_Viewer windowViewer = new Window_Viewer();

            if (AppState.IsUserLoggedIn)
            {
                windowMenu.Activate();
                windowMenu.Show();
            }
            else
            {
                windowLogin.Activate();
                windowLogin.Show();
            }

            return Result.Succeeded;
        }

        /// <summary>
        /// Gets the full namespace path to this command
        /// </summary>
        /// <returns></returns>
        public static string GetPath()
        {
            // Return constructed namespace path
            return typeof(Start_ExportModel).FullName;
        }
    }
}
