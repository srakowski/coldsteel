using System;
using System.Collections.Generic;
using System.Text;

namespace Coldsteel
{
    public class StateMachineTriggerConfigurator
    {
        private StateInfoConfigurator _stateInfoConfigurator;

        private StateMachineTrigger _trigger;

        public StateMachineTriggerConfigurator(StateInfoConfigurator stateInfoConfigurator, StateMachineTrigger trigger)
        {
            _stateInfoConfigurator = stateInfoConfigurator;
            _trigger = trigger;
        }

        public StateInfoConfigurator When(Func<Behavior, bool> condition)
        {
            _trigger.Condition = condition;
            return _stateInfoConfigurator;
        }
    }
}
