// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using Microsoft.Xna.Framework.Content;
using System.Linq;
using System;

namespace Coldsteel
{
    /// <summary>
    /// A building block of a Entity that defines its state, behavior, 
    /// and visual representation.
    /// </summary>
    public abstract class Component
    {
        public Entity Entity { get; internal set; }

        internal Transform Transform => Entity.Transform;

        internal virtual void Activate(Context context) { }

        internal virtual void HandleMessage(object message) { }
    }
}
