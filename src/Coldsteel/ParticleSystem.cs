using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coldsteel
{
    public class ParticleSystem : GameObjectComponent
    {
        public Layer Layer { get; set; }

        private Texture2D _texture;

        public Texture2D Texture
        {
            get { return _texture; }
            set
            {
                _texture = value;
                _textureCenter = new Vector2(_texture.Width * 0.5f, _texture.Height * 0.5f);
            }
        }

        private Vector2 _textureCenter;

        public float TTL { get; set; } = 80f;

        public Color Color { get; set; } = Color.White;

        public float Speed { get; set; } = 1f;        

        private Random _rand = new Random();

        public float MaxScaleVelocity { get; set; } = 0f;

        public ParticleSystem(Layer layer, Texture2D texture)
        {
            this.Layer = layer;
            this.Texture = texture;
        }

        public override void Update(IGameTime gameTime)
        {
            UpdateParticles(gameTime);
            EmitNewParticles(gameTime);
        }

        private List<Particle> _particles = new List<Particle>();

        private void UpdateParticles(IGameTime gameTime)
        {

            for (var i = 0; i < _particles.Count; i++)
            {
                var particle = _particles[i];
                particle.TTL -= gameTime.Delta;
                if (particle.TTL > 0)
                {
                    particle.Position += particle.Velocity * gameTime.Delta;
                    particle.Scale += particle.ScaleVelocity * gameTime.Delta;
                }
                _particles[i] = particle;
            }

            _particles.RemoveAll(p => p.TTL < 0);
        }

        private void EmitNewParticles(IGameTime gameTime)
        {
            for (var i = 0; i < 10; i++)
                _particles.Add(new Particle()
                {
                    Position = this.Transform.Position,
                    Velocity = new Vector2(_rand.Next(-100, 50) / 100f, _rand.Next(-20, 21) / 100f) * Speed,
                    TTL = this.TTL,
                    Color = this.Color,
                    Scale = (float)_rand.NextDouble(),
                    ScaleVelocity = (float)_rand.NextDouble() * MaxScaleVelocity
                });
        }

        internal void Render(IGameTime gameTime)
        {
            foreach (var particle in _particles)
                Layer.Render(
                    this.Texture,
                    particle.Position,
                    null,
                    particle.Color,
                    0f,
                    _textureCenter,
                    particle.Scale,
                    SpriteEffects.None,
                    1f);
        }
    }
}
