using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Create_fibinaci_numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 1, b = 2, total = 2;
            while(a < 4000000 && b < 4000000)
            {
                Console.Write($"{a} {b} ");
                int temp = a;
                a = a+b;
                b += a;
                if (a % 2 == 0) total += a;
                if (b % 2 == 0) total += b;
            }
            Console.WriteLine($"Even total is {total}");
            Console.Read();
        }
    }
}
