using Coldsteel.Configuration.Common;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coldsteel.Configuration.Components
{
    public class Transform : Component
    {
        [ContentSerializer(Optional = true)]
        public Import Parent { get; set; }

        [ContentSerializer(Optional = true)]
        public Vector2 Position { get; set; } = Vector2.Zero;

        [ContentSerializer(Optional = true)]
        public float Rotation { get; set; } = 0f;

        [ContentSerializer(Optional = true)]
        public float Scale { get; set; } = 1f;
    }
}
