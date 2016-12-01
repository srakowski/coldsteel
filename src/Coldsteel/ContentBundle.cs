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

        private ContentManager _contentManager;

        internal ContentBundle(ContentManager contentManager)
        {
            _contentManager = contentManager;
        }

        public T Load<T>(string assetName)
        {
            if (_content.ContainsKey(assetName))
                return (T)_content[assetName];

            var content = _contentManager.Load<T>(assetName);
            _content[assetName] = content;
            return content; 
        }

        internal void Unload()
        {
            _content.Clear();
            _contentManager.Unload();
        }
    }
}
