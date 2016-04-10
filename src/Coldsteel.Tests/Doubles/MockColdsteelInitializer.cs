using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coldsteel.Tests.Doubles
{
    class MockColdsteelInitializer : IColdsteelInitializer
    {
        public bool InitializeControlsWasInvoked = false;

        public Input ProvidedInputObject { get; set; } = null;
               
        public void InitializeControls(Input input)
        {
            InitializeControlsWasInvoked = true;
            ProvidedInputObject = input;            
        }
    }
}
