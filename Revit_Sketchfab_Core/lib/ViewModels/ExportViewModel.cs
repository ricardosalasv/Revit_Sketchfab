using Autodesk.Revit.UI;
using Revit_Sketchfab_Core.lib.Commands;
using Revit_Sketchfab_Core.lib.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Revit_Sketchfab_Core.lib.ViewModels
{
    public class ExportViewModel : BaseViewModel
    {
        public ExternalEvent extEvent { get; set; }

        private string modelName { get; set; }
        public string ModelName {
            get { return modelName; } 
            set { modelName = value;
                OnPropertyChanged("ModelName"); }
        }

        public ICommand ExportAllButtonCommand { get; set; }
        public ICommand ExportSelectedButtonCommand { get; set; }

        public ExportViewModel(ExternalEvent eEvent)
        {
            modelName = "Model Name";

            ExportAllButtonCommand = new RelayCommands(ExportAllButtonExec);
            ExportSelectedButtonCommand = new RelayCommands(ExportSelectedButtonExec);

            extEvent = eEvent;
        }

        private void ExportAllButtonExec()
        {
            if (modelName == "Model Name")
            {
                TaskDialog.Show("Warning", "You need to specify a name for exporting the model.");
            }
            else
            {
                ExportModel command = new ExportModel(false, modelName);

                // Binding functionality to command events
                command.RaiseModelExportingEvent += (sender, e) =>
                {
                    AppState.GetWindow("Window_WarningModelExporting").Show();
                };

                command.RaiseModelExportedEvent += (sender, e) =>
                {
                    AppState.GetWindow("Window_WarningModelExporting").Hide();
                    AppState.GetWindow("Window_WarningModelExported").Show();
                };

                AppState.CommandToExecute = command.Execute;

                extEvent.Raise();
            }
            
        }

        private void ExportSelectedButtonExec()
        {
            if (modelName == "Model Name")
            {
                TaskDialog.Show("Warning", "You need to specify a name for exporting the model.");
                AppState.GetWindow("Window_Export").Focus();
            }
            else
            {
                ExportModel command = new ExportModel(true, modelName);

                // Binding functionality to command events
                command.RaiseModelExportingEvent += (sender, e) =>
                {
                    AppState.GetWindow("Window_WarningModelExporting").Show();
                };

                command.RaiseModelExportedEvent += (sender, e) =>
                {
                    AppState.GetWindow("Window_WarningModelExporting").Hide();
                    AppState.GetWindow("Window_WarningModelExported").Show();
                };

                AppState.CommandToExecute = command.Execute;

                extEvent.Raise();
            }
        }
    }
}
