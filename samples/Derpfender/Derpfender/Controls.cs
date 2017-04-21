// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using System.Collections.Generic;
using Coldsteel;
using Coldsteel.Input;
using Microsoft.Xna.Framework.Input;

namespace Derpfender
{
    public class Controls
    {
        private ButtonControl Up { get; } = new ButtonControl("Up");

        private ButtonControl Down { get; } = new ButtonControl("Down");

        private ButtonControl Select { get; } = new ButtonControl("Select");

        private Controls()
        {
            Up.BindTo(new KeyboardButton(Keys.W));
            Up.BindTo(new KeyboardButton(Keys.Up));

            Down.BindTo(new KeyboardButton(Keys.S));
            Down.BindTo(new KeyboardButton(Keys.Down));

            Select.BindTo(new KeyboardButton(Keys.Space));
            Select.BindTo(new KeyboardButton(Keys.Enter));
        }

        public static IEnumerable<IControl> Get()
        {
            var controls = new Controls();
            return new IControl[]
            {
                controls.Up,
                controls.Down,
                controls.Select,
                new KeyboardButton(Keys.Left),
                new KeyboardButton(Keys.Right)
            };
        }
    }
}
