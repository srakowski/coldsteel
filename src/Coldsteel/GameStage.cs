using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Coldsteel.Algorithms;
using Microsoft.Xna.Framework;
using Coldsteel.Transitions;
using Microsoft.Xna.Framework.Graphics;

namespace Coldsteel
{
    internal enum GameStageState
    {
        TransitionOn,
        Active,
        TransitionOff,
        Hidden
    }

    /// <summary>
    /// Represents a scene/level/screen in the game.
    /// </summary>
    public abstract class GameStage
    {
        public bool SkipFade { get; set; } = true;

        public static Color DefaultBackgroundColor { get; set; } = Color.CornflowerBlue;

        private List<GameObject> _gameObjects = new List<GameObject>();

        private Dictionary<string, object> _content = new Dictionary<string, object>();

        private IGraphicsService _graphicsService = null;

        private IContentManager _contenManager = null;

        private SortedList<int, Layer> _layers = new SortedList<int, Layer>();

        private Layer _defaultLayer = null;

        private GameStageState _state = GameStageState.Hidden;

        /// <summary>
        /// Gets the GameStageManager that created this GameStage.
        /// </summary>
        public GameStageManager GameStageManager { get; internal set; }

        /// <summary>
        /// Gets the GameObjects contained in this stage.
        /// </summary>
        public IEnumerable<GameObject> GameObjects { get { return _gameObjects; } }

        /// <summary>
        /// Gets or sets the background color of the Stage.
        /// </summary>
        public Color BackgroundColor { get; set; } = DefaultBackgroundColor;

        /// <summary>
        /// Gets or sets the ResourceFactory used for ContentManagement, Rendering, and other services.
        /// </summary>
        internal IGameResourceFactory GameResourceFactory { get; set; }

        /// <summary>
        /// Gets or sets the Input object.
        /// </summary>
        public Input Input { get; internal set; }

        private SpriteBatch _sb;

        private SpriteBatch SpriteBatch
        {
            get
            {
                if (_sb == null)
                    _sb = GameResourceFactory.CreateSpriteBatch();

                return _sb;
            }
        }

        private int alpha = 255;

        private Texture2D fader = null;

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
        /// Gets or sets the object that will perform collision detections.
        /// </summary>
        private ICollisionDetector CollisionDetector { get; set; } = new NaiveCollisionDetector();        

        protected Transition InTransition { get; set; }

        protected Transition OutTransition { get; set; }

        protected object Param { get; private set; }

        public GameStage()
        {
        }

        /// <summary>
        /// Performs initial load.
        /// </summary>
        internal void Load(object param)
        {
            this.Param = param;
            this.LoadContent();
            this.Initialize();
            this._state = GameStageState.TransitionOn;
            this.fader = new Texture2D(SpriteBatch.GraphicsDevice, 1, 1);
            Color[] texData = new Color[1];
            texData[0] = Color.Black;
            this.fader.SetData<Color>(texData);
            //this.InTransition = this.InTransition ?? ImmediateTransition.In();
            //this.InTransition.Start(() =>
            //{
            //    this._state = GameStageState.Active;
            //});
        }

        private Action _then;

        /// <summary>
        /// Exits and unloads
        /// </summary>
        internal void Exit(Action then)
        {
            _then = then;
            this._state = GameStageState.TransitionOff;
            //this.OutTransition = this.OutTransition ?? ImmediateTransition.Out();
            //this.OutTransition.Start(() => 
            //{
            //    this._state = GameStageState.Hidden;
            //    this.UnloadContent();
            //});
        }

        /// <summary>
        /// Set the initial state of the GameStage. Create and initialize GameObjects.
        /// </summary>
        protected virtual void Initialize() { }

        /// <summary>
        /// Called when Content should be loaded. This is called before Initialize.
        /// </summary>
        /// <param name="contentManager"></param>
        protected virtual void LoadContent() { }

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
        /// Load
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path"></param>
        /// <param name="paths"></param>
        /// <returns></returns>
        public T[] LoadContent<T>(string path, params string[] paths) where T : class
        {
            List<T> content = new List<T>();
            content.Add(LoadContent<T>(path));
            foreach (var p in paths)
                content.Add(LoadContent<T>(p));
            return content.ToArray();
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
        /// Unloads content loaded by this Stage.
        /// </summary>
        private void UnloadContent()
        {
            _contenManager.Unload();
        }

        /// <summary>
        /// Adds a GameObject to the Stage
        /// </summary>
        /// <param name="gameObject"></param>
        public GameObject AddGameObject(GameObject gameObject = null)
        {
            if (gameObject == null)
                gameObject = new GameObject();
            _gameObjects.Add(gameObject);
            gameObject.GameStage = this;
            return gameObject;
        }

        /// <summary>
        /// Removes a GameObject from the Stage.
        /// </summary>
        /// <param name="gameObject"></param>
        public void RemoveGameObject(GameObject gameObject)
        {
            _gameObjects.Remove(gameObject);
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

            var layer = new Layer(name, GameResourceFactory.CreateSpriteBatch());
            _layers.Add(zOrder, layer);

            return layer;
        }

        /// <summary>
        /// Retrieves a layer by its name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Layer GetLayer(string name)
        {
            var result = _layers.Where(l => l.Value.Name == name);
            if (!result.Any())
                throw new ArgumentException(String.Format("no layer exists with the name \"{0}\"", name));
            return result.First().Value;
        }

        private List<GameObject> _activeGameObjects = new List<GameObject>();

        private List<Collider> _colliders = new List<Collider>();

        /// <summary>
        /// Do physics updates and collision detection.
        /// </summary>
        /// <param name="gameTime"></param>
        private void UpdatePhysics(IGameTime gameTime)
        {
            CollisionDetector.DetectCollisions(_colliders, OnCollision);            
        }

        /// <summary>
        /// Action taken during collision.
        /// </summary>
        /// <param name="collider1"></param>
        /// <param name="collider2"></param>
        private void OnCollision(Collider collider1, Collider collider2)
        {
            if (!collider1.NotifyCollision(collider2))
                collider2.NotifyCollision(collider1);
        }

        bool _first = true;

        /// <summary>
        /// Update GmeObjects.
        /// </summary>
        /// <param name="gameTime"></param>
        internal void Update(IGameTime gameTime)
        {
            if (_first)
            {
                _first = false;
                return;
            }

            PreUpdate();
            switch (_state)
            {
                case GameStageState.Active:
                    
                    DoToAllGameObjects(go => go.Update(gameTime));                    
                    UpdatePhysics(gameTime);
                    break;

                case GameStageState.TransitionOn:
                    if (alpha > 0 && !SkipFade)
                    {
                        alpha -= 2;
                        alpha = MathHelper.Clamp(alpha, 0, 255);
                    }
                    else
                    {
                        _state = GameStageState.Active;
                    }

                    //this.InTransition.Update(gameTime);
                    break;

                case GameStageState.TransitionOff:
                    if (alpha < 255 && !SkipFade)
                    {
                        alpha += 2;
                        alpha = MathHelper.Clamp(alpha, 0, 255);
                    }
                    else
                    {
                        _then.Invoke();
                        _state = GameStageState.Hidden;
                    }
                    //this.OutTransition.Update(gameTime);
                    break;
            }            
        }

        /// <summary>
        /// Updates the objects that should be rendered this frame.
        /// </summary>
        private void PreUpdate()
        {
            CollectCameras();
            foreach (var layer in _layers)
            {
                layer.Value.TransformMatrix = GetTransformForLayer(layer.Value);
                var tl = ScreenPosToLayerPos(Vector2.Zero, layer.Value);
                layer.Value.Bounds = new Rectangle((int)tl.X - 100, (int)tl.Y - 100, _graphicsService.DefaultViewport.Width + 200, _graphicsService.DefaultViewport.Height + 200);
            }
            var defaultBounds = new Rectangle(-100, -100, _graphicsService.DefaultViewport.Width + 200, _graphicsService.DefaultViewport.Height + 200);

            _colliders.Clear();     
            _activeGameObjects.Clear();
            DoToAllGameObjects((go) =>
            {
                var bounds = go.GetComponent<Renderer>()?.Layer.Bounds ?? defaultBounds;
                if (bounds.Contains(go.Transform.Position))
                {
                    _activeGameObjects.Add(go);
                    _colliders.AddRange(go.GetComponents<Collider>().Where(c => c.Enabled));
                }
            });
        }

        /// <summary>
        /// Render GameObjects.
        /// </summary>
        /// <param name="gameTime"></param>
        internal void Render(IGameTime gameTime)
        {            
            BeginLayerRender();
            _activeGameObjects.ForEach(go => go.Render(gameTime));
            EndLayerRender();

            if (!SkipFade)
            {
                SpriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied);
                SpriteBatch.Draw(this.fader, new Rectangle(0, 0, _graphicsService.DefaultViewport.Width, _graphicsService.DefaultViewport.Height), new Color(Color.Black, alpha));
                SpriteBatch.End();
            }
        }

        private List<Camera> _cameras = new List<Camera>();

        /// <summary>
        /// Begins the rendering process on all layers.
        /// </summary>
        private void BeginLayerRender()
        {
            if (_graphicsService == null)
                _graphicsService = GameResourceFactory?.CreateGraphicsService();

            _graphicsService.Clear(BackgroundColor);           
            foreach (var layer in _layers.Values)
                layer.Begin();
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
            DoToGameObjects(this.GameObjects.ToArray(), action);
        }

        /// <summary>
        /// The Recursive portion of DoToAllGameObjects.
        /// </summary>
        /// <param name="gameObjects"></param>
        /// <param name="action"></param>
        private static void DoToGameObjects(IEnumerable<GameObject> gameObjects, Action<GameObject> action)
        {
            foreach (var gameObject in gameObjects)
            {
                action.Invoke(gameObject);
                DoToGameObjects(gameObject.Children.ToArray(), action);
            }
        }

        /// <summary>
        /// Converts a screen position to a world position taking Cameras into account.
        /// </summary>
        /// <returns></returns>
        public Vector2 ScreenPosToLayerPos(Vector2 screenPos, Layer layer)
        {
            return Vector2.Transform(screenPos, Matrix.Invert(layer.TransformMatrix));
        }

        /// <summary>
        /// Gets all cameras.
        /// </summary>
        /// <returns></returns>
        private void CollectCameras()
        {
            _cameras.Clear();
            DoToAllGameObjects((go) =>
            {
                foreach (var camera in go.GetComponents<Camera>())
                    if (camera.IsActive)
                        _cameras.Add(camera);
            });
        }

        /// <summary>
        /// Given all the cameras calculate the transform for a layer.
        /// </summary>
        /// <param name="cameras"></param>
        /// <param name="layer"></param>
        /// <returns></returns>
        private Matrix GetTransformForLayer(Layer layer)
        {
            var transform = Matrix.Identity;
            foreach (var camera in _cameras)
                if (!camera.SkipsLayer(layer))
                {
                    var viewport = _graphicsService.DefaultViewport;
                    transform *= camera.GetTransformationMatrix(_graphicsService.DefaultViewport);
                    var viewportTranslation = Matrix.CreateTranslation(new Vector3(viewport.Width * 0.5f, viewport.Height * 0.5f, 0f));
                    transform *= viewportTranslation;
                }
            return transform;
        }
    }
}
