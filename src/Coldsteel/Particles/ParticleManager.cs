using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Coldsteel.Particles
{
    internal class ParticleManager 
    {
        private List<Particle> _particles = new List<Particle>();

        public ParticleManager(LayerManager layerManager)
        {
            layerManager.ForEach(AddParticleRenderer);
            layerManager.LayerAdded += LayerManager_LayerAdded;
        }

        private void LayerManager_LayerAdded(object sender, LayerAddedEvent e)
        {
            AddParticleRenderer(e.Layer);
        }

        private void AddParticleRenderer(Layer layer)
        {
            layer.AddRenderer(new ParticleRenderer(() => _particles.Where(p => p.LayerKey == layer.Key)));
        }

        public void AddParticles(IEnumerable<Particle> particles)
        {
            _particles.AddRange(particles);
        }

        public void Update(GameTime gameTime)
        {
            var gt = new GameTimeWrapper(gameTime);
            for (int i = 0; i < _particles.Count; i++)
                _particles[i] = _particles[i].Update(gt);
            _particles.RemoveAll(p => p.Ttl < 0);
        }
    }
}
