// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using Microsoft.Xna.Framework.Content;
using System;

namespace Coldsteel
{
    public abstract class Asset
    {
        private readonly Func<ContentManager, object> _loader;

        protected Asset(string name, Func<ContentManager, object> loader)
        {
            Name = name;
            _loader = loader;
        }

        public string Name { get; }

        public bool IsLoaded { get; private set; }

        public object Value { get; private set; }

        public T GetValue<T>() => (T)Value;

        internal void Load(ContentManager content)
        {
            Value = _loader.Invoke(content);
            IsLoaded = true;
        }

        internal void Unload()
        {
            IsLoaded = false;
            Value = null;
        }
    }

    public class Asset<T> : Asset
    {
        public Asset(string name)
            : base(name, (c) => c.Load<T>(name))
        {
        }

        public T GetValue()
        {
            if (!this.IsLoaded)
                throw new Exception($"asset not loaded, name: {Name}");

            return base.GetValue<T>();
        }
    }
}