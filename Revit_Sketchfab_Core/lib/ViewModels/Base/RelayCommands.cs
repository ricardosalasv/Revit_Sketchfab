using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Revit_Sketchfab_Core.lib.ViewModels.Base
{
    public class RelayCommands : ICommand
    {
        /// <summary>
        /// The action to execute
        /// </summary>
        private Action mAction = null;

        public event EventHandler CanExecuteChanged = (sender, e) => { };

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="parameter"></param>
        public RelayCommands(Action action)
        {
            mAction = action;
        }

        /// <summary>
        /// Defines the method that determines whether the command can execute in its current state
        /// </summary>
        /// <param name="parameter"></param> Data user by the command. If the command does not require data to be passed, this object can be set to <see langword="null"/>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        /// Defines the method to be called when the command is invoked
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            mAction();
        }
    }
}
