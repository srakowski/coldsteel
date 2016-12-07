// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Coldsteel
{
    /// <summary>
    /// Is a playable game state composed of a set of GameObjects.
    /// </summary>
    public class Scene
    {
        private List<GameObject> _gameObjects;

        private List<Layer> _layers;

        private ContentManager _contentManager;

        /// <summary>
        /// The GameObjects present in this Scene.
        /// </summary>
        public IEnumerable<GameObject> GameObjects => _gameObjects;

        /// <summary>
        /// All Scenes have at least 1 layer with this name set draw at order 0. To
        /// draw content behind this layer add a layer with an Order less than 0. To
        /// draw above this layer add a layer with an Order greater than 0.
        /// </summary>
        public static string DefaultLayerName { get; } = "default";

        /// <summary>
        /// Rendering Layers available to Renderer components in this Scene.
        /// </summary>
        public IEnumerable<Layer> Layers => _layers;

        /// <summary>
        /// Constructs an empty scene.
        /// </summary>
        public Scene() : this(Enumerable.Empty<GameObject>()) { }

        /// <summary>
        /// Constructs a scene with the provided GameObjects.
        /// </summary>
        /// <param name="gameObjects"></param>
        public Scene(IEnumerable<GameObject> gameObjects) : this(gameObjects, Enumerable.Empty<Layer>()) { }

        /// <summary>
        /// Constructs a scene initialized with the provided GameObjects and Layers.
        /// </summary>
        /// <param name="gameObjects"></param>
        /// <param name="layers"></param>
        public Scene(IEnumerable<GameObject> gameObjects, IEnumerable<Layer> layers)
        {
            _gameObjects = new List<GameObject>(gameObjects);
            _layers = new List<Layer>(layers);
            _layers.Add(new Layer(Scene.DefaultLayerName, 0));
        }

        /// <summary>
        /// Adds a Layer to this Scene.
        /// </summary>
        /// <param name="layer"></param>
        public void Add(Layer layer)
        {
            _layers.Add(layer);
        }

        /// <summary>
        /// Adds a GameObject to this Scene.
        /// </summary>
        /// <param name="gameObject"></param>
        public void Add(GameObject gameObject)
        {
            _gameObjects.Add(gameObject);
        }

        internal void Add(ISceneElement sceneElement)
        {
            if (sceneElement is GameObject)
                Add(sceneElement as GameObject);
            else if (sceneElement is Layer)
                Add(sceneElement as Layer);
            else
                throw new Exception($"unrecognized scene element type {sceneElement.GetType().Name}");
        }

        /// <summary>
        /// Before this is called the GameObjects are composed but in an inactive
        /// state. This call readies the GameObjects for gameplay. This must be
        /// called before the scene becomes the active scene.
        /// </summary>
        internal void Activate(ContentManager contentManager)
        {
            _contentManager = contentManager;
            _gameObjects.ForEach(go => go.Activate(contentManager));
        }

        /// <summary>
        /// Does any cleanup tasks required after this Scene is close.
        /// </summary>
        /// <param name="contentManager"></param>
        internal void Deactivate()
        {
            _contentManager.Unload();
        }
    }
}
