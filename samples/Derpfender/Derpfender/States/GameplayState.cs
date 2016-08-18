using Coldsteel;
using Derpfender.Behaviors;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Derpfender.States
{
    class GameplayState : GameState
    {
		public override void Preload()
		{
			Load.Image("star");
			Load.Image("ship");
			Load.Image("flash");
			Load.Image("bullet");
			Load.Image("smoke");
			Load.Image("enemy");
			Load.Image("debris");
			Load.SoundEffect("fire");
			Load.SoundEffect("explode");
		}

		public override void Create()
		{
			Stage.BackgroundColor = Color.Black;

			World.AddGameObject("ship")
				.Set.Position(60, 360)
				.Set.RotationDegrees(90)
				.Add.SpriteRenderer("ship")
				.Add.AudioSource("fire")
				.Add.Component(new ShipBehavior());

			World.AddGameObject()
				.Add.Component(new SpawnEnemyBehavior());
		}
	}
}
