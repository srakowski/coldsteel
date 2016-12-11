﻿// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Coldsteel.Input
{
    /// <summary>
    /// This component is responsible for ensuring input states are 
    /// updated between frames.
    /// </summary>
    internal class InputManager : GameComponent, IInputManager
    {
        private IInputState[] _inputStates;

        private Dictionary<string, IButtonControl> _buttonControls = new Dictionary<string, IButtonControl>();
        private Dictionary<string, IPositionalControl> _positionalControls = new Dictionary<string, IPositionalControl>();
        private Dictionary<string, IDirectionalControl> _directionalControls = new Dictionary<string, IDirectionalControl>();

        public InputManager(Game game) : base(game)
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
        }

        public IButtonControl GetButtonControl(string name) =>
            _buttonControls[name];

        public IPositionalControl GetPositionalControl(string name) =>
            _positionalControls[name];

        public IDirectionalControl GetDirectionalControl(string name) =>
            _directionalControls[name];

        public void AddControl(IControl control)
        {
            AddButtonControl(control as IButtonControl);
            AddPositionalControl(control as IPositionalControl);
            AddDirectionalControl(control as IDirectionalControl);
        }

        public void AddButtonControl(IButtonControl buttonControl)
        {
            if (buttonControl != null)
                _buttonControls[buttonControl.Name] = buttonControl;
        }

        public void AddPositionalControl(IPositionalControl control)
        {
            if (control == null)
                return;

            _positionalControls[control.Name] = control;
        }

        public void AddDirectionalControl(IDirectionalControl control)
        {
            if (control == null)
                return;

            _directionalControls[control.Name] = control;
        }

        public override void Update(GameTime gameTime)
        {
            InputStates.CenterScreen = new Vector2(Game.GraphicsDevice.Viewport.Width * 0.5f,
                Game.GraphicsDevice.Viewport.Height * 0.5f);
            foreach (var inputState in _inputStates)
                inputState.Update();
        }
    }
}
