using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Coldsteel.Rendering
{
    public class SpriteSheet
    {
        public Texture2D Image { get; private set; }

        private int _frameWidth;
        private int _imageWidth;
        private int _frameHeight;
        private int _imageHeight;
        private int _cols;
        private int _rows;
        private Rectangle[] _frames;

        internal Vector2 Origin => new Vector2(_frameWidth * 0.5f, _frameHeight * 0.5f);

        public SpriteSheet(Texture2D image, int frameWidth, int frameHeight)
        {
            this.Image = image;
            this._frameWidth = frameWidth;
            this._imageWidth = image.Width;
            this._cols = _imageWidth / _frameWidth;
            this._frameHeight = frameHeight;
            this._imageHeight = image.Height;
            this._rows = _imageHeight / _frameHeight;
            this._frames = new Rectangle[_rows * _cols];
            var x = 0;
            var y = 0;
            for (var i = 0; i < _frames.Length; i++)
            {
                this._frames[i] = new Rectangle(x, y, _frameWidth, _frameHeight);
                x += _frameWidth;
                if (x >= _imageWidth)
                {
                    x = 0;
                    y += _frameHeight;
                }
            }
        }

        public Rectangle this[int frameIndex]
        {
            get
            {
                return _frames[frameIndex];
            }
        }
    }
}
