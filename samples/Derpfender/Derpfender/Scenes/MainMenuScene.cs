using Coldsteel;
using Coldsteel.Components;
using Coldsteel.Controls;
using Derpfender.Behaviors;
using Derpfender.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Derpfender.Scenes
{
    class MainMenuScene : Scene
    {
        public override void Configure()
        {
            Content.Load<SpriteFont>("fonts/menu");
            Content.Load<Texture2D>("sprites/ship");

            Controls.Add("MenuUp", new KeyboardButtonControl(Keys.Up));
            Controls.Add("MenuDown", new KeyboardButtonControl(Keys.Down));
            Controls.Add("MenuSelect", new KeyboardButtonControl(Keys.Enter));

            CreateStarField();

            var mainMenu = new GameObject("mainMenu");
            mainMenu.Transform.Position = new Vector2(200, 200);
            mainMenu.Add(new TextRenderer("fonts/menu", "Derpfender"));
            GameObjects.Add(mainMenu);

            var playOption = new GameObject("play");
            playOption.Transform.Position = new Vector2(40, 40);
            playOption.Add(new TextRenderer("fonts/menu", "Play"));
            playOption.Transform.SetParent(mainMenu.Transform);
            GameObjects.Add(playOption);

            var exitOption = new GameObject("exit");
            exitOption.Transform.Position = new Vector2(40, 80);
            exitOption.Add(new TextRenderer("fonts/menu", "Exit"));
            exitOption.Transform.SetParent(mainMenu.Transform);
            GameObjects.Add(exitOption);

            var selectorShip = new GameObject("ship");
            selectorShip.Transform.Position = new Vector2(15, 53);
            selectorShip.Transform.Rotation = MathHelper.ToRadians(90);
            selectorShip.Add(new SpriteRenderer("sprites/ship"));
            selectorShip.Add(
                new MenuSelectBehavior(
                    new MenuOption(new Vector2(15, 53), Play), 
                    new MenuOption(new Vector2(15, 93), Exit)));
            selectorShip.Transform.SetParent(mainMenu.Transform);
            GameObjects.Add(selectorShip);
        }

        private void CreateStarField()
        {
            Content.Load<Texture2D>("sprites/star");

            Layers.Add(new Layer("starfield", -1)
            {
                BlendState = BlendState.NonPremultiplied,
                SamplerState = SamplerState.PointClamp
            });

            var starField = new GameObject("starfield");

            var rand = new Random();
            foreach (var color in StarColors(rand))
            {
                var star = new GameObject("star");
                star.Transform.Position = new Vector2(rand.Next(0, 1280), rand.Next(0, 720));
                star.Add(new SpriteRenderer("sprites/star")
                {
                    Layer = "starfield",
                    Color = color
                });
                star.Add(new StarMoveBehavior(color.A));
                star.Transform.SetParent(starField.Transform);
                GameObjects.Add(star);
            }

            GameObjects.Add(starField);
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

        public void Play() =>
            SceneManager.Start<GameplayScene>();

        public void Exit()
        {
            // TODO: exit
        }
    }
}
