using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace whiteboard_bubblesort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] unsortedScores = { 37, 89, 41, 65, 91, 53, 77, 69, 100, 90, 44, 83, 21, 49, 75 };
            int swap, passes = 0; bool fin = true;
            while (fin)
            {
                passes++;
                for (int x = 0; x<unsortedScores.Length-1; x++)
                    if(unsortedScores[x]> unsortedScores[x + 1])
                    {
                        swap = unsortedScores[x];
                        unsortedScores[x] = unsortedScores[x + 1];
                        unsortedScores[x + 1] = swap;
                    }
                for(int x = 0; x < unsortedScores.Length-1; x++)
                {
                    if (unsortedScores[x] > unsortedScores[x + 1])
                    {
                        break;
                    }
                    else if (x < (unsortedScores.Length - 2)) continue;
                    else fin = false;
                    
                }
            }
            for(int x = 0; x<unsortedScores.Length; x++)
            Console.WriteLine(unsortedScores[x]);
            Console.WriteLine("passes: " + passes);
            Console.Read();
    }
        }
    }

