// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using Coldsteel.Input;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace Coldsteel
{
    /// <summary>
    /// This component is responsible for ensuring input states are 
    /// updated between frames.
    /// </summary>
    internal class InputManager : GameComponent, IInputManager
    {
        private IInputState[] _inputStates;
        private Dictionary<string, IControl> _controls = new Dictionary<string, IControl>();

        public InputManager(Game game, Func<IEnumerable<IControl>> controls) : base(game)
        {
            game.Services.AddService<IInputManager>(this);

            // TODO: maybe this doesn't belong here?
            _inputStates = new IInputState[]
            {
                InputStates.Keyboard,
                InputStates.Mouse,
                InputStates.GamePads[(int)PlayerIndex.One],
                InputStates.GamePads[(int)PlayerIndex.Two],
                InputStates.GamePads[(int)PlayerIndex.Three],
                InputStates.GamePads[(int)PlayerIndex.Four]
            };

            foreach (var control in controls())
                AddControl(control);
        }

        public IButtonControl GetButtonControl(string name) =>
            _controls[name] as IButtonControl;

        public IPositionalControl GetPositionalControl(string name) =>
            _controls[name] as IPositionalControl;

        public IDirectionalControl GetDirectionalControl(string name) =>
                    _controls[name] as IDirectionalControl;

        public void AddControl(IControl control) =>
            _controls[control.Name] = control;

        public override void Update(GameTime gameTime)
        {
            InputStates.CenterScreen = new Vector2(
                Game.GraphicsDevice.Viewport.Width * 0.5f,
                Game.GraphicsDevice.Viewport.Height * 0.5f);

            foreach (var inputState in _inputStates)
                inputState.Update();
        }
    }
}
