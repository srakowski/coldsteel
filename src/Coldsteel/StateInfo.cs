using System;
using System.Collections.Generic;
using System.Text;

namespace Coldsteel
{
    public struct StateInfo
    {
        public string Key;
        public Type Type;
        public List<StateMachineTrigger> Triggers;
        public StateInfo(string key, Type type)
        {
            Key = key;
            Type = type;
            Triggers = new List<StateMachineTrigger>();
        }
    }
}
