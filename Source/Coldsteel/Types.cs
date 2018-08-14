// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of this source code package.

namespace Coldsteel
{
    /// <summary>
    /// A value which may or may not have a type.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public struct Maybe<T>
    {
        /// <summary>
        /// Constructs a new Maybe type with some value. A null value will
        /// evaluate to a Maybe with no value.
        /// </summary>
        /// <param name="value"></param>
        public Maybe(T value)
        {
            Value = value == null ? default(T) : value;
            HasValue = value != null;
        }

        /// <summary>
        /// The Value when HasValue is true.
        /// </summary>
        public T Value { get; }

        /// <summary>
        /// Is some value present or is there none?
        /// </summary>
        public bool HasValue { get; }

        /// <summary>
        /// Implicitly converts a value into a Maybe type. Nulls values do not have a value.
        /// </summary>
        /// <param name="value"></param>
        public static implicit operator Maybe<T>(T value) => new Maybe<T>(value);
    }

    /// <summary>
    /// Extensions to the generic Maybe type.
    /// </summary>
    public static class Maybe
    {
        /// <summary>
        /// Returns a Maybe type with no Value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Maybe<T> None<T>() => new Maybe<T>();
    }
}
