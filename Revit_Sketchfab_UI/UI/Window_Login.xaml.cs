using Autodesk.Revit.UI;
using Revit_Sketchfab_Core;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Revit_Sketchfab_UI.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Window_Login : Window
    {
        public Window_Login()
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

        private async void login_button_Click(object sender, RoutedEventArgs e)
        {
            string email = emailTextBox.Text;
            string password = passwordBox.Password;

            AppState.IsUserLoggedIn = await AppState.client.Authenticate(email, password);

            if (AppState.IsUserLoggedIn)
            {
                this.Close();

                Window_Menu window_Menu = AppState.GetWindow("Window_Menu") as Window_Menu;
                window_Menu.Activate();
                window_Menu.Show();
            }
            else
            {
                TaskDialog.Show("Warning", "The login credentials are invalid.");
                this.Focus();
            }
        }

        private void exit_button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }

}
