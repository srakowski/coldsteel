using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coldsteel
{
    public class AudioSource : GameObjectComponent
    {
        private SoundEffect _soundEffect;

        public AudioSource(SoundEffect soundEffect)
        {
            _soundEffect = soundEffect;
        }

        public void Play()
        {
            _soundEffect.Play();
        }

        public void Play(float volume, float pitch, float pan)
        {
            _soundEffect.Play(volume, pitch, pan);
        }
    }
}
