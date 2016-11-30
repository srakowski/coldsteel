using Coldsteel;
using Coldsteel.Components;
using Derpfender.Behaviors;
using Derpfender.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Derpfender.Scenes
{
    class MainMenuScene : Scene
    {
        public override void Configure()
        {
            Content.Require<SpriteFont>("fonts/menu");
            Content.Require<Texture2D>("sprites/ship");
            Content.Require<Texture2D>("sprites/star");

            Layers.Add(new Layer("starfield", -1)
            {
                BlendState = BlendState.NonPremultiplied,
                SamplerState = SamplerState.PointClamp
            });

            var mainMenu = new GameObject();
            mainMenu.Transform.Position = new Vector2(200, 200);
            mainMenu.Add(new TextRenderer("fonts/menu", "Derpfender"));
            GameObjects.Add(mainMenu);

            var playOption = new GameObject();
            playOption.Transform.Position = new Vector2(40, 40);
            playOption.Add(new TextRenderer("fonts/menu", "Play"));
            playOption.Transform.Parent = mainMenu.Transform;
            GameObjects.Add(playOption);

            var exitOption = new GameObject();
            exitOption.Transform.Position = new Vector2(40, 80);
            exitOption.Add(new TextRenderer("fonts/menu", "Exit"));
            exitOption.Transform.Parent = mainMenu.Transform;
            GameObjects.Add(exitOption);

            var selectorShip = new GameObject();
            selectorShip.Transform.Position = new Vector2(15, 53);
            selectorShip.Transform.Rotation = MathHelper.ToRadians(90);
            selectorShip.Add(new SpriteRenderer("sprites/ship"));
            selectorShip.Add(
                new MenuSelectBehavior(
                    new MenuOption(new Vector2(15, 53), Play), 
                    new MenuOption(new Vector2(15, 93), Exit)));
            GameObjects.Add(selectorShip);
        }

        public void Play() =>
            SceneManager.Start<GameplayScene>();

        public void Exit()
        {
            // TODO: exit
        }
    }
}
