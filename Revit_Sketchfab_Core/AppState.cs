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
        public static HttpClient client = new HttpClient();

    }
}
