using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coldsteel.Tests.Doubles
{
    class MockContentManager : IContentManager
    {
        public object DummyContentLoaded { get; set; }

        public T Load<T>(string path) where T : class
        {
            this.DummyContentLoaded = Activator.CreateInstance(typeof(T)) as T;
            return this.DummyContentLoaded as T;
        }

        public void Unload()
        {
        }
    }
}
