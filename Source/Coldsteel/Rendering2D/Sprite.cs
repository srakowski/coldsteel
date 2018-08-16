// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of this source code package.

namespace Coldsteel.Rendering2D
{
    /// <summary>
    /// Abstract base class for Sprite types.
    /// </summary>
    public abstract class Sprite : Component
    {
        internal override void OnActivated(GameState gameState)
        {
            SpriteRenderingSystem.RegisterSprite(gameState, this);
        }

        internal override void OnDeactivated(GameState gameState)
        {
            SpriteRenderingSystem.DeregisterSprite(gameState, this);
        }
    }
}
