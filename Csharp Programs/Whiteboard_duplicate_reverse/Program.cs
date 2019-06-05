using System;
using System.Linq;

namespace Whiteboard_duplicate_reverse
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] MyArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Console.Write("Array: ");
            for (int x = 0; x < MyArray.Length; x++)
            {
                Console.Write(MyArray[x]);
            }
            Console.WriteLine("\nDuplicate array: " + Duplicate(MyArray)+ "\n");
            Console.WriteLine("Reverse array: " +Reverse(MyArray));
            Console.Read();

        }

        static string Duplicate(int[] x)
        {
            
            string final = "";
            for (int y = 0; y < x.Length * 2; y++)
            {
                if (y < 9)
                    final+= x[y].ToString();
                else final+=x[y - x.Length].ToString();
            }
            return final;
        }
        static string Reverse(int[] x)
        {
            string final = "";
            for(int y = x.Length-1; y>=0; y--)
            {
                final += x[y];
            }
            return final;
        }
    }
}
