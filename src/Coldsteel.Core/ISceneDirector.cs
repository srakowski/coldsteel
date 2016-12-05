using System;
using System.Collections.Generic;
using System.Text;
using Coldsteel.Core;
using System.Collections;

namespace Coldsteel.Core
{
    public interface ISceneDirector
    {
        void BeginConstruction(string sceneId, ISceneBuilder sceneBuilder);
        void Update();
    }
}
