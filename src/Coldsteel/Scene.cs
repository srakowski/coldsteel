// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Coldsteel
{
    /// <summary>
    /// Is a playable game state composed of a set of Entities.
    /// </summary>
    public class Scene
    {
        private Context _context;

        private List<SceneElement> _sceneElements;

        private bool _activated = false;

        /// <summary>
        /// Fires when an element is added to a scene post-activation.
        /// </summary>
        public event EventHandler<SceneElementEventArgs> SceneElementAdded;

        /// <summary>
        /// Fires when an element is removed from a scene post-activation.
        /// </summary>
        public event EventHandler<SceneElementEventArgs> SceneElementRemoved;

        /// <summary>
        /// When the graphics device is at the start of scene rendering, this determines
        /// the background color of the scene.
        /// </summary>
        public Color BackgroundColor { get; set; } = Color.CornflowerBlue;

        /// <summary>
        /// Gets an enumerable of all SceneElements in this scene.
        /// </summary>
        public IEnumerable<SceneElement> Elements => _sceneElements;

        /// <summary>
        /// The Entities present in this Scene.
        /// </summary>
        //public IEnumerable<Entity> GameObjects => _sceneElements.OfType<Entity>();

        /// <summary>
        /// Constructs an empty scene.
        /// </summary>
        public Scene() : this(Enumerable.Empty<SceneElement>()) { }

        /// <summary>
        /// Constructs a scene with the provided elemnts.
        /// </summary>
        public Scene(IEnumerable<SceneElement> elements)
        {
            _sceneElements = new List<SceneElement>(elements);
            _activated = false;
        }

        /// <summary>
        /// Adds a SceneElement to this Scene.
        /// </summary>
        /// <param name="sceneElement"></param>
        public Scene AddElement(SceneElement sceneElement)
        {
            _sceneElements.Add(sceneElement);
            if (_activated)
            {
                sceneElement.Activate(_context);
                SceneElementAdded?.Invoke(this, new SceneElementEventArgs()
                {
                    SceneElement = sceneElement
                });
            }
            return this;
        }

        /// <summary>
        /// Update the scene, remove any destroyed objects.
        /// </summary>
        /// <param name="gameTime"></param>
        internal void Update(GameTime gameTime)
        {
            var sceneElements = _sceneElements.Where(se => se.IsDestroyed).ToArray();
            foreach (var sceneElement in sceneElements)
            {
                _sceneElements.Remove(sceneElement);
                SceneElementRemoved?.Invoke(this, new SceneElementEventArgs()
                {
                    SceneElement = sceneElement
                });
            }
        }

        /// <summary>
        /// Before this is called the Entities are composed but in an inactive
        /// state. This call readies the Entities for gameplay. This must be
        /// called before the scene becomes the active scene.
        /// </summary>
        internal void Activate(Context context)
        {
            _context = context;
            _activated = true;
            var sceneElementsToActivate = _sceneElements.ToList();
            sceneElementsToActivate.ForEach(go => go.Activate(context));
        }

        /// <summary>
        /// Does any cleanup tasks required after this Scene is close.
        /// </summary>
        /// <param name="contentManager"></param>
        internal void Deactivate()
        {
            _context.Unload();
            _sceneElements.Clear();
        }
    }
}
