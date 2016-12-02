using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
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
        private GameObjectViewModel _selectedViewModel;

        public GameObjectViewModel SelectedItem
        {
            get { return _selectedViewModel; }
            set
            {
                _selectedViewModel = value;
                RaisePropertyChanged();
            }
        }


        private SceneManager _sceneManager;

        public RelayCommand AddCommand { get; set; }

        public ObservableCollection<GameObjectViewModel> GameObjects { get; set; } = new ObservableCollection<GameObjectViewModel>();

        public SceneViewModel(ColdsteelGameComponent coldsteel)
        {
            this._sceneManager = coldsteel.SceneManager;
            this._sceneManager.ActiveSceneChanged += SceneManager_ActiveSceneChanged;
            AddCommand = new RelayCommand(Add);
        }

        private void Add()
        {
            var newGameObject = new GameObject("GameObject");
            GameObjects.Add(new GameObjectViewModel(newGameObject));
            _sceneManager.ActiveScene.GameObjects.Add(newGameObject);
        }

        private void SceneManager_ActiveSceneChanged(object sender, EventArgs e)
        {
            GameObjects.Clear();
            foreach (var gameObject in _sceneManager.ActiveScene.GameObjects.Where(go => go.Transform.Parent == null))
                GameObjects.Add(new GameObjectViewModel(gameObject));
        }
    }
}
