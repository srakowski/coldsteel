using Coldsteel;
using Derpfender.Behaviors;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Derpfender.States
{
    class GameplayState : GameState
    {
        public override void Preload()
        {
            Load.Image("star");
            Load.Image("ship");
            Load.Image("flash");
            Load.Image("bullet");
            Load.Image("smoke");
            Load.Image("enemy");
            Load.Image("debris");
            Load.SoundEffect("fire");
            Load.SoundEffect("explode");
        }

        public override void Create()
        {
            Stage.BackgroundColor = Color.Black;

            CreateStarField();
            Layers.Add("debris", -1).SetBlendState(BlendState.NonPremultiplied);

            World.AddGameObject("ship")
                .Set.Position(60, 360)
                .Set.RotationDegrees(90)
                .Add.SpriteRenderer("ship")
                .Add.AudioSource("fire")
                .Add.Component(new ShipBehavior());

            var shakeBehavior = new ShakeBehavior();
            Camera.Add.Component(shakeBehavior);

            World.AddGameObject()
                .Add.Component(new SpawnEnemyBehavior(shakeBehavior));
        }

        private void CreateStarField()
        {
            Layers.Add("starfield", -2)
                .SetBlendState(BlendState.NonPremultiplied)
                .SetSamplerState(SamplerState.PointClamp);

            var rand = new Random();
            foreach (var color in StarColors(rand))
                World.AddGameObject()
                    .Set.Position(rand.Next(0, 1280), rand.Next(0, 720))
                    .Set.Layer("starfield")
                    .Add.SpriteRenderer("star", color)
                    .Add.Component(new StarMoveBehavior(color.A));
        }

        private IEnumerable<Color> StarColors(Random rand)
        {
            for (var i = 0; i < 200; i++)
            {
                var r = rand.Next(56, 256);
                var g = rand.Next(56, 256);
                var b = rand.Next(56, 256);
                var a = rand.Next(56, 256);
                yield return new Color(r, g, b, a);
            }
        }
    }
}
