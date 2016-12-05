using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coldsteel.Core
{
    internal static class MonoGameExtensions
    {
        public static object Load(this ContentManager contentManager, Type type, string assetName)
        {
            var loadMethod = contentManager.GetType().GetMethod(nameof(contentManager.Load));
            var genericLoad = loadMethod.MakeGenericMethod(type);
            var content = genericLoad.Invoke(contentManager, new object[] { assetName });
            return content;
        }
    }
}
