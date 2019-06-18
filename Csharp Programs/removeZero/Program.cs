using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace removeZero
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 0, 1, 0, 3, 12 };
            int x = 0;
            while(x <= arr.Count()-1)
            {
                if (arr[x] == 0)
                {
                    for (int y = x; y < arr.Count(); y++)
                    {
                        if (y != arr.Count()-1) arr[y] = arr[y + 1];
                        else arr[y] = 0;
                    }

                }
                x++;
            }
            foreach(int z in arr)
            {
                Console.WriteLine(z);
            }
            Console.Read();
        }
    }
}
