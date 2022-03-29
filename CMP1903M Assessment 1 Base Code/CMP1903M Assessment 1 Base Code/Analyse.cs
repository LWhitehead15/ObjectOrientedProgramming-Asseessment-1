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
            //6. Number of Letters

            List<int> values = new List<int>();
            //Initialise all the values in the list to '0'
            for (int i = 0; i < 6; i++)
            {
                values.Add(0);
            }

            // For each Regex count, First i define Regex Filter and create Regex object for filter.
            // Next, I create a MatchCollection object for the matches of the Regex filter from the input.
            // Then I Store the matches count into that count's list index in Values list.

            // Sentence count

            string sentences = @"[!?.]\s|[!.?]+";
            Regex rxSentences = new Regex(sentences);
            MatchCollection matchSentences = rxSentences.Matches(input);
            values[0] = matchSentences.Count;


            // Vowels count

            string vowels = @"([aeiou]){1}";
            Regex rxVowels = new Regex(vowels);
            MatchCollection matchVowels = rxVowels.Matches(input.ToLower());
            values[1] = matchVowels.Count;


            // Consonants count

            string consonants = @"([bcdfghjklmnpqrstvwxyz]){1}";
            Regex rxConsonants = new Regex(consonants);
            MatchCollection matchConsonants = rxConsonants.Matches(input.ToLower());
            values[2] = matchConsonants.Count;


            // Uppercase letters count

            string uppercase = @"([A-Z]{1})";
            Regex rxUppercase = new Regex(uppercase);
            MatchCollection matchUppercase = rxUppercase.Matches(input);
            values[3] = matchUppercase.Count;


            // Lowercase letters count

            string lowercase = @"([a-z]{1})";
            Regex rxLowercase = new Regex(lowercase);
            MatchCollection matchLowercase = rxLowercase.Matches(input);
            values[4] = matchLowercase.Count;


            // letter count found by adding Upper & Lowercase letters.
            values[5] = (values[3] + values[4]);

            
            // Checks for words longer than 7 letters to write to a textfile.
            string longWord = @"([A-Za-z]{7,})";
            Regex rxLongWord = new Regex(longWord);
            MatchCollection matchLongWord = rxLongWord.Matches(input);
            List<string> temp = new List<string>();
            foreach (Match match in matchLongWord)
            {
                temp.Add(match.Value);
            }

            if (temp.Count > 0)
            {
                LongWords.WriteFile(temp);
            }

            return values;
        }


        // Creates a dictionary to hold the frequency of letters.

        public IDictionary<string, int> LetterAnalysis(string input)
        {
            IDictionary<string, int> frequency = new Dictionary<string, int>();

            // Retrieves the frequency of each letter. i is the index of the alphabetical
            // letter. +97 is used to relate it to the letters lowercase ascii value.

            for (int i = 0; i < 26; i++)
            {
                string letter = @"([" + Convert.ToChar(i + 97).ToString() + "]{1})";
                Regex rxLetter = new Regex(letter);
                // Create a MatchCollection object for the matches of the Regex filter from the input
                MatchCollection matchLetter = rxLetter.Matches(input.ToLower());

                frequency.Add(Convert.ToChar(i + 97).ToString(), matchLetter.Count);
            }

            return frequency;
        }
    }
}
