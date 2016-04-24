using System;
using System.Collections.Generic;
using System.Text;

namespace Coldsteel
{
    public interface IColdsteelInitializer
    {
        void InitializeControls(Input input);
        void RegisterStages(GameStageRegistry stages);
    }
}
