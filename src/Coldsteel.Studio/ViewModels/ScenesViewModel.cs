using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coldsteel.Studio.ViewModels
{
    public class ScenesViewModel : ViewModelBase
    {
        public string Name { get; set; } = "Scenes";

        public ObservableCollection<SceneViewModel> Children { get; } = new ObservableCollection<SceneViewModel>();

        public RelayCommand NewSceneCommand { get; }

        public ScenesViewModel()
        {
            NewSceneCommand = new RelayCommand(NewScene);
        }

        internal void NewScene() => Children.Add(new SceneViewModel());
    }
}
