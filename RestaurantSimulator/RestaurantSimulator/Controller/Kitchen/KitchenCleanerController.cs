using RestaurantSimulator.Model.Salle.Components;
using RestaurantSimulator.Model.Shared;
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
        public static void stock(Dictionary<string,int> dirty)
        {
            foreach(KeyValuePair<string, int> elem in dirty)
            {
                int temp;
                if (StockEquipment.Instance.Clean.TryGetValue(elem.Key,out temp)){
                    if (elem.Key == "tablecloth" || elem.Key == "towel")
                    {
                        toWashLaundry[elem.Key] += elem.Value;
                        checkLaundry();
                    }
                    else
                    {
                        toWashDishes[elem.Key] += elem.Value;
                        checkDishes();
                    }
                }
                else
                {
                    toWashLaundry[elem.Key] += elem.Value;
                    checkTools();
                }
                
            }
        }

        private static void checkTools()
        {
            foreach (KeyValuePair<string, int> elem in toWashTools)
            {
                Thread.Sleep(500);
                toWashTools[elem.Key] -= 1;
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
            foreach(KeyValuePair<string, int> elem in toWashDishes)
            {
                if(elem.Value > 10)
                {

                }
                else
                {
                    return;
                }
            }
            Thread t = new Thread(new ParameterizedThreadStart(Wash));
            t.Start(10000);
            t.Join();

            foreach (KeyValuePair<string, int> elem in toWashDishes)
            {
                if (elem.Value <= 24)
                {
                    toWashDishes[elem.Key] -= elem.Value;
                }
                else
                {
                    toWashDishes[elem.Key] -= 24;
                }
            }
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
