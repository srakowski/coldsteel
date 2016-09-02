using System;
using System.Collections.Generic;
using System.Text;

namespace Coldsteel.Input
{
    public abstract class Control
    {
        public ButtonControl ButtonControl => this as ButtonControl;
    }
}
