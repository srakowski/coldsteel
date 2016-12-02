using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coldsteel.DeveloperTools
{
    public static class ColdsteelGameComponentExtensions
    {
        public static void UseDeveloperTools(this ColdsteelGameComponent cs)
        {
            if (cs.Game.Components.Any(c => c is ColdsteelDeveloperToolsGameComponent))
                return;

            cs.Game.Components.Add(new ColdsteelDeveloperToolsGameComponent(cs));
        }
    }
}
