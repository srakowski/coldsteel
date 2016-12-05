using Coldsteel.Configuration.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coldsteel.Configuration.Components
{
    public class TextRenderer : Renderer
    {
        public Import SpriteFont { get; set; }

        public string Text { get; set; }
    }
}
