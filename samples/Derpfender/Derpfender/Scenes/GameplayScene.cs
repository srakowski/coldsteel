using Microsoft.Xna.Framework;
using Coldsteel;
using Microsoft.Xna.Framework.Graphics;
using Coldsteel.Fluent;
using Derpfender.Behaviors;
using Coldsteel.Rendering;
using Coldsteel.Audio;
using Coldsteel.Physics;

namespace Derpfender.Scenes
{
    public class GameplayScene : SpaceSceneBase
    {
        public override Color BackgroundColor { get; } = Color.Black;

        public Layer Debris { get; } = new Layer("debris", -1)
            .SetBlendState(BlendState.NonPremultiplied);

        public GameObject Ship { get; } = new GameObject()
            .SetName("ship") // TODO: constructor should accept name
            .SetPosition(60, 360)
            .SetRotationInDegrees(90)
            .AddComponent(new Body() { AngularDrag = 50, MaxAngularVelocity = 500 })
            .AddComponent(new SpriteRenderer("sprites/ship"))
            .AddComponent(new AudioSource("audio/fire"))
            .AddComponent(new ShipBehavior());
    }
}
