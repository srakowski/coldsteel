// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using Coldsteel.Composition;
using System.Collections.Generic;
using Coldsteel;
using Coldsteel.Input;
using Microsoft.Xna.Framework.Input;

namespace Derpfender
{
    public class Controls : IControlsBuilder
    {
        public ButtonControl Up { get; } = new ButtonControl("Up");

        public ButtonControl Down { get; } = new ButtonControl("Down");

        public ButtonControl Select { get; } = new ButtonControl("Select");

        public void ConfigureControls()
        {
            Up.AddBinding(new KeyboardButtonControlBinding(Keys.W));
            Up.AddBinding(new KeyboardButtonControlBinding(Keys.Up));

            Down.AddBinding(new KeyboardButtonControlBinding(Keys.S));
            Down.AddBinding(new KeyboardButtonControlBinding(Keys.Down));

            Select.AddBinding(new KeyboardButtonControlBinding(Keys.Space));
            Select.AddBinding(new KeyboardButtonControlBinding(Keys.Enter));
        }

        public IEnumerable<IControl> GetResult()
        {
            return new IControl[]
            {
                Up,
                Down,
                Select
            };
        }
    }
}
