using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace CMP1903M_Assessment_1_Base_Code
{
    public class Analyse
    {
        //Handles the analysis of text

        //Method: analyseText
        //Arguments: string
        //Returns: list of integers
        //Calculates and returns an analysis of the text
        public List<int> analyseText(string input)
        {
            //List of integers to hold the first five measurements:
            //1. Number of sentences
            //2. Number of vowels
            //3. Number of consonants
            //4. Number of upper case letters
            //5. Number of lower case letters
            List<int> values = new List<int>();
            //Initialise all the values in the list to '0'
            for (int i = 0; i < 6; i++)
            {
                values.Add(0);
            }

            // Sentence count

            // Define Regex Filter and create Regex object for filter
            string sentences = @"[.]\s{1}|[.*]+";
            Regex rxSentences = new Regex(sentences);
            // Create a MatchCollection object for the matches of the Regex filter from the input
            MatchCollection matchSentences = rxSentences.Matches(input);
            // Stores the matches (sentences) count into values list first index
            values[0] = matchSentences.Count;


            // Vowels count

            // Define Regex Filter and create Regex object for filter
            string vowels = @"([AEIOUaeiou]){1}";
            Regex rxVowels = new Regex(vowels);
            // Create a MatchCollection object for the matches of the Regex filter from the input
            MatchCollection matchVowels = rxVowels.Matches(input);
            values[1] = matchVowels.Count;


            // Consonants count

            // Define Regex Filter and create Regex object for filter
            string consonants = @"([bcdfghjklmnpqrstvwxyzBCDFGHJKLMNPQRSTVWXYZ]){1}";
            Regex rxConsonants = new Regex(consonants);
            // Create a MatchCollection object for the matches of the Regex filter from the input
            MatchCollection matchConsonants = rxConsonants.Matches(input);
            values[2] = matchConsonants.Count;


            // Uppercase letters count

            // Define Regex Filter and create Regex object for filter
            string uppercase = @"([ABCDEFGHIJKLMNOPQRSTUVWXYZ]{1})";
            Regex rxUppercase = new Regex(uppercase);
            // Create a MatchCollection object for the matches of the Regex filter from the input
            MatchCollection matchUppercase = rxUppercase.Matches(input);
            values[3] = matchUppercase.Count;


            // Lowercase letters count

            // Define Regex Filter and create Regex object for filter
            string lowercase = @"([abcdefghijklmnopqrstuvwxyz]{1})";
            Regex rxLowercase = new Regex(lowercase);
            // Create a MatchCollection object for the matches of the Regex filter from the input
            MatchCollection matchLowercase = rxLowercase.Matches(input);
            values[4] = matchLowercase.Count;


            // letter count
            values[5] = (values[3] + values[4]);


            return values;
        }
    }
}
