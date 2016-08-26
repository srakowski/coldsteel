using Coldsteel;
using Microsoft.Xna.Framework;
using SuperBigSister.Behaviors;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperBigSister.States
{
    class GameplayState : GameState
    {
        public override void Preload()
        {
            Load.SpriteSheet("adi", 50, 72);
        }

        public override void Create()
        {
            Stage.BackgroundColor = new Color(92, 148, 252);
            World.Gravity = new Vector2(0, 9.86f);

            World.AddGameObject()
                .Set.Position(100, 300)
                .Add.RigidBody()
                .Add.SpriteSheetRenderer("adi")
                .Add.Animation("stand", new int[] { 0, 1 }, 900)
                .Add.Animation("run", new int[] { 3, 4 }, 100)
                .Add.Animation("jump", 2)
                .Add.Component(new PlayerStateMachine());
        }
    }
}
