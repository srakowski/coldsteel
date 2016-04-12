using Microsoft.Xna.Framework;
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
        internal Matrix TransformMatrix
        {
            get
            {
                var translate = Matrix.CreateTranslation(new Vector3(this.Transform?.Position ?? Vector2.Zero, 0));
                var rotation = Matrix.CreateRotationZ(this.Transform?.Rotation ?? 0);                
                return Matrix.Identity * translate * rotation;
            }
        }
    }
}
