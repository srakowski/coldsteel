// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

namespace Coldsteel
{
    /// <summary>
    /// Base type for all elements that compose a scene, e.g. GameObjects, Layers, etc.
    /// </summary>
    public abstract class SceneElement
    {
        public virtual bool IsDestroyed { get; }

        internal virtual void Activate(Context context) { }
    }
}
