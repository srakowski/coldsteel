using Coldsteel.Components;
using Coldsteel.Controls;
using Derpfender.Models;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Derpfender.Behaviors
{
    public class MenuSelectBehavior : Behavior
    {
        private MenuOption[] _options;

        private int _selectedOption;

        //private ButtonControl _menuUp;

        //private ButtonControl _menuDown;

        //private ButtonControl _menuSelect;

        public MenuSelectBehavior()
        {
            _selectedOption = 0;
        }

        //public override void Initialize()
        //{
        //    //_menuUp = Controls.Get<ButtonControl>("MenuUp");
        //    //_menuDown = Controls.Get<ButtonControl>("MenuDown");
        //    //_menuSelect = Controls.Get<ButtonControl>("MenuSelect");
        //}

        public override void Update()
        {
            //if (_menuUp.IsDown())
            //{
            //    _selectedOption--;
            //    _selectedOption = MathHelper.Clamp(_selectedOption, 0, _options.Length - 1);
            //    this.Transform.LocalPosition = _options[_selectedOption].SelectorPosition;
            //}
            //else if (_menuDown.IsDown())
            //{
            //    _selectedOption++;
            //    _selectedOption = MathHelper.Clamp(_selectedOption, 0, _options.Length - 1);
            //    this.Transform.LocalPosition = _options[_selectedOption].SelectorPosition;
            //}
            //else if (_menuSelect.IsDown())
            //{
            //    _options[_selectedOption].Invoke();
            //}
        }
    }
}
