using System;

namespace SpaceFortress2
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (SpaceFortress2Game game = new SpaceFortress2Game())
            {
                game.Run();
            }
        }
    }
#endif
}

