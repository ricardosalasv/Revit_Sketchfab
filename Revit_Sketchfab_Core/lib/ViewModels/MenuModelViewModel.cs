using Autodesk.Revit.UI;
using Revit_Sketchfab_Core.lib.Commands;
using Revit_Sketchfab_Core.lib.ViewModels.Base;
using System.Windows.Input;

namespace Revit_Sketchfab_Core.lib.ViewModels
{
    /// <summary>
    /// A view model for the main application page
    /// </summary>
    public class MenuModelViewModel : BaseViewModel
    {
        public ExternalEvent extEvent { get; set; }
        public ICommand ExportButtonCommand { get; set; }
        public ICommand LibraryButtonCommand { get; set; }

        public MenuModelViewModel(ExternalEvent eEvent)
        {
            ExportButtonCommand = new RouteCommands(ExportButtonExec);
            LibraryButtonCommand = new RouteCommands(LibraryButtonExec);

            extEvent = eEvent;
        }

        private void ExportButtonExec()
        {
            ExportModel command = new ExportModel();
            AppState.CommandToExecute = command.Execute;

            extEvent.Raise();
        }

        private void LibraryButtonExec()
        {
            TaskDialog.Show("info", "I work 2");
        }
    }
}
