using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Coldsteel.Composition
{
    static class TypeHelper
    {
        // TODO: most likely this is a class from Xna/MonoGame,
        // should optimize to check that assembly first.
        public static Type FindType(string name) =>
            Type.GetType(name) ?? AppDomain.CurrentDomain.GetAssemblies().Select(a => a.GetType(name)).FirstOrDefault(t => t != null);
    }
}
