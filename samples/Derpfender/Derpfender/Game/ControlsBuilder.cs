using Coldsteel.Composition;
using System.Collections.Generic;
using Coldsteel;
using Coldsteel.Input;
using Microsoft.Xna.Framework.Input;

namespace Derpfender.Game
{
    public class ControlsBuilder : IControlsBuilder
    {
        public ButtonControl MenuUp { get; } = new ButtonControl("MenuUp");

        public ButtonControl MenuDown { get; } = new ButtonControl("MenuDown");

        public ButtonControl MenuSelect { get; } = new ButtonControl("MenuSelect");

        public void ConfigureControls()
        {
            MenuUp.AddBinding(new KeyboardButtonControlBinding(Keys.W));
            MenuUp.AddBinding(new KeyboardButtonControlBinding(Keys.Up));

            MenuDown.AddBinding(new KeyboardButtonControlBinding(Keys.S));
            MenuDown.AddBinding(new KeyboardButtonControlBinding(Keys.Down));

            MenuSelect.AddBinding(new KeyboardButtonControlBinding(Keys.Space));
            MenuSelect.AddBinding(new KeyboardButtonControlBinding(Keys.Enter));
        }

        public IEnumerable<IControl> GetResult()
        {
            return new IControl[]
            {
                MenuUp,
                MenuDown,
                MenuSelect
            };
        }
    }
}
