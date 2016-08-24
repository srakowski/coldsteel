using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Audio;

namespace Coldsteel.Audio
{
    public class AudioSource : GameObjectComponent
    {
        //private AudioEmitter _emitter;

        private SoundEffect _soundEffect;

        //private SoundEffectInstance _soundEffectInstance;

        public AudioSource(SoundEffect soundEffect)
        {
            //this._emitter = new AudioEmitter();
            this._soundEffect = soundEffect;
        }

        public override void Initialize()
        {
            //_soundEffectInstance = _soundEffect.CreateInstance();
        }

        public void Play()
        {
            // TODO: figure out why positional audio only plays in a single speaker
            // TODO: cleanup this class
            //_emitter.Position = new Microsoft.Xna.Framework.Vector3(this.Transform.Position.X, _emitter.Position.Y, _emitter.Position.Z);
            //_soundEffectInstance.Apply3D(Camera.AudioListener, _emitter);
            //_soundEffectInstance.Play();
            //_soundEffect.Play(0.25f, 0.0f, 1.0f);
            //_soundEffect.Play(0.25f, 0.0f, -1.0f);
            _soundEffect.Play(0.01f, 0f, 0f);
        }
    }
}
