using System;

namespace SuperBigSister.WindowsDX
{
#if WINDOWS || LINUX
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (var game = new SuperBigSisterGame())
                game.Run();
        }
    }
#endif
}
