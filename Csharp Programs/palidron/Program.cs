using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace palidron
{
    class Program
    {
        static bool palidron(string x)
        {
            if(x.Length%2 == 0)
            {
                string temp1 = x.Substring(0, x.Length / 2), temp2 = x.Substring(x.Length / 2, x.Length / 2); char [] temp3 = temp2.ToArray();
                int z = 0;
                for (int y = temp2.Length-1 ; y>=0; y-- )
                {
                    temp3[z] = temp2[y];
                    z++;

                }
                temp2 = new string(temp3);
                if (temp1 == temp2)
                    return true;
                else return false;
            }
            else
            {
                string temp1 = x.Substring(0, (x.Length / 2)), temp2 = x.Substring((x.Length / 2+1), (x.Length/2)); char[] temp3 = temp2.ToArray();
                int z = 0;
                for (int y = temp2.Length - 1; y >= 0; y--)
                {
                    temp3[z] = temp2[y];
                    z++;

                }
                temp2 = new string(temp3);
                if (temp1 == temp2)
                    return true;
                else return false;
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine(palidron("racecar") );
            Console.WriteLine(palidron("abba"));
            Console.WriteLine(palidron("steven"));
            Console.Read();
        }
    }
}
