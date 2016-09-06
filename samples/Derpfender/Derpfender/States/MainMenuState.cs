using Coldsteel;
using Microsoft.Xna.Framework;
using Derpfender.Behaviors;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace Derpfender.States
{
    class MainMenuState : GameState
    {
        public override void Preload()
        {
            Load.Image("ship");
            Load.Image("star");
            Load.SpriteFont("menu");
        }

        public override void Create()
        {
            CreateStarField();
            Layers.Default.SetFixedToCamera(true);

            var mainMenu = World.AddGameObject()
                .Set.Position(200, 200)
                .Add.TextRenderer("menu", "Derpfender");

            mainMenu.AddGameObject()
                .Set.Position(40, 40)
                .Add.TextRenderer("menu", "Play");

            mainMenu.AddGameObject()
                .Set.Position(40, 80)
                .Add.TextRenderer("menu", "Exit");

            mainMenu.AddGameObject()
                .Set.Position(15, 53)
                .Set.RotationDegrees(90)
                .Add.SpriteRenderer("ship")
                .Add.Component(new MenuSelectorBehavior(Play, Exit));
        }

        private void CreateStarField()
        {
            Layers.Add("starfield", -1)
                .SetBlendState(BlendState.NonPremultiplied)
                .SetSamplerState(SamplerState.PointClamp)
                .SetFixedToCamera(true);

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

        private void Play()
        {
            State.Start<GameplayState>();
        }

        private void Exit()
        {
            State.Exit();
        }
    }
}
