using System;
using System.Collections.Generic;
using System.Text;

namespace Coldsteel
{
    public class StateMachineTrigger
    {
        public Func<bool> Condition { get; set; } = () => true;

        public string StateKey { get; set; }

        public StateMachineTrigger(string stateKey)
        {
            this.StateKey = stateKey;
        }
    }
}
