using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RestaurantSimulator.Controller.Kitchen
{
    public static class KitchenCleanerController
    {

        private static Dictionary<string, int> toWashLaundry = new Dictionary<string, int>();
        private static Dictionary<string, int> toWashTools = new Dictionary<string, int>();
        private static Dictionary<string, int> toWashDishes = new Dictionary<string, int>();

        private static Semaphore _cleaner = new Semaphore(2, 2);

        private static void Wash(Object obj)
        {
            _cleaner.WaitOne();
            int time = (int)obj;
            Thread.Sleep(time);
            _cleaner.Release(1);
        }

        public static void WashLaundry(int quantity)
        {

        }

        public static void WashDishes()
        {

        }

    
        public static void WashTools(int size)
        {
            //Big tool
            if(size == 0)
            {
                Thread t = new Thread(new ParameterizedThreadStart(Wash));
                t.Start(1500);
            }
            //Little tool
            else if(size == 1)
            {
                Thread t = new Thread(new ParameterizedThreadStart(Wash));
                t.Start(500);
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public static void InitSocketServer()
        {

        }

        //Entry to KitchenCleanerController. This method stock Laundry and Dishes to wash.
        public static void stock(string name, int type, int quantity)
        {
            switch (type)
            {
                //0: Laundry
                case 0:
                    toWashLaundry[name] += quantity;
                    checkLaundry();
                    break;
                //1: Dishes
                case 1:
                    toWashDishes[name] += quantity;
                    checkDishes();
                    break;
               
            }
        }

        private static void checkLaundry()
        {
            int total = 0;
            foreach(KeyValuePair<string, int> elem in toWashLaundry)
            {
                total += elem.Value;
            }
            if(total >= 10)
            {
                Wash(16000);
            }
        }
        private static void checkDishes()
        {

        }

        private static string ConvertBytesString(byte[] data)
        {
            return "true";
        }
        private static string ConvertStringBytes(string str)
        {
            return "true";
        }
    }
}
