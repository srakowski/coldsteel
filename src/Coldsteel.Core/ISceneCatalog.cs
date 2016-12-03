using System;
using System.Collections.Generic;
using System.Text;
using Coldsteel.Core;

namespace Coldsteel
{
    public interface ISceneCatalog
    {
        string StartingSceneId { get; }
        Scene Instantiate(string sceneId);
    }
}
