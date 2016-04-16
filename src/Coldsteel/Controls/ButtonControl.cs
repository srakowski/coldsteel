using System;
using System.Collections.Generic;
using System.Text;

namespace Coldsteel.Controls
{
    public abstract class ButtonControl : Control
    {
        public virtual bool IsDown() { return false; }

        public virtual bool IsUp() { return false; }

        public virtual bool WasPressed() { return false; }

        public ButtonControl() : base()
        {
        }        
    }
}
