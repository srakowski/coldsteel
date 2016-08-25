using Coldsteel.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Coldsteel.Particles
{
    internal class ParticleRenderer : IRenderer
    {
        private Func<IEnumerable<Particle>> _particlesGetter;

        public ParticleRenderer(Func<IEnumerable<Particle>> particlesGetter)
        {
            _particlesGetter = particlesGetter;
        }

        public void Render(GameTime gameTime, SpriteBatch spriteBatch)
        {
            foreach (var p in _particlesGetter.Invoke())
                p.Render(gameTime, spriteBatch);
        }
    }
}
