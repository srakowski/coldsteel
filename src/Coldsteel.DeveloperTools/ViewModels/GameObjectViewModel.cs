using Coldsteel.Components;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coldsteel.DeveloperTools.ViewModels
{
    class GameObjectViewModel : ViewModelBase
    {
        public string Name => _gameObject.Name;

        private GameObject _gameObject;

        public ObservableCollection<GameObjectViewModel> GameObjects { get; set; } = new ObservableCollection<GameObjectViewModel>();

        public ObservableCollection<GameObjectComponentViewModel> Components { get; set; } = new ObservableCollection<GameObjectComponentViewModel>();

        public GameObjectViewModel(GameObject gameObject)
        {
            this._gameObject = gameObject;
            foreach (var childGameObject in gameObject.Transform.Children.Select(c => c.GameObject))
                GameObjects.Add(new GameObjectViewModel(childGameObject));

            Components.Add(new TransformViewModel(_gameObject.Transform));
            foreach (var component in _gameObject.Components)
                Components.Add(new ComponentViewModel(component));
        }
    }
}
