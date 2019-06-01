// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using Coldsteel;

namespace Derpfender
{
    class SceneFactory : ISceneFactory
    {
        public Scene Create(string sceneName)
        {
            if (sceneName == nameof(Scenes.MainMenu))
                return Scenes.MainMenu.Create();

            return null;
        }
    }
}
