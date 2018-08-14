// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of this source code package.

using System.Collections.Generic;
using System.Linq;

namespace Coldsteel
{
    internal static class Extensions
    {
        /// <summary>
        /// Appends a value to the sequence.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="self"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static IEnumerable<T> Append<T>(this IEnumerable<T> self, T value) => self.Concat(new[] { value });

        /// <summary>
        /// Excludes a value from the sequence.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="self"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static IEnumerable<T> Exclude<T>(this IEnumerable<T> self, T value) => self.Except(new[] { value });
    }
}
