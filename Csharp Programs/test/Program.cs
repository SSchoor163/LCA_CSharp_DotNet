using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] x = { 5, 6, 7, 8, 9, 10 };
            foreach(int y in x)
            {
                Console.WriteLine(x[y]);
            }
            Console.Read();
        }
    }
}
