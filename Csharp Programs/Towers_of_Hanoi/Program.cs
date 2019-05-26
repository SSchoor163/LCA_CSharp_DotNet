using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Towers_of_Hanoi
{
    
    class Program
    {
       static Dictionary<char, Stack<int>> towers = new Dictionary<char, Stack<int>>();
        static void Main(string[] args)
        {
            towers.Add('A', new Stack<int> { });
            for (int x = 4; x == 0; x--)
            {
                towers['A'].Push(x);
            }
            towers.Add('B', new Stack<int> { });
            towers.Add('C', new Stack<int> { });

            Console.WriteLine("Towers of Hanoi");
            Console.Write("Rules: You must get each number in tower A into tower C\n" +
                          "You may move only one number at a time, and a higher number can not sit atop a lower number.\n");

        }
        static void printboard()
        {

        }
        static bool victoryConditions()
        {
            return false;
        }
    }
    
}
