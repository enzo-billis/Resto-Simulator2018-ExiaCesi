using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSimulator.Model.Shared
{
    public static class Parameters
    {
        public const int TABLES_BY_SQUARE = 6;
        public const int WAITER_BY_SQUARE = 1;
        public const int RANKCHIEF_NUMBER = 2;
        public const int MAP_NUMBER = 40;
        public static int SPEED = 1;

        public static string KICHEN_SERVER_LOCAL_IP = "127.0.0.1";
        public static int KITCHEN_SERVER_COMMAND_PORT = 9897;
        public static bool KITCHEN_SERVER_STARTED = false;

        public static string SALLE_CLIENT_LOCAL_IP = "127.0.0.1";
        public static int SALLE_CLIENT_COMMAND_PORT = 9897;
        public static bool SALLE_CLIENT_STARTED = false;

        public static int SALLE_NUMBER = 1;

        //public static string LOG_PATH = Directory.GetCurrentDirectory();
        public static string LOG_PATH = @"C:\Users\Arthur\Documents\DiagrammeCSharp\log.txt";

        private static Dictionary<string, int> options;

        public static Dictionary<string, int> Options { get => options; set => options = value; }
    }
}
