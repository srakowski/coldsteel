using Coldsteel.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coldsteel.DeveloperTools.ViewModels
{
    class ComponentViewModel : GameObjectComponentViewModel
    {
        public override string Type => _component.GetType().Name;

        private IComponent _component;

        public ComponentViewModel(IComponent component)
        {
            this._component = component;
        }
    }
}
