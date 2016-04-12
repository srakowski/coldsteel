using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coldsteel
{
    public class Camera : GameObjectComponent
    {
        public bool IsActive { get; set; } = true;

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
