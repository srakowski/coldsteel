using Coldsteel;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperBigSister.Behaviors
{
    public class JumpBehavior : Behavior
    {
        public override void Initialize()
        {
            Animations.Play("jump");
            RigidBody.Velocity = new Vector2(RigidBody.Velocity.X, -10);
        }

        public override void Update()
        {
            if (Input["left"].ButtonControl.IsDown())
            {
                RigidBody.Velocity = new Vector2(-5, RigidBody.Velocity.Y);
                Set.SpriteEffects(SpriteEffects.FlipHorizontally);
            }

            if (Input["right"].ButtonControl.IsDown())
            {
                RigidBody.Velocity = new Vector2(5, RigidBody.Velocity.Y);
                Set.SpriteEffects(SpriteEffects.None);
            }
        }
    }
}
