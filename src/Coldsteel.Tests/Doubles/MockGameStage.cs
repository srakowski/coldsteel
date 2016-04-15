using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coldsteel.Tests.Doubles
{
    class MockGameStage : GameStage
    {
        public bool LoadContentWasInvoked { get; internal set; } = false;

        public bool InitializeWasInvoked { get; set; } = false;
        public bool AttemptToLoadContent { get; internal set; }

        protected override void LoadContent()
        {
            this.LoadContentWasInvoked = true;
            if (AttemptToLoadContent)
                LoadContent<Texture2D>("testonly");
        }

        protected override void Initialize()
        {
            this.InitializeWasInvoked = true;
        }
    }
}
