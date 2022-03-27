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
            Console.WriteLine("");
            Console.WriteLine("Analysis results:");
            Console.WriteLine("------------------------------");
            Console.WriteLine("Sentence count | " + output[0]);
            Console.WriteLine("Vowel count | " + output[1]);
            Console.WriteLine("Consonant count | " + output[2]);
            Console.WriteLine("Uppercase letter count | " + output[3]);
            Console.WriteLine("Lowercase letter count | " + output[4]);
            Console.WriteLine("Letter count | " + output[5]);
        }

    }
}
