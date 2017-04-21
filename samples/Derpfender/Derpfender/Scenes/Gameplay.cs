using Microsoft.Xna.Framework;
using Coldsteel;
using Microsoft.Xna.Framework.Graphics;
using Derpfender.Behaviors;
using Coldsteel.Rendering;
using Coldsteel.Audio;
using Coldsteel.Physics;

namespace Derpfender.Scenes
{
    public class Gameplay : SpaceSceneBase
    {
        public static Scene Scene() => new Coldsteel.Scene();

        public Color BackgroundColor { get; } = Color.Black;

        public Layer Debris { get; } = new Layer("debris", -1)
            .SetBlendState(BlendState.NonPremultiplied);

        public Entity Ship { get; } = new Entity()
            .SetName("ship") // TODO: constructor should accept name
            .SetPosition(60, 360)
            .SetRotationInDegrees(90)
            .AddComponent(new Body() { AngularDrag = 50, MaxAngularVelocity = 500 })
            .AddComponent(new SpriteRenderer("sprites/ship"))
            .AddComponent(new AudioSource("audio/fire"))
            .AddComponent(new ShipBehavior());

        public Entity EnemySpawner { get; } = new Entity()
            .AddComponent(new SpawnEnemyBehavior());
    }
}
