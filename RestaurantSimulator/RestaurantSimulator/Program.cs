using System;
using RestaurantSimulator.Model.Shared;

namespace RestaurantSimulator
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
            RestaurantLauncher restaurant = new RestaurantLauncher();
            using (var game = restaurant.Game)
                game.Run();
        }
    }
#endif
}
