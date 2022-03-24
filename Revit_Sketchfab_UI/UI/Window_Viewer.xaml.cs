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
using System.Windows.Shapes;

namespace Revit_Sketchfab_UI.UI
{
    /// <summary>
    /// Interaction logic for Window_Viewer.xaml
    /// </summary>
    public partial class Window_Viewer : Window
    {
        public Window_Viewer()
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
    }
}
