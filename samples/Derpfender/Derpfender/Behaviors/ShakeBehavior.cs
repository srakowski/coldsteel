using Coldsteel;
using Microsoft.Xna.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

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

            StartCoroutine(DoShake());
        }

        private IEnumerator DoShake()
        {
            _isShaking = true;
            var originalPosition = Transform.Position;
            for (int i = 100; i > 0; i-= 10)
            {
                Transform.Position = originalPosition + new Vector2((float)_rand.Next(-i, i) / 10f, (float)_rand.Next(-i, i) / 10f);
                yield return WaitMSecs(10);
            }
            Transform.Position = originalPosition;
            _isShaking = false;
        }
    }
}
