using System;
using System.Collections.Generic;
using System.Text;
using Coldsteel.Input;
using Coldsteel.Rendering;
using Microsoft.Xna.Framework;

namespace Coldsteel
{
    public class GameObject
    {
        public GameObjectConfigurator Set { get; private set; }

        public GameObjectComponentAdder Add { get; private set; }

        public GameObject Parent { get; private set; }

        private List<GameObject> _children = new List<GameObject>();

        public IEnumerable<GameObject> Children => _children;

        private GameState _gameState;

        public World World => _gameState.World;

        public ContentManager Content => _gameState.Load;

        public LayerManager Layers => _gameState.Layers;

        public InputManager Input => _gameState.Input;

        public Transform Transform { get; private set; }

        public Layer Layer { get; internal set; }

        private Renderer _renderer;

        public Renderer Renderer
        {
            get { return _renderer; }
            set
            {
                Layer.RemoveRenderer(_renderer);
                _renderer = value;
                Layer.AddRenderer(_renderer);
            }
        }

        private List<Behavior> _behaviors = new List<Behavior>();

        public IEnumerable<Behavior> Behaviors => _behaviors;

        public IGameTime GameTime { get; private set; }

        internal GameObject(GameState gameState)
        {
            _gameState = gameState;
            Layer = Layers.Default;
            Set = new GameObjectConfigurator(this);
            Add = new GameObjectComponentAdder(this);
            AddGameObjectComponent(new Transform());
        }

        public GameObject AddGameObject()
        {
            var gameObject = World.AddGameObject();
            gameObject.Parent = this;
            _children.Add(gameObject);
            return gameObject;
        }

        internal void AddGameObjectComponent(GameObjectComponent component)
        {
            component.GameObject = this;
            this.Transform = component as Transform ?? Transform;
            this.Renderer = component as Renderer ?? Renderer;
            if (component is Behavior)
                _behaviors.Add(component as Behavior);
        }

        internal void Update(GameTime gameTime)
        {
            this.GameTime = new GameTimeWrapper(gameTime);
            _behaviors.ForEach(b => b.Update());
        }
    }
}
