using System;
using System.Collections.Generic;
using System.Text;

namespace Coldsteel
{
    public class GameStageRegistry
    {
        public Type Default { get; private set; }

        public IEnumerable<string> Keys { get { return _stages.Keys; } }

        private Dictionary<string, Type> _stages = new Dictionary<string, Type>();        

        public Type this[string key] { get { return _stages[key]; } }

        public void RegisterStage<T>(string key) where T : GameStage
        {
            if (this.Default == null)
                this.Default = typeof(T);

            _stages[key] = typeof(T);
        }

        public void RegisterStage<T>() where T : GameStage
        {
            this.RegisterStage<T>(typeof(T).Name);
        }
    }
}
