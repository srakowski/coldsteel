using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Content;

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

        private Layer _defaultLayer;

        /// <summary>
        /// The Default rendering layer for this Stage.
        /// </summary>
        public Layer DefaultLayer
        {
            get
            {
                if (_defaultLayer == null)
                {
                    if (GameResourceFactory == null)
                        throw new InvalidOperationException("GameResourceFactory must be assigned before a DefaultLayer can be accessed");

                    _defaultLayer = new Layer(GameResourceFactory.CreateSpriteBatch());
                }

                return _defaultLayer;
            }
        }

        /// <summary>
        /// Set the initial state of the GameStage. Create and initialize GameObjects.
        /// </summary>
        public virtual void Initialize() { }

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
            this.DefaultLayer.Begin();
        }

        /// <summary>
        /// Ends the rendering process on all layers (in order of when they should be drawn).
        /// </summary>
        private void EndLayerRender()
        {
            this.DefaultLayer.End();
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
