using Autodesk.Revit.UI;
using Revit_Sketchfab_Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revit_Sketchfab.RevitUI
{
    /// <summary>
    /// Represents the Revit PushButton
    /// </summary>
    public static class RevitPushButton
    {
        /// <summary>
        /// Creates the PushButton based on the PushButtonDataModel provided in <see cref="RevitPushButtonDataModel"/>
        /// </summary>
        /// <param name="dataModel"></param>
        /// <returns></returns>
        public static PushButton Create(RevitPushButtonDataModel dataModel)
        {
            // The button name based on unique identifier
            var btnDataName = Guid.NewGuid().ToString();

            // Sets the button data
            var btnData = new PushButtonData(btnDataName, dataModel.Label, MainAssembly.GetAssemblyLocation(), dataModel.CommandNamespacePath)
            {
                ToolTip = dataModel.Tooltip,
                LargeImage = ResourceImage.GetIcon(dataModel.IconImageName),
                ToolTipImage = ResourceImage.GetIcon(dataModel.TooltipImageName)
            };

            // Return create button and host it on panel provided in required data model
            return dataModel.Panel.AddItem(btnData) as PushButton;
        }
    }
}
