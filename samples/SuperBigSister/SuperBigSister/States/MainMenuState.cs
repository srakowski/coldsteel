using Coldsteel;
using Microsoft.Xna.Framework;
using SuperBigSister.Behaviors;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperBigSister.States
{
    class MainMenuState : GameState
    {
        public override void Preload()
        {
            Load.SpriteFont("title");
            Load.SpriteFont("subtitle");
            Load.SpriteSheet("adi", 50, 72);
        }

        public override void Create()
        {
            Stage.BackgroundColor = new Color(92, 148, 252);

            World.AddGameObject()
                .Add.Component(new StartGameBehavior());

            World.AddGameObject()
                .Set.Position(150, 50)
                .Add.TextRenderer("title", "Super Big Sister");

            World.AddGameObject()
                .Set.Position(150, 150)
                .Add.TextRenderer("subtitle", "The Quest to Know The Baby's Gender");

            var adi = World.AddGameObject()
                .Set.Position(100, 300)
                .Add.SpriteSheetRenderer("adi")
                .Add.Animation("stand", new int[] { 0, 1 }, 900)
                .Add.Component(new PlayerBehavior());

            World.AddGameObject()
                .Set.Position(150, 500)
                .Add.TextRenderer("subtitle", "Press [SPACEBAR] To Start");
        }
    }
}
