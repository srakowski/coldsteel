using Coldsteel;
using Coldsteel.Controls;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Derpfender.Behaviors
{
    class MenuSelectorBehavior : Behavior
    {
        private Action[] _options;

        private int _selectedOption;

        public MenuSelectorBehavior(params Action[] options)
        {
            _options = options;
        }

        public override void HandleInput(IGameTime gameTime, Input input)
        {
            if (input.GetControl<ButtonControl>("MenuUp").IsDown() ||
                input.GetControl<ButtonControl>("AltMenuUp").IsDown())
            {
                _selectedOption--;
                _selectedOption = MathHelper.Clamp(_selectedOption, 0, _options.Length - 1);
                Transform.LocalPosition = new Vector2(Transform.LocalPosition.X, 53 + (40 * _selectedOption));
            }
            else if (input.GetControl<ButtonControl>("MenuDown").IsDown() ||
                input.GetControl<ButtonControl>("AltMenuDown").IsDown())
            {
                _selectedOption++;
                _selectedOption = MathHelper.Clamp(_selectedOption, 0, _options.Length - 1);
                Transform.LocalPosition = new Vector2(Transform.LocalPosition.X, 53 + (40 * _selectedOption));
            }
            else if (input.GetControl<ButtonControl>("MenuSelect").IsDown() ||
                input.GetControl<ButtonControl>("AltMenuSelect").IsDown())
            {
                _options[_selectedOption].Invoke();
            }
        }
    }
}
