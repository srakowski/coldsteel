using Coldsteel;
using Coldsteel.Rendering;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperBigSister.Behaviors
{
    public class PlayerStateMachine : StateMachine
    {
        public override void Initialize()
        {
            AddState<IdleBehavior>("idle")
                .Trigger("jump").When(_ => Input["jump"].ButtonControl.IsDown())
                .Trigger("runLeft").When(_ => Input["left"].ButtonControl.IsDown())
                .Trigger("runRight").When(_ => Input["right"].ButtonControl.IsDown());

            AddState<JumpBehavior>("jump")
                .Trigger("jump").When(_ => Input["jump"].ButtonControl.WasUp());

            AddState<RunLeftBehavior>("runLeft")
                .Trigger("jump").When(_ => Input["jump"].ButtonControl.IsDown())
                .Trigger("runRight").When(_ => Input["right"].ButtonControl.IsDown())
                .Trigger("idle").When(_ => Input["left"].ButtonControl.IsUp());

            AddState<RunRightBehavior>("runRight")
                .Trigger("jump").When(_ => Input["jump"].ButtonControl.IsDown())
                .Trigger("runLeft").When(_ => Input["left"].ButtonControl.IsDown())
                .Trigger("idle").When(_ => Input["right"].ButtonControl.IsUp());

            Start("idle");
        }
    }
}
