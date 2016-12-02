using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coldsteel.DeveloperTools.ViewModels
{
    class SceneViewModel : ViewModelBase
    {
        private SceneManager _sceneManager;

        public ObservableCollection<GameObjectViewModel> GameObjects { get; set; } = new ObservableCollection<GameObjectViewModel>();

        public SceneViewModel(ColdsteelGameComponent coldsteel)
        {
            this._sceneManager = coldsteel.SceneManager;
            this._sceneManager.ActiveSceneChanged += SceneManager_ActiveSceneChanged;
        }

        private void SceneManager_ActiveSceneChanged(object sender, EventArgs e)
        {
            GameObjects.Clear();
            foreach (var gameObject in _sceneManager.ActiveScene.GameObjects)
                GameObjects.Add(new GameObjectViewModel(gameObject));
        }
    }
}
