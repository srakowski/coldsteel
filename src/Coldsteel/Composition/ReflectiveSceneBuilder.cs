// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using Microsoft.Xna.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Coldsteel.Composition
{
    /// <summary>
    /// SceneBuilder that uses its own properties to build the scene.
    /// </summary>
    public abstract class ReflectiveSceneBuilder : ISceneBuilder
    {
        private Scene _scene;

        public virtual Color BackgroundColor { get; } = Color.CornflowerBlue;

        public ReflectiveSceneBuilder()
        {
            _scene = new Scene();
            Compose();
        }

        public void ConfigureScene()
        {
            _scene.BackgroundColor = BackgroundColor;
            AddPropertyValuesToScene<Layer>();
            AddManyPropertyValuesToScene<Layer>();
            AddPropertyValuesToScene<GameObject>();
            AddManyPropertyValuesToScene<GameObject>();
        }

        public Scene GetResult() => _scene;

        protected virtual void Compose() { }

        private void AddPropertyValuesToScene<T>() where T : ISceneElement
        {
            var properties = this.GetType().GetProperties()
                .Where(p => p.PropertyType == typeof(T));
            foreach (var property in properties)
                _scene.Add(property.GetValue(this) as ISceneElement);
        }

        private void AddManyPropertyValuesToScene<T>() where T : ISceneElement
        {
            var enumerableOfTypeType = typeof(IEnumerable<T>);
            var properties = this.GetType().GetProperties();
            var enumerableProperties = properties.Where(p => enumerableOfTypeType.IsAssignableFrom(p.PropertyType));
            foreach (var property in enumerableProperties)
            {
                var enumerable = property.GetValue(this) as IEnumerable;
                foreach (var element in enumerable)
                    _scene.Add(element as ISceneElement);
            }
        }
    }
}
