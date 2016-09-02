using System;
using System.Collections.Generic;
using System.Text;

namespace Coldsteel
{
    public class LayerAddedEvent : EventArgs
    {
        public Layer Layer { get; internal set; }

        public LayerAddedEvent(Layer layer)
        {
            Layer = layer;
        }
    }
}
