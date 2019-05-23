// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Linq;

namespace Coldsteel
{
    public class Sprite : Component
    {
        private Asset<Texture2D> _texture;

        public string AssetName;

        public Rectangle? SourceRectangle;

        public Color Color = Color.White;

        public Vector2 Origin;

        public SpriteEffects SpriteEffects;

        public float LayerDepth;

        public bool Enabled = true;

        public string SpriteLayerName;

        public Sprite() { }

        public Sprite(string assetName, string spriteLayerName)
        {
            AssetName = assetName;
            SpriteLayerName = spriteLayerName;
        }

        private protected override void Activated()
        {
            Engine.SpriteSystem.AddSprite(Scene, this);
            _texture = Scene.Assets.FirstOrDefault(a => a.Name == AssetName) as Asset<Texture2D>;
        }

        private protected override void Deactivated()
        {
            _texture = null;
            Engine.SpriteSystem.RemoveSprite(Scene, this);
        }

        internal void Draw(SpriteBatch spriteBatch)
        {
            if (!(_texture?.IsLoaded ?? false) || !Enabled) return;
            spriteBatch.Draw(
                _texture.GetValue(),
                Entity.Position,
                SourceRectangle,
                Color,
                Entity.Rotation,
                Origin,
                Entity.Scale,
                SpriteEffects,
                LayerDepth
            );
        }
    }
}