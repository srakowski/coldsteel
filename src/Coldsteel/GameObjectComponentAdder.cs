using System;
using System.Collections.Generic;
using System.Text;
using Coldsteel.Audio;
using Coldsteel.Rendering;
using Coldsteel.Physics;
using Microsoft.Xna.Framework;
using Coldsteel.Particles;

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

        public GameObject SpriteRenderer(string imageKey) => SpriteRenderer(imageKey, Color.White);

        public GameObject SpriteRenderer(string imageKey, Color color)
        {
            var image = Content.Images[imageKey];
            _gameObject.AddGameObjectComponent(new SpriteRenderer(image)
            {
                Color = color
            });
            return _gameObject;
        }

        public GameObject SpriteSheetRenderer(string spriteSheetKey) => SpriteSheetRenderer(spriteSheetKey, Color.White);

        public GameObject SpriteSheetRenderer(string spriteSheetKey, Color color)
        {
            var spriteSheet = Content.SpriteSheets[spriteSheetKey];
            _gameObject.AddGameObjectComponent(new SpriteSheetRenderer(spriteSheet)
            {
                Color = color
            });
            return _gameObject;
        }

        public GameObject AudioSource(string audioKey)
        {
            var soundEffect = Content.SoundEffects[audioKey];
            _gameObject.AddGameObjectComponent(new AudioSource(soundEffect));
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

        public GameObject RigidBody()
        {
            _gameObject.AddGameObjectComponent(new RigidBody());
            return _gameObject;
        }

        public GameObject ParticleEmitter(string imageKey)
        {
            var image = Content.Images[imageKey];
            _gameObject.AddGameObjectComponent(new ParticleEmitter(image));
            return _gameObject;
        }

        public GameObject Animation(string key, int frame)
        {
            if (_gameObject.Animations == null)
                _gameObject.AddGameObjectComponent(new AnimationManager());

            _gameObject.Animations.Add(key, frame);
            return _gameObject;
        }

        public GameObject Animation(string key, int[] frames, int rate)
        {
            if (_gameObject.Animations == null)
                _gameObject.AddGameObjectComponent(new AnimationManager());

            _gameObject.Animations.Add(key, frames, rate);
            return _gameObject;
        }
    }
}
