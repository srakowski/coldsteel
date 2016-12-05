using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coldsteel.Studio.ViewModels
{
    public class SceneViewModel : ViewModelBase
    {
        public string Name { get; set; } = "NewScene";

        public ObservableCollection<GameObjectViewModel> GameObjects { get; set; } = new ObservableCollection<GameObjectViewModel>();
    }
}
