using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coldsteel
{
    /// <summary>
    /// Used during activation to give game objects everything it may need.
    /// </summary>
    internal class Context
    {
        public Scene Scene { get; }

        public ISceneManager SceneManager { get; }

        public IPhysicsManager PhysicsManager { get; }

        public IInputManager Input { get; }

        public ContentManager Content { get; }

        public GraphicsDevice GraphicsDevice { get; }

        public Context(Scene scene,
            SceneManager sceneManager, 
            IPhysicsManager physicsManager,
            IInputManager inputManager, 
            ContentManager contentManager,
            GraphicsDevice graphicsDevice)
        {
            Scene = scene;
            SceneManager = sceneManager;
            PhysicsManager = physicsManager;
            Input = inputManager;
            Content = contentManager;
            GraphicsDevice = graphicsDevice;
        }

        internal void Unload()
        {
            Content.Unload();
        }
    }
}
