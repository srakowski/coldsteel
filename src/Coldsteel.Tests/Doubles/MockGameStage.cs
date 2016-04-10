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

        public override void LoadContent()
        {
            this.LoadContentWasInvoked = true;
        }

        public override void Initialize()
        {
            this.InitializeWasInvoked = true;
        }
    }
}
