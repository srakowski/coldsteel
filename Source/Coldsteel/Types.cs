// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of this source code package.

using System;

namespace Coldsteel
{
    /// <summary>
    /// Abstract Maybe type.
    /// </summary>
    public interface IMaybe
    {
        bool HasValue { get; }
        object GetValue();
    }

    /// <summary>
    /// A value which may or may not have a type.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public struct Maybe<T> : IMaybe
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

        /// <summary>
        /// Gets a non-typed value, if any.
        /// </summary>
        /// <returns></returns>
        object IMaybe.GetValue() => Value;
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

        /// <summary>
        /// When has value invokes the selector and flattens the result to the maybe type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="self"></param>
        /// <param name="selector"></param>
        /// <returns></returns>
        public static Maybe<TResult> Bind<T, TResult>(this Maybe<T> self, Func<T, Maybe<TResult>> selector) =>
            self.HasValue ? selector(self.Value) : None<TResult>();

        /// <summary>
        /// Filters any value out to None if the predicate is false.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="self"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static Maybe<T> Where<T>(this Maybe<T> self, Func<T, bool> predicate) =>
            !self.HasValue ? None<T>() :
            predicate(self.Value) ? self :
            Maybe.None<T>();

        /// <summary>
        /// Casts the value contained in the Maybe to <typeparamref name="T"/> and
        /// returns a Maybe of that type, or returns None of that type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="self"></param>
        /// <returns></returns>
        public static Maybe<T> OfType<T>(this IMaybe self) =>
            self.HasValue ? new Maybe<T>((T)self.GetValue()) : None<T>();

        /// <summary>
        /// Casts the Type of the maybe to a different type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="maybe"></param>
        /// <returns></returns>
        public static Maybe<T> Cast<T>(this IMaybe maybe) => maybe.HasValue ? (T)maybe.GetValue() : None<T>();

        /// <summary>
        /// Gets the value inside the maybe or returns the result of <paramref name="altValue"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="self"></param>
        /// <param name="altValue"></param>
        /// <returns></returns>
        public static T GetValueOr<T>(this Maybe<T> self, Func<T> altValue) =>
            self.HasValue ? self.Value : altValue();
    }
}
