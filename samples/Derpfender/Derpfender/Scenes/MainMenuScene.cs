using Coldsteel.Composition;
using Coldsteel;
using Coldsteel.Fluent;
using Coldsteel.Components;
using Derpfender.Behaviors;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections;
using System.Collections.Generic;
using System;

namespace Derpfender.Scenes
{
    public class MainMenuScene : ReflectiveSceneBuilder
    {
        private const string MenuFontAssetName = "fonts/menu";

        public override Color BackgroundColor => Color.Black;

        public Layer StarField { get; } = new Layer("starfield", -1)
            .SetBlendState(BlendState.NonPremultiplied)
            .SetSamplerState(SamplerState.PointClamp);

        public GameObject MainMenu { get; } = new GameObject()
            .SetName("mainMenu")
            .SetPosition(200, 200)
            .Add(new TextRenderer(MenuFontAssetName, "Derpfender"));

        public GameObject PlayOption { get; } = new GameObject()
            .SetPosition(40, 40)
            .Add(new TextRenderer(MenuFontAssetName, "Play"));

        public GameObject ExitOption { get; } = new GameObject()
            .SetPosition(40, 80)
            .Add(new TextRenderer(MenuFontAssetName, "Exit"));

        public GameObject ShipSelector { get; } = new GameObject()
            .SetRotationInDegrees(90)
            .Add(new SpriteRenderer("sprites/ship"))
            .Add(new MainMenuBehavior());

        public IEnumerable<GameObject> Stars { get; private set; } 

        protected override void Compose()
        {
            PlayOption.SetParent(MainMenu);
            ExitOption.SetParent(MainMenu);
            ShipSelector.SetParent(MainMenu);
            Stars = CreateStars();
        }

        private IEnumerable<GameObject> CreateStars()
        {
            var rand = new Random();
            foreach (var color in StarColors(rand))
            {
                yield return new GameObject()
                    .SetPosition(rand.Next(0, 1280), rand.Next(0, 720))
                    .Add(new SpriteRenderer("sprites/star")
                    {
                        Layer = StarField.Name,
                        Color = color
                    })
                    .Add(new StarBehavior(color.A));
            }
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
