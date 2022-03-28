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
        public Window_Menu()
        {
            InitializeComponent();
            this.MouseDown += Window_MouseDown;

            AppState.InitializedWPFWindows.Add(this);
        }

        protected override void OnClosed(EventArgs e)
        {
            AppState.InitializedWPFWindows.Remove(this);

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

        private void export_button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Window_Export window_Export = AppState.GetWindow("Window_Export") as Window_Export;
            window_Export.Activate();
            window_Export.Show();
        }

        private async void library_button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

            Window_Library window_Library = AppState.GetWindow("Window_Library") as Window_Library;
            await window_Library.ShowWithUpdatedList();
        }
    }
}
