using Coldsteel.DeveloperTools.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace Coldsteel.DeveloperTools
{
    /// <summary>
    /// Interaction logic for DevToolsWindow.xaml
    /// </summary>
    public partial class DevToolsWindow : Window
    {
        public bool HideOnClose { get; set; } = true;

        public DevToolsWindow(ColdsteelGameComponent coldsteel)
        {
            InitializeComponent();
            this.SceneView.Content = new SceneView(coldsteel);
            this.Closing += new CancelEventHandler((sender, e) =>
            {
                if (!HideOnClose)
                    return;

                e.Cancel = true;
                this.Hide();
            });
        }
    }
}
