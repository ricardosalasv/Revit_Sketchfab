using Revit_Sketchfab_Core;
using Revit_Sketchfab_Core.lib.Commands;
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

        private async void export_button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            ExportModel exportCommand = new ExportModel();
            await exportCommand.Execute();
        }

        private void library_button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
