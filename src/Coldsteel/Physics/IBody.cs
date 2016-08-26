using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace Coldsteel.Physics
{
    internal interface IBody
    {
        bool IsRigid { get; set; }
        Vector2 Position { get; set; }
        float Rotation { get; set; }
        bool Enabled { get; set; }
        Vector2 Velocity { get; set; }

        void Dispose();
        void CreateBoxCollider(int width, int height);
    }
}
