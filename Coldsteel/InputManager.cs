// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using KB = Microsoft.Xna.Framework.Input.Keyboard;
using MS = Microsoft.Xna.Framework.Input.Mouse;
using GP = Microsoft.Xna.Framework.Input.GamePad;

namespace Coldsteel
{
    internal class InputManager : GameComponent
    {
        private readonly Engine _engine;

        public InputManager(Game game, Engine engine) : base(game)
        {
            _engine = engine;
            game.Components.Add(this);
            Keyboard = new InputStates<KeyboardState>();
            Mouse = new InputStates<MouseState>();
            GamePads = new InputStates<GamePadState>[]
            {
                new InputStates<GamePadState>(),
                new InputStates<GamePadState>(),
                new InputStates<GamePadState>(),
                new InputStates<GamePadState>(),
            };
        }

        public static InputStates<KeyboardState> Keyboard;

        public static InputStates<MouseState> Mouse;

        public static InputStates<GamePadState>[] GamePads;

        public static Vector2 CenterScreen;

        public override void Update(GameTime gameTime)
        {
            CenterScreen = Game.GraphicsDevice.Viewport.Bounds.Center.ToVector2();
            Keyboard = Keyboard.Next(KB.GetState());
            Mouse = Mouse.Next(MS.GetState());
            UpdateGamePadState(PlayerIndex.One);
            UpdateGamePadState(PlayerIndex.Two);
            UpdateGamePadState(PlayerIndex.Three);
            UpdateGamePadState(PlayerIndex.Four);
        }

        private static void UpdateGamePadState(PlayerIndex playerIndex)
        {
            GamePads[(int)playerIndex] = GamePads[(int)playerIndex].Next(GP.GetState(playerIndex));
        }
    }
}
