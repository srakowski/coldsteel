using Coldsteel;
using Coldsteel.Composition;
using Coldsteel.Fluent;
using Coldsteel.Rendering;
using Derpfender.Behaviors;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Derpfender.Scenes
{
    public abstract class SpaceSceneBase : ReflectiveSceneBuilder
    {
        public Layer StarField { get; } = new Layer("starfield", -1)
            .SetBlendState(BlendState.NonPremultiplied)
            .SetSamplerState(SamplerState.PointClamp);

        public IEnumerable<GameObject> Stars { get; } = CreateStars();

        private static IEnumerable<GameObject> CreateStars()
        {
            var rand = new Random();
            foreach (var color in StarColors(rand))
            {
                yield return new GameObject()
                    .SetPosition(rand.Next(0, 1280), rand.Next(0, 720))
                    .AddComponent(new SpriteRenderer("sprites/star")
                    {
                        Layer = "starfield",
                        Color = color
                    })
                    .AddComponent(new StarBehavior(color.A));
            }
        }

        private static IEnumerable<Color> StarColors(Random rand)
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
