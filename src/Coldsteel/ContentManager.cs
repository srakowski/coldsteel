using Coldsteel.Rendering;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using MonogameContentManager = Microsoft.Xna.Framework.Content.ContentManager;

namespace Coldsteel
{
    public class ContentManager
    {
        private MonogameContentManager _content;

        internal ContentManager(MonogameContentManager content)
        {
            _content = content;
        }

        private Dictionary<string, Texture2D> _images = new Dictionary<string, Texture2D>();

        public IDictionary<string, Texture2D> Images => _images;

        public void Image(string name, string path = null)
        {
            _images.Add(name, _content.Load<Texture2D>(path ?? name));
        }

        private Dictionary<string, SpriteSheet> _spriteSheets = new Dictionary<string, SpriteSheet>();

        public IDictionary<string, SpriteSheet> SpriteSheets => _spriteSheets;

        public void SpriteSheet(string name, int frameWidth, int frameHeight, string path = null)
        {
            _spriteSheets.Add(name, new SpriteSheet(_content.Load<Texture2D>(path ?? name), frameWidth, frameHeight));
        }

        private Dictionary<string, SpriteFont> _spriteFonts = new Dictionary<string, SpriteFont>();

        public IDictionary<string, SpriteFont> SpriteFonts => _spriteFonts;

        public void SpriteFont(string name, string path = null)
        {
            _spriteFonts.Add(name, _content.Load<SpriteFont>(path ?? name));
        }

        private Dictionary<string, SoundEffect> _soundEffects = new Dictionary<string, SoundEffect>();

        public IDictionary<string, SoundEffect> SoundEffects => _soundEffects;

        public void SoundEffect(string name, string path = null)
        {
            _soundEffects.Add(name, _content.Load<SoundEffect>(path ?? name));
        }

        internal void Reset()
        {
            _images.Clear();
            _spriteFonts.Clear();
            _soundEffects.Clear();
            _content.Unload();
        }
    }
}
