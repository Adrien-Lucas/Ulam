using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Application
    {
        public static Application Instance;
        private int _turns;
        private int x = 30;
        private int y = 30;
        private int donePath;
        private int _lenght = 1;

        static Application()
        {
            Instance = new Application();
        }

        public void Run()
        {
            Console.SetWindowSize(60, 60);

            int max = Console.WindowHeight * Console.WindowWidth;
            for (int i = 1; i < max+1; i++)
            {
                Console.SetCursorPosition(x,y);
                if(IsPrime(i))
                    Console.ForegroundColor = ConsoleColor.Red;
                else
                    Console.ForegroundColor = ConsoleColor.Blue;

                Console.Write("▓");
                FindNext();

                Thread.Sleep(20);
            }
            Console.ReadKey();
        }

        bool IsPrime(float n)
        {
            List<int> divisors = new List<int>();
            divisors.Clear();

            for (float i = 1; i <= Math.Sqrt(n); i++)
            {
                if((float)(n/i) == (int)(n/i))
                {
                    divisors.Add((int)i);
                    divisors.Add((int)(n/i));
                }
            }

            if (divisors.Count == 2)
                return true;
            else
                return false;
        }

        void FindNext()
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

        int Increment(int actual, int limit)
        {
            int ret = actual;
            ret++;
            if (ret > limit)
                ret = 0;

            return ret;
        }
    }
}
