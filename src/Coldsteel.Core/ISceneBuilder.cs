using Coldsteel.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coldsteel.Core
{
    public interface ISceneBuilder
    {
        void Begin(string name);
        object AddContent(Type type, string assetName);
        void AddControl();
        void AddLayer();
        void AddGameObject(GameObject gameObject);
        void End();
    }
}
