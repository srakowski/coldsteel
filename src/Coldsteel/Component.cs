// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using Microsoft.Xna.Framework.Content;
using System.Linq;

namespace Coldsteel
{
    /// <summary>
    /// A building block of a GameObject that defines its state, behavior, 
    /// and visual representation.
    /// </summary>
    public abstract class Component
    {
        public GameObject GameObject { get; internal set; }

        internal Transform Transform => GameObject.Transform;

        internal virtual void Activate(Context context) { }
    }
}
