using Coldsteel;
using Microsoft.Xna.Framework;
using Derpfender.Behaviors;
using System;
using System.Collections.Generic;
using System.Text;

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
