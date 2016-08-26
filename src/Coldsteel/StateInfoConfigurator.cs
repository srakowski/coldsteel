using System;
using System.Collections.Generic;
using System.Text;

namespace Coldsteel
{
    public class StateInfoConfigurator
    {
        private StateInfo _statInfo;

        public StateInfoConfigurator(StateInfo stateInfo)
        {
            _statInfo = stateInfo;
        }

        public StateMachineTriggerConfigurator Trigger(string stateKey)
        {
            var trigger = new StateMachineTrigger(stateKey);
            _statInfo.Triggers.Add(trigger);
            return new StateMachineTriggerConfigurator(this, trigger);
        }
    }
}
