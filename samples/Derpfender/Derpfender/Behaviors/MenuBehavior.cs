using Coldsteel.Scripting;
using Derpfender.Models;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Derpfender.Behaviors
{
    public abstract class MenuBehavior : Behavior
    {
        private List<MenuOption> _options = new List<MenuOption>();

        private int _selectedOption;

        public MenuBehavior()
        {
            _selectedOption = 0;
        }

        public void AddMenuOption(MenuOption option) =>
            _options.Add(option);

        public override void Activate()
        {
            this.Transform.LocalPosition = _options[_selectedOption].SelectorPosition;
        }

        public override void Update()
        {
            if (Input.GetButtonControl("Up").IsDown())
            {
                _selectedOption--;
                _selectedOption = MathHelper.Clamp(_selectedOption, 0, _options.Count - 1);
                this.Transform.LocalPosition = _options[_selectedOption].SelectorPosition;
            }
            else if (Input.GetButtonControl("Down").IsDown())
            {
                _selectedOption++;
                _selectedOption = MathHelper.Clamp(_selectedOption, 0, _options.Count - 1);
                this.Transform.LocalPosition = _options[_selectedOption].SelectorPosition;
            }
            else if (Input.GetButtonControl("Select").IsDown())
            {
                _options[_selectedOption].Invoke();
            }
        }
    }
}
