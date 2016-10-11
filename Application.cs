using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace Ulam
{
    internal class Application
    {
        public static Application Instance;
        private int _lenght = 1;
        private int _turns;
        private int donePath;
        private int x;
        private int y;

        static Application()
        {
            Instance = new Application();
        }

        public void Run()
        {
            Console.Title = "Ulam Spiral by MrBrenan - 2016";
            Console.SetWindowSize(60, 60); //Set size

            x = Console.WindowWidth/2;
            y = Console.WindowHeight/2;

            var max = Console.WindowHeight*Console.WindowWidth;
            for (var i = 1; i < max + 1; i++)
            {
                Console.SetCursorPosition(x, y);
                if (IsPrime(i))
                    Console.ForegroundColor = ConsoleColor.Red;
                else
                    Console.ForegroundColor = ConsoleColor.Blue;

                Console.Write("▓");
                FindNext();

                Thread.Sleep(25); //Set speed
            }
            Console.ReadKey();
        }

        private bool IsPrime(float n)
        {
            var divisors = new List<int>();
            divisors.Clear();

            for (float i = 1; i <= Math.Sqrt(n); i++)
            {
                if (n/i == (int) (n/i))
                {
                    divisors.Add((int) i);
                    divisors.Add((int) (n/i));
                }
            }

            if (divisors.Count == 2 && n != 1)
                return true;
            return false;
        }

        private void FindNext()
        {
            switch (_turns)
            {
                case 0:
                    y++;
                    break;

                case 1:
                    x--;
                    break;

                case 2:
                    y--;
                    break;

                case 3:
                    x++;
                    break;
            }

            donePath++;

            if (donePath >= _lenght)
            {
                _turns = Increment(_turns, 3);
                Debug.WriteLine("turn = " + _turns);
                donePath = 0;

                if (_turns == 0 || _turns == 2)
                    _lenght++;
            }
        }

        private int Increment(int actual, int limit)
        {
            var ret = actual;
            ret++;
            if (ret > limit)
                ret = 0;

            return ret;
        }
    }
}