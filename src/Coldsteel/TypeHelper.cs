﻿// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using System;
using System.Linq;

namespace Coldsteel
{
    internal static class TypeHelper
    {
        /// <summary>
        /// Gets a type given a partial name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static Type FindType(string name) =>
            Type.GetType(name) ?? AppDomain.CurrentDomain.GetAssemblies().Select(a => a.GetType(name)).FirstOrDefault(t => t != null);
    }
}
