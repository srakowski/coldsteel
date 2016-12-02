using Coldsteel.DeveloperTools.ViewModels;
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

namespace Coldsteel.DeveloperTools.Views
{
    /// <summary>
    /// Interaction logic for SceneView.xaml
    /// </summary>
    public partial class SceneView : UserControl
    {
        public SceneView(ColdsteelGameComponent coldsteel)
        {
            InitializeComponent();
            this.DataContext = new SceneViewModel(coldsteel);
        }
    }
}
