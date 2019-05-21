using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;

namespace Coldsteel
{
    public class Scene
    {
        private readonly List<Entity> _entities = new List<Entity>();

        private readonly List<SpriteLayer> _spriteLayers = new List<SpriteLayer>();

        private readonly List<Asset> _assets = new List<Asset>();

        private Engine _engine;

        private ContentManager _content;

        public Scene AddEntity(Entity entity)
        {
            _entities.Add(entity);
            if (_engine != null)
                entity.Activate(_engine, this);
            return this;
        }

        public IEnumerable<Asset> Assets => _assets;

        public Scene AddContentDependency(Asset asset)
        {
            _assets.Add(asset);
            if (_content != null)
                asset.Load(_content);
            return this;
        }

        public IEnumerable<SpriteLayer> SpriteLayers => _spriteLayers;

        public Scene AddSpriteLayer(SpriteLayer spriteLayer)
        {
            _spriteLayers.Add(spriteLayer);
            return this;
        }

        internal void Activate(Engine engine)
        {
            _engine = engine;
            _content = new ContentManager(_engine.Game.Services, _engine.Game.Content.RootDirectory);

            foreach (var contentDependency in _assets)
                contentDependency.Load(_content);

            foreach (var entity in _entities.ToArray())
                entity.Activate(engine, this);
        }

        internal void Deactivate()
        {
            foreach (var entity in _entities)
                entity.Deactivate();

            foreach (var contentDependency in _assets)
                contentDependency.Unload();

            _content.Unload();
            _content = null;
            _engine = null;
        }
    }
}