// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

namespace Coldsteel.Input
{
    /// <summary>
    /// Allows typed IInputState<> instances to be put into an enumerable.
    /// </summary>
    internal interface IInputState
    {
        void Update();
    }

    /// <summary>
    /// Represents the current and previous states of some input device.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal interface IInputState<T> : IInputState
    {
        T PreviousState { get; }
        T CurrentState { get; }
    }
}
