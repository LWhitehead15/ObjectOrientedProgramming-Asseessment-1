using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_Assessment_1_Base_Code
{
    class report
    {
        //Handles the reporting of the analysis
        //Maybe have different methods for different formats of output?
        //eg.   public void outputConsole(List<int>)

        public static void outputResult(List<int> output)
        {
            // Reviews highlighted unoptimised output design. Added whitespace Values.

            Console.WriteLine();
            Console.WriteLine("Analysis results:");
            Console.WriteLine("------------------------------");
            Console.WriteLine("{0, -15} {1,0} {2,0}", "Sentence count", " | ", output[0]);
            Console.WriteLine("{0, -15} {1,0} {2,0}", "Vowel count", " | ", output[1]);
            Console.WriteLine("{0, -15} {1,0} {2,0}", "Consonant count", " | ", output[2]);
            Console.WriteLine("{0, -15} {1,0} {2,0}", "Uppercase count", " | ", output[3]);
            Console.WriteLine("{0, -15} {1,0} {2,0}", "Lowercase count", " | ", output[4]);
            Console.WriteLine("{0, -15} {1,0} {2,0}", "Letter count", " | ", output[5]);
        }

        // Outputs the frequency of each character.
        public static void outputFreq(IDictionary<string, int> frequency)
        {

            // Add 65 onto the index to relate to ascii  of uppercase version of
            // letter for output. Add 97 for lowercase version for search.
            for (int i = 0; i < 26; i++)
            {
                if (frequency.ContainsKey(Convert.ToChar(i + 97).ToString()))
                {
                    Console.WriteLine("{0, -5} {1,0} {2,0}", Convert.ToChar(i + 65).ToString(), " | ", frequency[Convert.ToChar(i + 97).ToString()]);
                }
            }

            //For punctuation between ASCII 32 and 65
            for (int i = 32; i < 65; i++)
            {
                if (frequency.ContainsKey(Convert.ToChar(i).ToString()))
                {
                    Console.WriteLine("{0, -5} {1,0} {2,0}", Convert.ToChar(i).ToString(), " | ", frequency[Convert.ToChar(i).ToString()]);
                }
            }
        }
    }
}
