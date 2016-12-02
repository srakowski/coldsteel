using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coldsteel.DeveloperTools.ViewModels
{
    class GameObjectViewModel
    {
        public string Name => _gameObject.Name;

        private GameObject _gameObject;

        public GameObjectViewModel(GameObject gameObject)
        {
            this._gameObject = gameObject;
        }
    }
}
