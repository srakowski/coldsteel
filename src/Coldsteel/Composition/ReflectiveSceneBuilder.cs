// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using Coldsteel.Rendering;
using Microsoft.Xna.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Reflection;

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
            AddPropertyValuesToScene();
            AddManyPropertyValuesToScene();
        }

        public Scene GetResult() => _scene;

        protected virtual void Compose() { }

        private void AddPropertyValuesToScene()
        {
            var properties = this.GetType().GetProperties()
                .Where(p => p.PropertyType.IsSubclassOf(typeof(SceneElement)));
            foreach (var property in properties)
                _scene.AddElement(property.GetValue(this) as SceneElement);
        }

        private void AddManyPropertyValuesToScene()
        {
            var properties = this.GetType().GetProperties().Where(IsOfSceneElement);
            foreach (var property in properties)
            {
                var enumerable = property.GetValue(this) as IEnumerable;
                foreach (var element in enumerable)
                    _scene.AddElement(element as SceneElement);
            }
        }

        private bool IsOfSceneElement(PropertyInfo property)
        {
            var type = property.PropertyType;
            if (type.GetInterface(nameof(IEnumerable)) == null)
                return false;

            var elementType = type.IsArray
                ? type.GetElementType()
                : type.IsGenericType
                    ? type.GenericTypeArguments.FirstOrDefault()
                    : null;

            var result = elementType?.IsSubclassOf(typeof(SceneElement)) ?? false;
            return result;
        }
    }
}
