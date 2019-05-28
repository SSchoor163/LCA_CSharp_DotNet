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
            Dictionary<string, int> test = new Dictionary<string, int>();
            test.Add("test1", 5);
            test.Add("test1", 3);
            foreach(string name in test.Keys)
                Console.WriteLine(test[name]);
            Console.Read();
        }
    }
}
