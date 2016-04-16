using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coldsteel
{
    public class Camera : GameObjectComponent
    {
        /// <summary>
        /// Get or set whether or not this camera should be actively affecting the stage.
        /// </summary>
        public bool IsActive { get; set; } = true;

        /// <summary>
        /// The transformation matrix that affects the rendering of a layer.
        /// </summary>
        internal Matrix GetTransformationMatrix(Viewport viewport)
        {
            var translation = Matrix.CreateTranslation(new Vector3(-(this.Transform?.Position.X ?? 0), -(this.Transform?.Position.Y ?? 0), 0f));
            var rotation = Matrix.CreateRotationZ(this.Transform?.Rotation ?? 0);
            var scale = Matrix.CreateScale(this.Transform?.Scale ?? 1f);            
            return Matrix.Identity * 
                translation * 
                rotation *
                scale;
        }

        private List<Layer> _skippedLayers = new List<Layer>();

        public Camera SkipLayer(Layer layer)
        {
            _skippedLayers.Add(layer);
            return this;
        }

        public bool SkipsLayer(Layer layer)
        {
            return _skippedLayers.Contains(layer);
        }
    }
}
