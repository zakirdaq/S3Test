using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileBill
{
    class Program
    {
        static void Main(string[] args)
        {
            // The code provided will print ‘Hello World’ to the console.
            // Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.
            Console.WriteLine("Start Time: ");
            DateTime startTime = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("End Time: ");
            DateTime endTime = DateTime.Parse(Console.ReadLine());

            double bill = CalculateMobileBill(startTime, endTime);

            Console.WriteLine("Bill is: " + Math.Round(bill, 2)  + " taka");
            Console.ReadKey();

            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
        }

        static double CalculateMobileBill(DateTime startTime, DateTime endTime)
        {
            double bill = 0.0;
            var now = DateTime.Now;
            DateTime startPick = new DateTime(now.Year, now.Month, now.Day, 9, 0, 0);
            DateTime startOffPick = new DateTime(now.Year, now.Month, now.Day, 23, 0, 0);
            while (startTime < endTime)
            {
                double rate = 0.20;
                if ((startTime.TimeOfDay >= startPick.TimeOfDay && startTime.TimeOfDay < startOffPick.TimeOfDay) || (startTime.AddSeconds(20).TimeOfDay >= startPick.TimeOfDay && startTime.AddSeconds(20).TimeOfDay < startOffPick.TimeOfDay))
                    rate = 0.30;
                bill += rate;
                startTime = startTime.AddSeconds(20);
            }
            return bill;
        }
    }
}
