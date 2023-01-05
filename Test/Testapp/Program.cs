using System;
using System.Timers;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Testapp
{
    public class Frequency
    {
        public int number;
        public int freq;

        public Frequency(int input)
        {
            number = input;
            freq = 1;
        }
        public void increment()
        {
            freq = freq + 1;
        }
        public  int getN()
        {
            return number;
        }
        public int getF()
        {
            return freq;
        }
    }

    class Program
    {
        public static List<Frequency> numberfrequency = new List<Frequency>() { };// list of frequency 
        public static System.Timers.Timer aTimer = new System.Timers.Timer(); // Timer 
        public static Boolean run = true; // global run condition
        public static int[] Fibonacci(int numElement)// Fibonaci sequence for the first 1000
        {
            var n = numElement + 1; //you need n+1 positions. The 9th number is in 10th position
            var a = new int[n];
            a[0] = 0;
            a[1] = 1;

            for (var i = 2; i < n; i++)
                a[i] = a[i - 2] + a[i - 1];

            return a;
        }



        static void Main(string[] args)
        {
                        
            Console.WriteLine(">> Please input the amount of time in seconds between emitting numbers and thier frequency");
            SetTimer(Convert.ToInt32(Console.ReadLine()));//input for timer
            Console.WriteLine(">> Please enter the first number");
            numberfrequency.Add(new Frequency((Convert.ToInt32(Console.ReadLine()))));
            aTimer.Start();
            while (run);//quit conditon
            Display();
            aTimer.Stop();
            Console.WriteLine(">> Thanks for playing, press any key to exit.");
        }

        private static void Stop()
        {
            Console.WriteLine(">> timer halted");
            aTimer.Stop();
            if ((Console.ReadLine())== ("resume"))
            {
                Console.WriteLine(">> timer resume");
                aTimer.Start();            
            }
        }

        private static void SetTimer(int intervals)
        {
            // Create a timer converting to second instead of milliseconds
            aTimer = new System.Timers.Timer(intervals * 1000);
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;
        }

        private static void NumInput(int input)
        {
            Boolean found = false;//if value is in list
            foreach (var k in numberfrequency)// loop through list
            {
                if (input == (k.getN()))
                {
                    found = true;
                    k.increment();//increment
                }

            }
            if (found == false)
            {
                numberfrequency.Add(new Frequency(input));//adding new frequency
            }
            Display();
        }

        private static void Display()
        {
            //sorting list
            Console.Write(">> ");
            if ((numberfrequency.Count) > 1)//common are a bitch no need to sort
            {
                List<Frequency> SortedList = numberfrequency.OrderByDescending(o => o.number).ToList();
                foreach (var k in SortedList)//display list
                {
                    Console.Write("{0}:{1}, ", k.getN(), k.getF());
                }
            }
            else
            {
                Console.Write("{0}:{1} ", numberfrequency[0].getN(), numberfrequency[0].getF());
            }
            Console.WriteLine();
        }

        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            Sequence(); 
        }
        private static void Sequence()
        {
           
            Console.WriteLine(">> Please enter the next number");
            string input = Console.ReadLine();//reading as commnad
            int[] array = Fibonacci(1000);//first 1000 number of the fibonacci sequence
            if(input == "quit")
            {
                run = false;
            }
            if (input == ("halt"))
            {
                Stop();
                return;
            }
            //
            int number = Convert.ToInt32(input);//reading as input
            foreach (int i in array)// checking fib sequence
            {
                if (number == i)
                {
                    Console.WriteLine(">> Fib");
                    
                }
                
            }
            NumInput(number);//

        }

    }
}
