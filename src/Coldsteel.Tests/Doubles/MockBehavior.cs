using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coldsteel.Tests.Doubles
{
    class MockBehavior : Behavior
    {
        public bool HandleInputWasInvoked { get; set; } = false;

        public override void HandleInput(IGameTime gameTime, Input input)
        {
            HandleInputWasInvoked = true;
        }
    }
}
