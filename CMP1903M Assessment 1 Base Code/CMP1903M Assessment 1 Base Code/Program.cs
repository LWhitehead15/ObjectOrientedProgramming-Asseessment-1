//Base code project for CMP1903M Assessment 1
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_Assessment_1_Base_Code
{
    class Program
    {
        
        static void Main()
        {


            //Local list of integers to hold the first five measurements of the text
            List<int> parameters = new List<int>();

            //Create 'Input' object, valid Boolean, text & choice string.
            Input Input = new Input();
            bool valid = false;
            string text = "";
            string choice = "";

            Console.WriteLine("Text Analyser by Liam Whitehead (ID: 25698752)");


            //Get either manually entered text, or text from a file.
            //The choice is programmed in the input class.
            text = Input.ChooseEntry();


            //Create an 'Analyse' object
            //Pass the text input to the 'analyseText' method
            Analyse Analyse = new Analyse();

            //Receive a list of integers back
            //Report the results of the analysis

            report report = new report();
            report.outputResult(Analyse.analyseText(text));



            //Get the frequency of individual letters.
            // Reuse valid variable.
            valid = false;

            while (valid == false)
            {
                Console.WriteLine();
                Console.WriteLine("Would you like to see the frequency of each letter? (Enter 0 for Yes) (Enter 1 for no): ");
                choice = Console.ReadLine();

                if (choice == "0")
                {
                    report.outputLetters(Analyse.LetterAnalysis(text));
                    valid = true;
                }
                else if (choice == "1")
                {
                    valid = true;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please try again...");
                    valid = false;
                }
            }


            // Ask the user if they want to rerun application.
            valid = false;
            while (valid == false)
            {
                Console.WriteLine("Would you like to rerun the application? (Enter 0 for yes) (Enter 1 for no):");
                choice = Console.ReadLine();

                if (choice == "0")
                {
                    Console.Clear();
                    Main();
                    Environment.Exit(0);
                }
                else if (choice == "1")
                {
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Invalid input. Please try again...");
                    valid = false;
                }
            }
        }
        
        
    
    }
}
