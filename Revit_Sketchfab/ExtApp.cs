using Autodesk.Revit.UI;
using Revit_Sketchfab_Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revit_Sketchfab
{
    public class ExtApp : IExternalApplication
    {
        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }

        public Result OnStartup(UIControlledApplication application)
        {
            SetupUI.Initialize(application);

            // Setting AppState
            AppState.IsUserLoggedIn = false;

            return Result.Succeeded;
        }
    }
}
