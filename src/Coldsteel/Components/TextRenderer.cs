using System;
using System.Collections.Generic;
using System.Text;

namespace Coldsteel.Components
{
    public class TextRenderer : Renderer
    {
        private string _fontAssetName;

        private string _text;

        public TextRenderer(string fontAssetName, string text) 
        {
            this._fontAssetName = fontAssetName;
            this._text = text;
        }
    }
}
