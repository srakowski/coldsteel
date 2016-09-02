using Coldsteel;
using Microsoft.Xna.Framework;
using System;

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

        public override void Update()
        {
            if (Input.GetButtonControl("MenuUp").IsDown())
            {
                _selectedOption--;
                _selectedOption = MathHelper.Clamp(_selectedOption, 0, _options.Length - 1);
                Transform.LocalPosition = new Vector2(Transform.LocalPosition.X, 53 + (40 * _selectedOption));
            }
            else if (Input.GetButtonControl("MenuDown").IsDown())
            {
                _selectedOption++;
                _selectedOption = MathHelper.Clamp(_selectedOption, 0, _options.Length - 1);
                Transform.LocalPosition = new Vector2(Transform.LocalPosition.X, 53 + (40 * _selectedOption));
            }
            else if (Input.GetButtonControl("MenuSelect").IsDown())
            {
                _options[_selectedOption].Invoke();
            }
        }
    }
}
