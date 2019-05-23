// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using System.Collections.Generic;

namespace Coldsteel.Controls
{
    public abstract class Control
    {
        protected Control(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }

    public abstract class Control<TBinding> : Control where TBinding : ControlBinding
    {
        protected readonly List<TBinding>[] _bindingsByPlayer = new[]
        {
            new List<TBinding>(),
            new List<TBinding>(),
            new List<TBinding>(),
            new List<TBinding>()
        };

        protected Control(string name) : base(name)
        {
        }

        public void AddBinding(TBinding binding)
        {
            _bindingsByPlayer[(int)binding.PlayerIndex].Add(binding);
        }
    }
}
