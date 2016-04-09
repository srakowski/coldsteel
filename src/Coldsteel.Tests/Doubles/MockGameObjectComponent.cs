using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coldsteel.Tests.Doubles
{
    class MockGameObjectComponent : GameObjectComponent
    {        
        public bool WasUpdated { get; set; } = false;

        public bool RemoveFromGameObjectDuringUpdate { get; set; } = false;

        public override void Update(IGameTime gameTime)
        {
            WasUpdated = true;
            if (RemoveFromGameObjectDuringUpdate)
                this.GameObject.RemoveComponent(this);
        }
    }
}
