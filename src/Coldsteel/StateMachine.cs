using System;
using System.Collections.Generic;
using System.Text;

namespace Coldsteel
{
    public abstract class StateMachine : GameObjectComponent
    {
        private Behavior _currentState;

        private StateInfo _currentStateInfo;

        private Dictionary<string, StateInfo> _stateInfo = new Dictionary<string, StateInfo>();

        public StateInfoConfigurator AddState<T>(string key) where T : Behavior, new()
        {
            var stateInfo = new StateInfo(key, typeof(T));
            _stateInfo[key] = stateInfo;
            return new StateInfoConfigurator(stateInfo);
        }

        public void Start(string key)
        {
            if (_currentState != null)
            {
                GameObject.RemoveGameObjectComponent(_currentState);
                _currentState.Dispose();
            }

            _currentStateInfo = _stateInfo[key];
            _currentState = Activator.CreateInstance(_currentStateInfo.Type) as Behavior;
            GameObject.AddGameObjectComponent(_currentState);
        }

        public override void Update()
        {
            var triggers = _currentStateInfo.Triggers;
            foreach (var trigger in triggers)
                if (trigger.Condition())
                {
                    Start(trigger.StateKey);
                    break;
                }

        }
    }
}
