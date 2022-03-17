using Revit_Sketchfab_UI.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revit_Sketchfab_UI.lib
{
    public static class CreateWindows
    {
        public static void CreateLoginWindow()
        {
            Window_Login windowLogin = new Window_Login();
            windowLogin.Activate();
            windowLogin.Show();
        }

        public static void CreateMenuWindow()
        {
            Window_Menu windowMenu = new Window_Menu();
            windowMenu.Activate();
            windowMenu.Show();
        }
    }
}
