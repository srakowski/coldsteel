using System;

namespace Derpfender
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new DerpfenderExampleGame())
                game.Run();
        }
    }
}
