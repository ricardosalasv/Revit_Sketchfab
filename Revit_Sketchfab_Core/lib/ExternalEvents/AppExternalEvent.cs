using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revit_Sketchfab_Core.lib.ExternalEvents
{
    public class AppExternalEvent : IExternalEventHandler
    {
        public void Execute(UIApplication app)
        {
            AppState.CommandToExecute();
        }

        public string GetName()
        {
            return "External Event";
        }
    }
}
