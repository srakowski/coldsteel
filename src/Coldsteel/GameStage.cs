using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Coldsteel.Algorithms;
using Microsoft.Xna.Framework;

namespace Coldsteel
{
    /// <summary>
    /// Represents a scene/level/screen in the game.
    /// </summary>
    public abstract class GameStage
    {
        /// <summary>
        /// Gets the GameStageManager that created this GameStage.
        /// </summary>
        public GameStageManager GameStageManager { get; internal set; }

        private List<GameObject> _gameObjects = new List<GameObject>();

        /// <summary>
        /// Gets the GameObjects contained in this stage.
        /// </summary>
        public IEnumerable<GameObject> GameObjects { get { return _gameObjects; } }        
               
        /// <summary>
        /// Adds a GameObject to the Stage
        /// </summary>
        /// <param name="gameObject"></param>
        public void AddGameObject(GameObject gameObject)
        {
            _gameObjects.Add(gameObject);
            gameObject.GameStage = this;
        }

        /// <summary>
        /// Removes a GameObject from the Stage.
        /// </summary>
        /// <param name="gameObject"></param>
        public void RemoveGameObject(GameObject gameObject)
        {
            _gameObjects.Remove(gameObject);
        }

        private Dictionary<string, object> _content = new Dictionary<string, object>();

        /// <summary>
        /// Gets or sets the ResourceFactory used for ContentManagement, Rendering, and other services.
        /// </summary>
        public IGameResourceFactory GameResourceFactory { get; set; }

        private IContentManager _contenManager;

        /// <summary>
        /// Gets the ContentManager used to load and store content.
        /// </summary>
        private IContentManager ContentManager
        {
            get
            {
                if (_contenManager == null)
                {
                    if (GameResourceFactory == null)
                        throw new InvalidOperationException("GameResourceFactory must be assigned before content is managed");

                    _contenManager = GameResourceFactory.CreateContentManager();
                }

                return _contenManager;
            }
        }

        /// <summary>
        /// Loads and stores content uses for this stage.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path"></param>
        /// <returns></returns>
        public T LoadContent<T>(string path) where T : class
        {
            _content[path] = ContentManager.Load<T>(path);
            return _content[path] as T;
        }

        /// <summary>
        /// Retrieves an already stored peices of content that was loaded with LoadContent<T>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path"></param>
        /// <returns></returns>
        public T GetContent<T>(string path) where T : class
        {
            if (!_content.ContainsKey(path))
                throw new ArgumentException(String.Format("content with path {0} has not been loaded", path));

            return _content[path] as T;
        }

        /// <summary>
        /// Called when Content should be loaded. This is called before Initialize.
        /// </summary>
        /// <param name="contentManager"></param>
        public virtual void LoadContent() { }

        private SortedList<int, Layer> _layers = new SortedList<int, Layer>();

        private Layer _defaultLayer;

        /// <summary>
        /// The Default rendering layer for this Stage.
        /// </summary>
        public Layer DefaultLayer
        {
            get
            {
                if (_defaultLayer == null)
                    _defaultLayer = AddLayer("default", 0);

                return _defaultLayer;
            }
        }

        /// <summary>
        /// Adds a layer with given name. DefaultLayer is 0, to go under go negative, to go above add positive.
        /// Layers are rendered in order of this zOrder.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="zOrder"></param>
        /// <returns></returns>
        public Layer AddLayer(string name, int zOrder)
        {
            if (GameResourceFactory == null)
                throw new InvalidOperationException("GameResourceFactory must be assigned before a DefaultLayer can be accessed");

            var layer = new Layer(GameResourceFactory.CreateSpriteBatch());
            _layers.Add(zOrder, layer);

            return layer;
        }

        /// <summary>
        /// Set the initial state of the GameStage. Create and initialize GameObjects.
        /// </summary>
        public virtual void Initialize() { }

        /// <summary>
        /// Gets or sets the object that will perform collision detections.
        /// </summary>
        private ICollisionDetector CollisionDetector { get; set; } = new NaiveCollisionDetector();

        /// <summary>
        /// Do physics updates and collision detection.
        /// </summary>
        /// <param name="gameTime"></param>
        internal void UpdatePhysics(IGameTime gameTime)
        {
            var colliders = new List<Collider>();
            DoToAllGameObjects((go) => colliders.AddRange(go.GetComponents<Collider>()));
            CollisionDetector.DetectCollisions(colliders, OnCollision);
        }

        /// <summary>
        /// Action taken during collision.
        /// </summary>
        /// <param name="collider1"></param>
        /// <param name="collider2"></param>
        private void OnCollision(Collider collider1, Collider collider2)
        {
            collider1.NotifyCollision(collider2);
            collider2.NotifyCollision(collider1);
        }

        /// <summary>
        /// HandleInput on GameObjects.
        /// </summary>
        /// <param name="gameTime"></param>
        /// <param name="_input"></param>
        internal void HandleInput(IGameTime gameTime, Input _input)
        {
            DoToAllGameObjects((go) => go.HandleInput(gameTime, _input));
        }

        /// <summary>
        /// Update GmeObjects.
        /// </summary>
        /// <param name="gameTime"></param>
        internal void Update(IGameTime gameTime)
        {
            DoToAllGameObjects((go) => go.Update(gameTime));
        }

        /// <summary>
        /// Render GameObjects.
        /// </summary>
        /// <param name="gameTime"></param>
        internal void Render(IGameTime gameTime)
        {            
            BeginLayerRender();
            DoToAllGameObjects((go) => go.Render(gameTime));
            EndLayerRender();
        }

        /// <summary>
        /// Begins the rendering process on all layers.
        /// </summary>
        private void BeginLayerRender()
        {
            Matrix transform = Matrix.Identity;
            DoToAllGameObjects((go) => {
                foreach (var camera in go.GetComponents<Camera>())
                    if (camera.IsActive)
                        transform *= camera.TransformMatrix;                
                });

            foreach (var layer in _layers)
                layer.Value.Begin(transform);
        }       

        /// <summary>
        /// Ends the rendering process on all layers (in order of when they should be drawn).
        /// </summary>
        private void EndLayerRender()
        {
            foreach (var layer in _layers)
                layer.Value.End();
        }

        /// <summary>
        /// Passes every GameObject to the provided action recursively.
        /// </summary>
        /// <param name="action"></param>
        private void DoToAllGameObjects(Action<GameObject> action)
        {
            DoToGamObjects(this.GameObjects.ToArray(), action);
        }

        /// <summary>
        /// The Recursive portion of DoToAllGameObjects.
        /// </summary>
        /// <param name="gameObjects"></param>
        /// <param name="action"></param>
        private static void DoToGamObjects(IEnumerable<GameObject> gameObjects, Action<GameObject> action)
        {
            foreach (var gameObject in gameObjects)
            {
                action.Invoke(gameObject);
                DoToGamObjects(gameObject.Children.ToArray(), action);
            }
        }
    }
}
