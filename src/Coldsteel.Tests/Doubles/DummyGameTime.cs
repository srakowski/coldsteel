using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coldsteel.Tests.Doubles
{
    class DummyGameTime : IGameTime
    {
        public float Delta
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
