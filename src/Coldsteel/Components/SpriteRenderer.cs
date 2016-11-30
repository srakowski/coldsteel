using System;
using System.Collections.Generic;
using System.Text;

namespace Coldsteel.Components
{
    public class SpriteRenderer : Renderer
    {
        private string _textureAssetName;

        public SpriteRenderer(string textureAssetName)
        {
            this._textureAssetName = textureAssetName;
        }
    }
}
