using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coldsteel.Tests.Doubles
{
    class MockGameResourceFactory : IGameResourceFactory
    {
        public MockContentManager MockContentManager { get; set; }

        public IContentManager CreateContentManager()
        {
            return MockContentManager ?? new MockContentManager();
        }

        public SpriteBatch CreateSpriteBatch()
        {
            return null;
        }
    }
}
