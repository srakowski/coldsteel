using Coldsteel;
using Coldsteel.Renderers;
using Derpfender.Behaviors;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Derpfender.Stages
{
    class MainMenuStage : GameStage
    {
        public override void LoadContent()
        {
            LoadContent<SpriteFont>("MenuFont");
            LoadContent<Texture2D>("ship");
            LoadContent<Texture2D>("star");
        }

        public override void Initialize()
        {
            var background = AddLayer("background", -1);
            background.BlendState = BlendState.NonPremultiplied;
            background.SamplerState = SamplerState.PointClamp;
            SetupStarField(background);

            var mainMenu = new GameObject()
                .SetPosition(new Vector2(200, 200))
                .AddComponent(new TextRenderer(DefaultLayer, GetContent<SpriteFont>("MenuFont"), "Derpfender"));
            AddGameObject(mainMenu);

            var playOption = new GameObject()
                .SetPosition(new Vector2(40, 40))
                .AddComponent(new TextRenderer(DefaultLayer, GetContent<SpriteFont>("MenuFont"), "Play"));

            mainMenu.AddChild(playOption);

            var exitOption = new GameObject()
                .SetPosition(new Vector2(40, 80))
                .AddComponent(new TextRenderer(DefaultLayer, GetContent<SpriteFont>("MenuFont"), "Exit"));

            mainMenu.AddChild(exitOption);

            var selector = new GameObject()
                .SetPosition(new Vector2(15, 53))
                .SetRotation((float)Math.PI / 2f)
                .AddComponent(new SpriteRenderer(DefaultLayer, GetContent<Texture2D>("ship")))
                .AddComponent(new MenuSelectorBehavior(Play, Exit));

            mainMenu.AddChild(selector);            
        }

        private void Play()
        {
            GameStageManager.LoadStage("GameplayStage");
        }

        private void Exit()
        {
            // TODO: figure out exiting
        }

        private void SetupStarField(Layer layer)
        {
            var rand = new Random();
            for (var i = 0; i < 200; i++)
            {
                var r = rand.Next(56, 256);
                var g = rand.Next(56, 256);
                var b = rand.Next(56, 256);
                var alpha = rand.Next(56, 256);
                AddGameObject(new GameObject()
                    .SetPosition(new Vector2(rand.Next(0, 1280), rand.Next(0, 720)))
                    .AddComponent(new SpriteRenderer(layer, GetContent<Texture2D>("star")) { Color = new Color(r, g, b, alpha) })
                    .AddComponent(new StarMoveBehavior(alpha)));
            }
        }
    }
}
