using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coldsteel.Particles
{
    internal struct Particle
    {
        public string LayerKey;
        public Texture2D Image;
        public Vector2 Position;
        public Color Color;
        public float Rotation;
        public Vector2 Origin;
        public float Scale;
        public double Ttl;
        public Vector2 Velocity;
        public float ScaleVelocity;
        public float RotationVelocity;

        internal Particle Update(IGameTime gameTime)
        {
            this.Ttl -= gameTime.Delta;
            if (this.Ttl > 0)
            {
                Position += Velocity * gameTime.Delta;
                Scale += ScaleVelocity * gameTime.Delta;
                Rotation += RotationVelocity * gameTime.Delta;
            }
            return this;
        }

        public void Render(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                this.Image,
                this.Position,
                null,
                this.Color,
                this.Rotation,
                this.Origin,
                this.Scale,
                SpriteEffects.None,
                0f);
        }
    }
}
