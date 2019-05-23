// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using Coldsteel.Controls;
using System.Collections.Generic;
using System.Linq;

namespace Coldsteel
{
    public class EngineConfig
    {
        public EngineConfig(
            ISceneFactory sceneFactory,
            IEnumerable<Control> controls)
        {
            SceneFactory = sceneFactory;
            Controls = controls.ToDictionary((ks) => ks.Name);
        }

        public ISceneFactory SceneFactory { get; }

        public IReadOnlyDictionary<string, Control> Controls { get; }
    }
}
