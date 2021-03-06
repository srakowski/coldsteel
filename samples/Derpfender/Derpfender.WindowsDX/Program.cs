﻿// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using Coldsteel;

namespace Derpfender
{
    class Program
    {
        public static void Main()
        {
            using (var game = new ColdsteelGame())
                game.Run();
        }
    }
}
