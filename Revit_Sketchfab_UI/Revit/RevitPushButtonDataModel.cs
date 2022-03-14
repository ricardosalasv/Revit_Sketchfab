using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revit_Sketchfab_UI.Revit
{
    /// <summary>
    /// Represents the Revit PushButtonDataModel
    /// </summary>
    public class RevitPushButtonDataModel
    {
        /// <summary>
        /// Gets or sets the label of the button
        /// </summary>
        public string Label { get; set; }
        
        /// <summary>
        /// Gets or sets the panel on which the button is hosted
        /// </summary>
        public RibbonPanel Panel { get; set; }

        /// <summary>
        /// Gets or sets the command namespace path
        /// </summary>
        public string CommandNamespacePath { get; set; }

        /// <summary>
        /// Gets or sets the tooltip
        /// </summary>
        public string Tooltip { get; set; }

        /// <summary>
        /// Gets or sets the bane if the icon image
        /// </summary>
        public string IconImageName { get; set; }

        /// <summary>
        /// Gets or sets the name of the tooltip image
        /// </summary>
        public string TooltipImageName { get; set; }
    }
}
