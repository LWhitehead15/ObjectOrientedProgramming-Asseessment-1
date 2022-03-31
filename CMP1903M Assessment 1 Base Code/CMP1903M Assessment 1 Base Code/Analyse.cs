using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace CMP1903M_Assessment_1_Base_Code
{
    // Abstract class (Abstraction)
    public class Analyse
    {
        //Handles the analysis of text

        //Method: analyseText
        //Arguments: string
        //Returns: list of integers
        //Calculates and returns an analysis of the text

        // Abstract method (Abstraction)
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
            // t.filter allows encapsulated property in other class to be used each time.

            // Encapsulation using class object for filter.
            FilterType t = new FilterType();


            // Sentence count

            // t.filter shows Encapsualtion and keeping variable creation to a minimum.
            t.filter = @"[!?.]\s|[!.?]+";
            Regex rxSentences = new Regex(t.filter);
            MatchCollection matchSentences = rxSentences.Matches(input);
            values[0] = matchSentences.Count;


            // Vowels count


            t.filter = @"([aeiou]){1}";
            Regex rxVowels = new Regex(t.filter);
            MatchCollection matchVowels = rxVowels.Matches(input.ToLower());
            values[1] = matchVowels.Count;


            // Consonants count

            t.filter = @"([bcdfghjklmnpqrstvwxyz]){1}";
            Regex rxConsonants = new Regex(t.filter);
            MatchCollection matchConsonants = rxConsonants.Matches(input.ToLower());
            values[2] = matchConsonants.Count;


            // Uppercase letters count

            t.filter = @"([A-Z]{1})";
            Regex rxUppercase = new Regex(t.filter);
            MatchCollection matchUppercase = rxUppercase.Matches(input);
            values[3] = matchUppercase.Count;


            // Lowercase letters count

            t.filter = @"([a-z]{1})";
            Regex rxLowercase = new Regex(t.filter);
            MatchCollection matchLowercase = rxLowercase.Matches(input);
            values[4] = matchLowercase.Count;


            // letter count found by adding Upper & Lowercase letters.
            values[5] = (values[3] + values[4]);

            
            // Checks for words longer than 7 letters to write to a textfile.
            t.filter = @"([A-Za-z]{7,})";
            Regex rxLongWord = new Regex(t.filter);
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


        // Abstract Method (Abstraction)
        // Creates a dictionary to hold the frequency of characters.

        public IDictionary<string, int> FreqAnalysis(string input)
        {
            IDictionary<string, int> frequency = new Dictionary<string, int>();

            // Retrieves the frequency of each character.

            // i is the index of the Ascii +97 is used to start at the
            // letters lowercase ascii value.

            for (int i = 0; i < 26; i++)
            {
                string letter = @"([" + Convert.ToChar(i + 97).ToString() + "]{1})";
                Regex rxLetter = new Regex(letter);
                // Create a MatchCollection object for the matches of the Regex filter from the input
                MatchCollection matchLetter = rxLetter.Matches(input.ToLower());

                //Only added if there is any instances will it be added
                if (matchLetter.Count > 0)
                {
                    frequency.Add(Convert.ToChar(i + 97).ToString(), matchLetter.Count);
                }
            }

            //For punctuation between ASCII 32 and 65
            for (int i = 32; i < 65; i++)
            {
                string punct = @"([" + Convert.ToChar(i).ToString() + "]{1})";
                Regex rxPunct = new Regex(punct);
                // Create a MatchCollection object for the matches of the Regex filter from the input
                MatchCollection matchPunct = rxPunct.Matches(input.ToLower());

                //Only added if there is any instances will it be added
                if (matchPunct.Count > 0)
                {
                    frequency.Add(Convert.ToChar(i).ToString(), matchPunct.Count);
                }
            }
            return frequency;
        }

    }

    // Encapsulation with properties
    public class FilterType
    {
        public string filter;
        public string Type
        {
            // Get and Set accessors allow filter to be read and write accessbile.
            get
            {
                return filter;
            }
            set
            {
                filter = value;
            }
        }
    }
}
