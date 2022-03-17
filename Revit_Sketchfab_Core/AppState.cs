using Autodesk.Revit.UI;
using Revit_Sketchfab_Core.lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Revit_Sketchfab_Core
{
    /// <summary>
    /// Singleton class to store data that will be persistent within the active Revit session
    /// </summary>
    public static class AppState
    {
        public static bool IsUserLoggedIn { get; set; }

        // Initializes the http client pointing at the Sketchfab API
        public static SketchfabAPIConnection client = new SketchfabAPIConnection();

        public static ExportConfig ExportConfig = new ExportConfig();

        public static UIApplication CurrentUIApplication { get; set; }

        public static void Initialize()
        {
            IsUserLoggedIn = false;
            ExportConfig.selectedElements = false;
        }

    }

    public class ExportConfig
    {
        public bool selectedElements { get; set; }
    }
}
