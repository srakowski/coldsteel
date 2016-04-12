using Coldsteel;
using Coldsteel.Renderers;
using Derpfender.Behaviors;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Derpfender.Stages
{
    class GameplayStage : GameStage
    {
        public override void LoadContent()
        {            
            LoadContent<Texture2D>("star");
            LoadContent<SoundEffect>("fire");
            LoadContent<Texture2D>("ship");
            LoadContent<Texture2D>("flash");
            LoadContent<Texture2D>("bullet");
            LoadContent<Texture2D>("enemy");
            LoadContent<Texture2D>("debris");
            LoadContent<SoundEffect>("explode");
        }

        public override void Initialize()
        {            
            var background = AddLayer("background", -1);
            background.BlendState = BlendState.NonPremultiplied;
            background.SamplerState = SamplerState.PointClamp;            

            var rand = new Random();
            for (var i = 0; i < 200; i++)
            {
                var r = rand.Next(56, 256);
                var g = rand.Next(56, 256);
                var b = rand.Next(56, 256);
                var alpha = rand.Next(56, 256);
                AddGameObject(new GameObject()
                    .SetPosition(new Vector2(rand.Next(0, 1280), rand.Next(0, 720)))
                    .AddComponent(new SpriteRenderer(background, GetContent<Texture2D>("star")) { Color=new Color(r, g, b, alpha) })
                    .AddComponent(new StarMoveBehavior(alpha)));
            }            

            var ship = new GameObject()
                .SetPosition(new Vector2(60, 360))
                .SetRotation((float)Math.PI / 2f)
                .AddComponent(new SpriteRenderer(DefaultLayer, GetContent<Texture2D>("ship")))
                .AddComponent(new ShipBehavior())
                .AddComponent(new AudioSource(GetContent<SoundEffect>("fire")));

            AddGameObject(ship);

            var camera = new GameObject()
                .AddComponent(new Camera())
                .AddComponent(new ShakeBehavior());
            AddGameObject(camera);

            var enemyShipSpawner = new GameObject()
                .AddComponent(new SpawnEnemyBehavior(camera));
            
            AddGameObject(enemyShipSpawner);
        }
    }
}
