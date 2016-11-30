using Microsoft.Xna.Framework.Content;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Coldsteel
{
    public class ContentBundle
    {
        private Dictionary<string, object> _content = new Dictionary<string, object>();

        private Dictionary<string, Action<string>> _requires = new Dictionary<string, Action<string>>();

        private ContentManager _contentManager;

        internal ContentBundle(ContentManager contentManager)
        {
            _contentManager = contentManager;
        }

        public void Require<T>(string assetName)
        {
            if (_requires.ContainsKey(assetName) || _content.ContainsKey(assetName))
                return;

            _requires.Add(assetName, LoadContent<T>);
        }

        internal void Load()
        {
            foreach (var require in _requires)
                require.Value.Invoke(require.Key);

            // TODO: figure out how to make a loading bar loading screen
            _requires.Clear();
        }

        internal void Unload()
        {
            _contentManager.Unload();
        }

        private void LoadContent<T>(string assetName)
        {
            if (_content.ContainsKey(assetName))
                return;

            _content[assetName] = _contentManager.Load<T>(assetName);
        }
    }
}
