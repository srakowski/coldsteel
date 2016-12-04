using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coldsteel.Configuration.Components
{
    public abstract class Renderer : Component
    {
        [ContentSerializer(Optional = true)]
        public string Layer { get; set; }
    }
}
