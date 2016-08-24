using Coldsteel;
using Microsoft.Xna.Framework;
using System;
using System.Collections;

namespace Derpfender.Behaviors
{
    class ShakeBehavior : Behavior
    {
        private bool _isShaking = false;

        private Random _rand = new Random();

        public void Shake()
        {
            if (_isShaking)
                return;

            _isShaking = true;
            StartCoroutine(DoShake());
        }

        private IEnumerator DoShake()
        {
            var originalPosition = Transform.Position;
            for (int i = 60; i > 0; i -= 6)
            {
                Transform.Position = originalPosition + new Vector2((float)_rand.Next(-i, i) / 10f, (float)_rand.Next(-i, i) / 10f);
                yield return WaitMSecs(10);
            }
            Transform.Position = originalPosition;
            _isShaking = false;
        }
    }
}
