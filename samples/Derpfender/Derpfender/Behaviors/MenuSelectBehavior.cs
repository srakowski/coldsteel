using Coldsteel;
using Coldsteel.Controls;
using Derpfender.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Derpfender.Behaviors
{
    class MenuSelectBehavior : Behavior
    {
        private MenuOption[] _options;

        private int _selectedOption;

        private ButtonControl _menuUp;

        private ButtonControl _menuDown;

        private ButtonControl _menuSelect;

        public MenuSelectBehavior(params MenuOption[] options)
        {
            _options = options;
            _selectedOption = 0;
        }

        public override void Initialize()
        {
            _menuUp = Input.GetControl<ButtonControl>("MenuUp");
            _menuDown = Input.GetControl < ButtonControl>("MenuDown");
            _menuSelect = Input.GetControl < ButtonControl>("MenuSelect");
        }

        public override void Update()
        {
            if (_menuUp.IsDown())
            {
                _selectedOption--;
                this.Transform.LocalPosition = _options[_selectedOption].SelectorPosition;
            }
            else if (_menuDown.IsDown())
            {
                _selectedOption++;
                this.Transform.LocalPosition = _options[_selectedOption].SelectorPosition;
            }
            else if (_menuSelect.IsDown())
            {
                _options[_selectedOption].Invoke();
            }
        }
    }
}
