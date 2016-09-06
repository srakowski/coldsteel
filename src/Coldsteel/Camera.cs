using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;

namespace Coldsteel
{
    public class Camera : GameObject
    {
        internal Matrix TransformationMatrix
        {
            get
            {
                var screenCenter = Matrix.CreateTranslation(new Vector3((Stage?.Width * 0.5f ?? 0), (Stage?.Height * 0.5f ?? 0), 0f));
                var translation = Matrix.CreateTranslation(new Vector3(-(Transform?.Position.X ?? 0), -(Transform?.Position.Y ?? 0), 0f));
                var rotation = Matrix.CreateRotationZ(Transform?.Rotation ?? 0);
                return Matrix.Identity *
                    screenCenter *
                    translation *
                    rotation;
            }
        }

        public Camera(World world) 
            : base(world)
        {
        }

        internal override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        /// <summary>
        /// Camera may not be destroyed.
        /// </summary>
        public new void Kill() { }
    }
}
