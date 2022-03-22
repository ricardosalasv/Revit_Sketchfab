using Autodesk.Revit.UI;
using Revit_Sketchfab.Entrypoints;
using Revit_Sketchfab.RevitUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revit_Sketchfab
{
    /// <summary>
    /// Setup whole plugins interface with tabs, panels, buttons
    /// </summary>
    public class SetupUI
    {
        /// <summary>
        /// Default constructor.
        /// Initializes a new instance of the <see cref="SetupUI"/>
        /// </summary>
        public SetupUI()
        {

        }

        /// <summary>
        /// Initializes all interface elements on custom created Revit tab
        /// </summary>
        /// <param name="app"></param>
        public static void Initialize(UIControlledApplication app)
        {
            // Create ribbon tab
            string tabName = "Sketchfab Integration";
            app.CreateRibbonTab(tabName);

            // Create the export commands panel
            RibbonPanel exportPanel = app.CreateRibbonPanel(tabName, "Export");

            // Populate button data model
            var exportModelButtonData = new RevitPushButtonDataModel()
            {
                Label = "Export Models",
                Panel = exportPanel,
                Tooltip = "This command opens the Sketchfab Integration interface.",
                IconImageName = "icon_export.png",
                TooltipImageName = "icon_tooltip_export.png",
                CommandNamespacePath = Start_App.GetPath()
            };

            // Create PushButton from provided data model
            PushButton exportButton = RevitPushButton.Create(exportModelButtonData);
        }
    }
}
