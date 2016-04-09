using System;
using System.Collections.Generic;
using System.Text;

namespace Coldsteel
{
    public abstract class Control
    {
        /// <summary>
        /// A key that uniquely identifies this control.
        /// </summary>
        public string Key { get; private set; }

        public Control(string key)
        {
            this.Key = key;
        }
    }
}
