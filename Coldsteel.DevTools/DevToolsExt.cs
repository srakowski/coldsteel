// MIT License - Copyright (C) Shawn Rakowski
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using Coldsteel.DevTools;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System.Threading.Tasks;

namespace Coldsteel
{
    public static class DevToolsExt
    {
        public static Engine Engine { get; private set; }

        public static void UseDevTools(this Engine engine)
        {
            if (Engine != null) return;
            Engine = engine;
            Task.Factory.StartNew(() =>
            {
                WebHost.CreateDefaultBuilder()
                    .UseStartup<Startup>()
                    .Build()
                    .Run();
            });
        }
    }
}
