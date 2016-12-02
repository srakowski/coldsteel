using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coldsteel.DeveloperTools.ViewModels
{
    class TransformViewModel : GameObjectComponentViewModel
    {
        private Transform _transform;

        public override string Type => "Transform";

        public TransformViewModel(Transform transform)
        {
            _transform = transform;
        }
    }
}
