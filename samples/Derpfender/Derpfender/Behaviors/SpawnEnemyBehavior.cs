using Coldsteel;
using Coldsteel.Colliders;
using Coldsteel.Renderers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Derpfender.Behaviors
{
    class SpawnEnemyBehavior : Behavior
    {
        private bool _allowSpawn = true;

        private Random _rand = new Random();

        private GameObject _camera;

        public SpawnEnemyBehavior(GameObject camera)
        {
            this._camera = camera;
        }

        public override void Update(IGameTime gameTime)
        {
            base.Update(gameTime);
            if (_allowSpawn)
                StartCoroutine(Spawn());
        }

        private IEnumerator Spawn()
        {
            _allowSpawn = false;
            AddGameObject(new GameObject("enemy")
                .SetPosition(new Vector2(1300, _rand.Next(20, 700)))
                .SetRotation((float)MathHelper.ToRadians(270))
                .AddComponent(new SpriteRenderer(DefaultLayer, GetContent<Texture2D>("enemy")))
                .AddComponent(new EnemyShipBehavior(_camera, new Vector2(-1, 0), _rand.Next(100, 200) / 1000f))
                .AddComponent(new BoxCollider(24, 24))
                .AddComponent(new AudioSource(GetContent<SoundEffect>("explode"))));
            yield return WaitMSecs(200);
            _allowSpawn = true;
        }
    }
}
