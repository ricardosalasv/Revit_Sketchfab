using Revit_Sketchfab_Core;
using Revit_Sketchfab_Core.lib;
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
    /// Interaction logic for Window_Library.xaml
    /// </summary>
    public partial class Window_Library : Window
    {
        private IList<GetModel> modelList;

        public Window_Library()
        {
            InitializeComponent();
            this.MouseDown += Window_MouseDown;

            AppState.InitializedWPFWindows.Add(this);
        }

        public async Task<string> ShowWithUpdatedList()
        {
            modelList = await AppState.client.GetModelLibrary();

            models_ListBox.ItemsSource = modelList;

            base.Show();

            return "succeed";
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

        private void open_button_Click(object sender, RoutedEventArgs e)
        {
            GetModel selectedItem = models_ListBox.SelectedItem as GetModel;

            System.Diagnostics.Process.Start(selectedItem.viewerUrl);

            this.Close();
        }
    }
}
