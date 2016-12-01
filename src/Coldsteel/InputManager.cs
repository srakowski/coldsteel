using Coldsteel.Controls;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coldsteel
{
    public class InputManager
    {
        internal KeyboardState PreviousKeyboardState { get; set; } = new KeyboardState();
        internal KeyboardState CurrentKeyboardState { get; set; } = new KeyboardState();
        internal GamePadState PreviousGamePadState { get; set; } = new GamePadState();
        internal GamePadState CurrentGamePadState { get; set; } = new GamePadState();
        internal MouseState CurrentMouseState { get; set; } = new MouseState();
        internal MouseState PreviousMouseState { get; set; } = new MouseState();

        private Dictionary<string, Control> _controls = new Dictionary<string, Control>();

        public Control this[string controlName] =>
            _controls[controlName];

        public T GetControl<T>(string controlName) where T : Control =>
            this[controlName] as T;

        public void Update(GameTime gameTime)
        {
            PreviousKeyboardState = CurrentKeyboardState;
            CurrentKeyboardState = Keyboard.GetState();
            PreviousGamePadState = CurrentGamePadState;
            CurrentGamePadState = GamePad.GetState(Microsoft.Xna.Framework.PlayerIndex.One, GamePadDeadZone.Circular);
            PreviousMouseState = CurrentMouseState;
            CurrentMouseState = Mouse.GetState();
        }
    }
}
