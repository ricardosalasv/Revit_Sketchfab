using Autodesk.Revit.UI;
using Revit_Sketchfab_Core;
using Revit_Sketchfab_Core.lib.Commands;
using Revit_Sketchfab_Core.lib.ExternalEvents;
using Revit_Sketchfab_Core.lib.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Revit_Sketchfab_UI.UI
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window_Menu : Window
    {
        private ExternalEvent extEvent;
        private AppExternalEvent evHandler;
        public Window_Menu()
        {
            InitializeComponent();
            evHandler = new AppExternalEvent();
            extEvent = ExternalEvent.Create(evHandler);

            DataContext = new MenuModelViewModel(extEvent);

            this.MouseDown += Window_MouseDown;
            AppState.InitializedWPFWindows.Add(this);
        }

        protected override void OnClosed(EventArgs e)
        {
            extEvent.Dispose();
            extEvent = null;
            evHandler = null;

            base.OnClosed(e);
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void exit_button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void logout_button_Click(object sender, RoutedEventArgs e)
        {
            AppState.IsUserLoggedIn = false;
            this.Close();
        }
    }
}
