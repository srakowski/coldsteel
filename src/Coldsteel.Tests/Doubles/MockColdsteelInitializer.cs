using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coldsteel.Tests.Doubles
{
    class MockColdsteelInitializer : IColdsteelInitializer
    {
        public bool InitializeControlsWasInvoked { get; set; } = false;

        public Input ProvidedInputObject { get; set; } = null;

        public void InitializeControls(Input input)
        {
            InitializeControlsWasInvoked = true;
            ProvidedInputObject = input;
        }

        public bool RegisterStagesWasInvoked { get; set; } = false;

        public GameStageCollection ProvidedGameStageCollection { get; set; } = null;

        public void RegisterStages(GameStageCollection stages)
        {
            RegisterStagesWasInvoked = true;
            ProvidedGameStageCollection = stages;
        }
    }
}
