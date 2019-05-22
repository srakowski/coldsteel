// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

namespace Coldsteel
{
    internal struct InputStates<T>
    {
        public InputStates(T previousState, T currentState)
        {
            PreviousState = previousState;
            CurrentState = currentState;
        }

        public T PreviousState { get; }

        public T CurrentState { get; }

        public InputStates<T> Next(T newCurrentState) =>
            new InputStates<T>(CurrentState, newCurrentState);
    }
}
