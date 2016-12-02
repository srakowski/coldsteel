using Coldsteel.DeveloperTools.Views;
using System.ComponentModel;
using System.Windows;

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
