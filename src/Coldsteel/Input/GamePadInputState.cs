// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Coldsteel.Input
{
    /// <summary>
    /// Maintains Previous and Current GamePad state for control evaluation.
    /// </summary>
    internal class GamePadInputState : IInputState<GamePadState>
    {
        private PlayerIndex _playerIndex;

        public GamePadState PreviousState { get; private set; } = new GamePadState();

        public GamePadState CurrentState { get; private set; } = new GamePadState();

        public GamePadInputState(PlayerIndex playerIndex)
        {
            _playerIndex = playerIndex;
        }

        public void Update()
        {
            PreviousState = PreviousState;
            CurrentState = GamePad.GetState(_playerIndex);
        }
    }
}
