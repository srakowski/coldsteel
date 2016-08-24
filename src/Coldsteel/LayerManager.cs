using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Coldsteel
{
    public class LayerManager
    {
        private List<Layer> _layers = new List<Layer>();

        private Layer _defaultLayer;

        public Layer Default => _defaultLayer;

        public LayerManager()
        {
            _defaultLayer = new Layer("default", 0);
            _layers.Add(_defaultLayer);
        }

        public Layer this[string key] => _layers.FirstOrDefault(x => x.Key == key);

        /// <summary>
        /// Adds a layer to the game state.
        /// </summary>
        /// <param name="key">used to reference the added layer in other game objects</param>
        /// <param name="sortIndex">
        /// sort position in reference to the default 0, layers are drawn from lowest to highest
        /// </param>
        public Layer Add(string key, int sortIndex)
        {
            var layer = new Layer(key, sortIndex);
            _layers.Add(layer);
            _layers.Sort((a, b) => a.SortIndex.CompareTo(b.SortIndex));
            return layer;
        }

        /// <summary>
        /// Perform the given action for each layer.
        /// </summary>
        /// <param name="doThis"></param>
        internal void ForEach(Action<Layer> doThis)
        {
            _layers.ForEach(doThis);
        }
    }
}
