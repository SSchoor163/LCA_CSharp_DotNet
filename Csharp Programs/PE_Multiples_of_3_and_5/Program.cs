using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE_Multiples_of_3_and_5
{
    class Program
    {
        static void Main(string[] args)
        {
            int total = 0;
            for(int x = 0; x<1000; x++)
            {
                if(x%3 == 0)
                { total += x; }
                else if(x%5 == 0)
                {
                    total += x;
                }
               
            }
            Console.WriteLine(total);
            Console.Read();
        }
    }
}
