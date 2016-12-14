// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

namespace Coldsteel
{
    /// <summary>
    /// Required Service.
    /// Providers implementing this service are responsible for composing
    /// the game, i.e. configuring the input, screen, etc.
    /// </summary>
    internal interface IGameComposer
    {
        void ConfigureInput(IInputManager inputManager);
        ISceneFactory CreateSceneFactory();
    }
}
