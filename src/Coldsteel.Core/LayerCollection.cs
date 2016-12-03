using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Coldsteel.Core
{
    internal class LayerCollection : IEnumerable<Layer>
    {
        private List<Layer> _layers = new List<Layer>();

        public LayerCollection()
        {
            Add(new Layer("default", 0));
        }

        public void Add(Layer layer)
        {
            _layers.Add(layer);
        }

        public IEnumerator<Layer> GetEnumerator() =>
            this._layers.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() =>
            this.GetEnumerator();
    }
}
