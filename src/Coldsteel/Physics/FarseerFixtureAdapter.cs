using System;
using System.Collections.Generic;
using System.Text;
using FarseerPhysics.Dynamics;

namespace Coldsteel.Physics
{
    internal class FarseerFixtureAdapter
    {
        private Fixture _fixture;

        public FarseerFixtureAdapter(Fixture fixture)
        {
            this._fixture = fixture;
        }
    }
}
