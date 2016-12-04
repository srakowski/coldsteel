using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Derpfender.Models
{
    public class MenuOption
    {
        public Vector2 SelectorPosition { get; private set; }

        private Action _action;

        public MenuOption(Vector2 selectorPosition, Action action)
        {
            this.SelectorPosition = selectorPosition;
            this._action = action;
        }

        public void Invoke() =>
            _action.Invoke();
    }
}
