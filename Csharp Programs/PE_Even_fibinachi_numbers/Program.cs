using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE_Even_fibinachi_numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 1, b = 2, total = 0;
            while (a <= 4000000|| b <= 4000000)
            {
                if (a % 2 == 0)
                    total += a;
                else if (b % 2 == 0)
                    total += b;
                a = a + b;
                b = b + a;
                
            }
            Console.WriteLine(total);
            Console.Read();
        }
    }
}
