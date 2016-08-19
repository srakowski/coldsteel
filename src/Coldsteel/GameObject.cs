using System;
using System.Collections.Generic;
using System.Text;
using Coldsteel.Input;
using Coldsteel.Rendering;
using Microsoft.Xna.Framework;
using Coldsteel.Physics;

namespace Coldsteel
{
    public class GameObject
    {
        /// <summary>
        /// Tags are used to identify what type of GameObject this GameObject is.
        /// </summary>
        public string[] Tags { get; internal set; }


        /// <summary>
        /// Used to perform common modifications to the state of the 
        /// GameObject such as rotating or transforming.
        /// </summary>
        public GameObjectConfigurator Set { get; private set; }


        /// <summary>
        /// Use to add GameObjectComponents to the GameObject.
        /// </summary>
        public GameObjectComponentAdder Add { get; private set; }


        /// <summary>
        /// If this GameObject is a child of another GameObject and not the World
        /// then this will be populated with the parent. Being a child of another
        /// GameObject affects components such as the Transform. The transform of
        /// a child GameObject is relative to the Parent.
        /// </summary>
        public GameObject Parent { get; private set; }


        private List<GameObject> _children = new List<GameObject>();

        /// <summary>
        /// The Children of this GameObject. Some behaviors are relative
        /// to this GameObject.
        /// </summary>
        public IEnumerable<GameObject> Children => _children;


        /// <summary>
        /// The World this GameObject belongs to.
        /// </summary>
        public World World { get; private set; }


        /// <summary>
        /// Gets the StateManager.
        /// </summary>
        public GameStateManager State => World?.GameState?.State;


        /// <summary>
        /// Gets the GameStage.
        /// </summary>
        public GameStage Stage => World?.GameState?.Stage;


        /// <summary>
        /// Gets the ContentManager.
        /// </summary>
        public ContentManager Content => World?.GameState?.Load;


        /// <summary>
        /// Gets the LayerManager.
        /// </summary>
        public LayerManager Layers => World?.GameState?.Layers;


        /// <summary>
        /// Gets the InputManager.
        /// </summary>
        public InputManager Input => World?.GameState?.Input;


        /// <summary>
        /// Gets the Tranform.
        /// </summary>
        public Transform Transform { get; private set; }


        /// <summary>
        /// Gets the RigidBody.
        /// </summary>
        public RigidBody RigidBody { get; private set; }


        /// <summary>
        /// Gets the Collider.
        /// </summary>
        public Collider Collider { get; private set; }


        private Layer _layer;

        /// <summary>
        /// Gets the Layer this GameObject will be rendered to.
        /// </summary>
        public Layer Layer
        {
            get { return _layer; }
            set
            {
                _layer?.RemoveGameObject(this);
                _layer = value;
                _layer?.AddGameObject(this);
            }
        }


        private Renderer _renderer;

        /// <summary>
        /// Gets the Renderer, if any.
        /// </summary>
        public Renderer Renderer
        {
            get { return _renderer; }
            set
            {
                _renderer = value;
                if (Layer == null)
                    Layer = Layers.Default;
            }
        }


        private List<Behavior> _behaviors = new List<Behavior>();

        /// <summary>
        /// Gets the Behaviors.
        /// </summary>
        public IEnumerable<Behavior> Behaviors => _behaviors;


        /// <summary>
        /// Gets the GameTime.
        /// </summary>
        public IGameTime GameTime { get; private set; }


        /// <summary>
        /// Construct a GameObject for the provided World.
        /// </summary>
        /// <param name="world"></param>
        internal GameObject(World world)
        {
            this.World = world;
            this.Set = new GameObjectConfigurator(this);
            this.Add = new GameObjectComponentAdder(this);
            this.AddGameObjectComponent(new Transform());
        }


        /// <summary>
        /// Adds a child GameObject.
        /// </summary>
        /// <param name="tags"></param>
        /// <returns></returns>
        public GameObject AddGameObject(params string[] tags)
        {
            var gameObject = World.AddGameObject(tags);
            gameObject.Parent = this;
            _children.Add(gameObject);
            return gameObject;
        }


        /// <summary>
        /// Kills this GameObject and all its children.
        /// </summary>
        public void Kill()
        {
            Layer?.RemoveGameObject(this);
            Transform?.Dispose();
            World.RemoveGameObject(this);
            foreach (var child in Children)
                child.Kill();
        }


        /// <summary>
        /// Adds or updates a component for this GameObject.
        /// </summary>
        /// <param name="component"></param>
        internal void AddGameObjectComponent(GameObjectComponent component)
        {
            component.GameObject = this;

            this.Transform = component as Transform ?? Transform;
            this.Renderer = component as Renderer ?? Renderer;
            this.Collider = component as Collider ?? Collider;
            this.RigidBody = component as RigidBody ?? RigidBody;
            if (component is Behavior)
                _behaviors.Add(component as Behavior);

            component.Initialize();
        }


        /// <summary>
        /// Handles collisions with other GameObjects.
        /// </summary>
        /// <param name="withGameObject"></param>
        internal void HandlCollision(GameObject withGameObject)
        {
            ForEachBehavior(b => b.OnCollision(withGameObject));
        }


        /// <summary>
        /// Updates the GameObject state.
        /// </summary>
        /// <param name="gameTime"></param>
        internal void Update(GameTime gameTime)
        {
            this.GameTime = new GameTimeWrapper(gameTime);
            ForEachBehavior(b => b.Update());
        }


        /// <summary>
        /// Updates any Coroutines this GameObject has in flight.
        /// </summary>
        /// <param name="gameTime"></param>
        internal void UpdateCoroutines(GameTime gameTime)
        {
            this.GameTime = new GameTimeWrapper(gameTime);
            ForEachBehavior(b => b.UpdateCoroutines());
        }


        /// <summary>
        /// Helper method used to do various updates to Behaviors.
        /// </summary>
        /// <param name="action"></param>
        private void ForEachBehavior(Action<Behavior> action)
        {
            var behaviorsToUpdate = _behaviors.ToArray();
            foreach (var behavior in behaviorsToUpdate)
                action(behavior);
        }
    }
}
