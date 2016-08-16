using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Coldsteel
{
    public class LayerManager
    {
        private Layer _layer = new Layer();

        public Layer Default => _layer;

        internal void ForEach(Action<Layer> doThis)
        {
            doThis(_layer);
        }
    }
}
