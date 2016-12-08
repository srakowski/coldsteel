// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

namespace Coldsteel
{
    /// <summary>
    /// A contract for behaviors into interact with for the purpsoses
    /// of responding to user input.
    /// </summary>
    public interface IInputManager
    {
        IButtonControl GetButtonControl(string name);
        void AddControl(IControl control);
    }
}
