using Coldsteel.Configuration.Common;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coldsteel.Configuration.Components
{
    public class SpriteRenderer : Renderer
    {
        public Import Texture2D { get; set; }

        [ContentSerializer(Optional = true)]
        public Color Color { get; set; }
    }
}
