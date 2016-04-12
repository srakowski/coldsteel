using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coldsteel.Tests.Doubles
{
    class MockRenderer : Renderer
    {
        public bool RenderWasInvoked { get; set; } = false;

        public MockRenderer()
            : base(null)
        {
        }

        public override void Render(IGameTime gameTime)
        {
            RenderWasInvoked = true;
        }
    }
}
