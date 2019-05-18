using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pig_Latin_Translator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter a word to be translated");
            string translateWork = Console.ReadLine();
            translateWork = translateWork.ToLower();
            Console.WriteLine( pigLatin(translateWork));
            Console.ReadLine();

            


        }

        static string pigLatin(string original)
        {
            String[] vowels = new string[5] { "a", "e", "i", "o", "u" };
            
                if(vowels.Any(x => original.StartsWith(x)) && vowels.Any(x => original.EndsWith(x)))
                {
                    original += "yay";
                    return original;
                }
                else if(vowels.Any(x => original.StartsWith(x)) && !vowels.Any(x=> original.EndsWith(x)))
                {
                    original += "ay";
                    return original;
                }
                else if (!(vowels.Any(x => original.Contains(x))))
                {
                original += "ay";
                return original;
                }
                else if(vowels.Any(x => original.Contains(x)) && !(vowels.Any(x => original.StartsWith(x))))               
                {
                    string hold = original;
                    while(!vowels.Any(x => hold.StartsWith(x))){
                        hold += hold.ElementAt(0);
                        hold = hold.Remove(0, 1);

                    }
                    hold += "ay";
                    original = hold;
                    return original;
                }

            return "fail state";



        }
    }
}
