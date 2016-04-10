using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coldsteel
{
    internal class ContentManagerWrapper : IContentManager
    {
        private ContentManager _contentManager;

        public ContentManagerWrapper(ContentManager contentManager)
        {
            _contentManager = contentManager;
        }

        public T Load<T>(string path) where T : class
        {
            return _contentManager.Load<T>(path);
        }

        public void Unload()
        {
            _contentManager.Unload();
        }
    }
}
