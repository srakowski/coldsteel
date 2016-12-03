using System;
using System.Collections.Generic;
using System.Text;

namespace Coldsteel.Core.Components
{
    internal interface IComponent
    {
        GameObject GameObject { get; set; }

        void Initialize();
    }
}
