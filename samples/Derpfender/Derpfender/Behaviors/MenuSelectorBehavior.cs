//using Coldsteel;
//using Coldsteel.Controls;
//using Microsoft.Xna.Framework;
//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Derpfender.Behaviors
//{
//    class MenuSelectorBehavior : Behavior
//    {
//        private Action[] _options;

//        private int _selectedOption;

//        public MenuSelectorBehavior(params Action[] options)
//        {
//            _options = options;
//        }

//        public override void Update(IGameTime gameTime)
//        {
//            if (Input.GetControl<ButtonControl>("MenuUp").IsDown() ||
//                Input.GetControl<ButtonControl>("AltMenuUp").IsDown())
//            {
//                _selectedOption--;
//                _selectedOption = MathHelper.Clamp(_selectedOption, 0, _options.Length - 1);
//                Transform.LocalPosition = new Vector2(Transform.LocalPosition.X, 53 + (40 * _selectedOption));
//            }
//            else if (Input.GetControl<ButtonControl>("MenuDown").IsDown() ||
//                Input.GetControl<ButtonControl>("AltMenuDown").IsDown())
//            {
//                _selectedOption++;
//                _selectedOption = MathHelper.Clamp(_selectedOption, 0, _options.Length - 1);
//                Transform.LocalPosition = new Vector2(Transform.LocalPosition.X, 53 + (40 * _selectedOption));
//            }
//            else if (Input.GetControl<ButtonControl>("MenuSelect").IsDown() ||
//                Input.GetControl<ButtonControl>("AltMenuSelect").IsDown())
//            {
//                _options[_selectedOption].Invoke();
//            }
//        }
//    }
//}
