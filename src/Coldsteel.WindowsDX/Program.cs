using Coldsteel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coldsteel.WindowsDX
{
    class Program
    {
        [STAThread]
        public static void Main()
        {
            using (var game = new ColdsteelGame())
                game.Run();
        }
    }
}
