using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revit_Sketchfab_Core.lib.APIObjects
{
    internal class Sketchfab_Model
    {
        public string name { get; set; }
        public string description { get; set; }
        public IList<string> tags { get; set; }
        public IList<string> categories { get; set; }
        public string license { get; set; }
        public bool isPublished { get; set; }
        public bool isInspectable { get; set; }

        public Sketchfab_Model(string modelName)
        {
            name = modelName;
            description = "Uploaded with Ricardo Salas' Sketchfab Exporter Revit Plugin";
            tags = new List<string>()
            {
                "ricardosalasv.com",
                "revit",
                "revit API",
                "C#"
            };
            categories = new List<string>()
            {
                "Architecture",
                "Furniture & Home"
            };
            license = "by Ricardo Salas";
            isPublished = false;
            isInspectable = true;
        }
    }
}
