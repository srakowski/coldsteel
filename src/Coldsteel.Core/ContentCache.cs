using System;
using System.Collections.Generic;
using System.Text;

namespace Coldsteel
{
    public class ContentCache
    {
        private Dictionary<string, object> _gameContent = new Dictionary<string, object>();

        public T Get<T>(string assetName) => 
            (T)_gameContent[assetName];

        internal void Set(string assetName, object content) =>
            _gameContent[assetName] = content;

        internal void Clear() =>
            _gameContent.Clear();
    }
}
