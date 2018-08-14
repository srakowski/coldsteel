// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of this source code package.

using System;

namespace Coldsteel
{
    public interface IContentReference
    {
        string Name { get; }
        Type ContentType { get; }
    }

    /// <summary>
    /// A reference to some loaded content.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public struct ContentReference<T> : IContentReference
    {
        private string _name;

        public ContentReference(string name) => _name = name;

        /// <summary>
        /// The name of the content reference.
        /// </summary>
        public string Name => _name ?? string.Empty;

        /// <summary>
        /// Gets the type of the content.
        /// </summary>
        public Type ContentType => typeof(T);

        public static implicit operator ContentReference<T>(string name) => 
            new ContentReference<T>(name);
    }
}
