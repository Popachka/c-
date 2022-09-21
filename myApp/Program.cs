using System;
namespace myApp
{
    class Program
    {
        static void Main()
        {
            var stopwatch = new Stopwatch();
            bool flag = false;
            while (true)
            {
                Console.WriteLine("Tap 'y' to start, 'n' to stop, or 'q' to quit.");
                switch (Console.ReadLine())
                {
                    case "y":
                        if (flag == false)
                        {
                            flag = true;
                            Console.WriteLine("start");
                            // Resets *and* starts if necessary
                            stopwatch.Restart();
                        }
                        else
                        {
                            Console.WriteLine("InvalidOperationException.");
                        }

                        break;
                    case "n":
                        Console.WriteLine("stop");
                        if (flag)
                        {
                            flag = false;
                            stopwatch.Stop();
                            stopwatch.getLastTime();
                        }
                        else
                        {
                            Console.WriteLine("InvalidOperationException.");
                        }

                        break;
                    case "q":
                        stopwatch.getHistory();
                        return;
                    default:
                        Console.WriteLine("InvalidOperationException");
                        return;
                }
            }
        }
    }
}
