// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using Microsoft.Xna.Framework.Audio;

namespace Coldsteel.Audio
{
    public class AudioSource : Component
    {
        private string _soundEffectAssetName;

        /// <summary>
        /// The SoundEffect this AudioSource plays.
        /// </summary>
        private SoundEffect SoundEffect { get; set; }

        public AudioSource() { }

        public AudioSource(string soundEffectAssetName)
        {
            _soundEffectAssetName = soundEffectAssetName;
        }

        public void Play() => SoundEffect.Play();

        public void Play(float volume, float pitch, float pan) => SoundEffect.Play(volume, pitch, pan);

        internal override void Activate(Context context) =>
            SoundEffect = context.Content.Load<SoundEffect>(_soundEffectAssetName);
    }
}
