using System;

namespace EventPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            Counter c = new Counter(new Random().Next(10));
            c.ThresholdReached += c_ThresholdReached;

            Console.WriteLine("press 'a' key to increase total");
            while (Console.ReadKey(true).KeyChar == 'a')
            {
                Console.WriteLine("adding one");
                c.Add(1);
            }
        }

        #region Action when event Happens
        static void c_ThresholdReached(object sender, EventArgs e)
        {
            Console.WriteLine("The threshold was reached.");
            Environment.Exit(0);
        }
        #endregion
    }

    class Counter
    {
        private int threshold;
        private int total;

        public Counter(int passedThreshold)
        {
            threshold = passedThreshold;
        }

        public void Add(int x)
        {
            total += x;

            #region raise an Event
            if (total >= threshold)
            {
                ThresholdReached?.Invoke(this, EventArgs.Empty);
            }

            #endregion
        }
        #region Define Event

        public event EventHandler ThresholdReached;

        #endregion
    }
}





