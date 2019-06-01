// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using Microsoft.Xna.Framework;

namespace Coldsteel
{
    public class UIHost : Component
    {
        public UIHost(Element root)
        {
            Root = root;
            Tree = null;
        }

        public Element Root { get; }

        internal ElementNode Tree { get; private set; }

        private protected override void Activated()
        {
            Tree = Root.CreateTree(null);
            Engine.UISystem.AddUIHost(Scene, this);
        }

        private protected override void Deactivated()
        {
            Engine.UISystem.RemoveUIHost(Scene, this);
            Tree = null;
        }

        internal void Update(GameTime gameTime)
        {
            if (Tree == null) return;
        }

        public static UIHost New(Element root) => new UIHost(root);
    }
}
