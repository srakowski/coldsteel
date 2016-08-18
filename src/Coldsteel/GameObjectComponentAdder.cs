using System;
using System.Collections.Generic;
using System.Text;
using Coldsteel.Audio;
using Coldsteel.Rendering;
using Coldsteel.Physics;

namespace Coldsteel
{
    public class GameObjectComponentAdder
    {
        private GameObject _gameObject;

        private ContentManager Content => _gameObject.Content;

        public GameObjectComponentAdder(GameObject gameObject)
        {
            _gameObject = gameObject;
        }

        public GameObject TextRenderer(string spriteFontKey, string text)
        {
            var spriteFont = Content.SpriteFonts[spriteFontKey];
            _gameObject.AddGameObjectComponent(new TextRenderer(spriteFont, text));
            return _gameObject;
        }

        public GameObject SpriteRenderer(string imageKey)
        {
            var image = Content.Images[imageKey];
            _gameObject.AddGameObjectComponent(new SpriteRenderer(image));
            return _gameObject;
        }

        public GameObject AudioSource(string audioKey)
        {
            _gameObject.AddGameObjectComponent(new AudioSource());
            return _gameObject;
        }

        public GameObject Component(GameObjectComponent component)
        {
            _gameObject.AddGameObjectComponent(component);
            return _gameObject;
        }

        public GameObject BoxCollider(int width, int height)
        {
            _gameObject.AddGameObjectComponent(new BoxCollider(width, height));
            return _gameObject;
        }
    }
}
