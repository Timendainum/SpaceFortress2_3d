using System;

namespace SpaceFortress2_3d
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (SpaceFortress2 game = new SpaceFortress2())
            {
                game.Run();
            }
        }
    }
#endif
}

