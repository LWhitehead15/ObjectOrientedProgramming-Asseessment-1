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

            //Create 'Input' object, valid integer and text string.
            Input Input = new Input();
            int valid = 0;
            string text = "";

            while (valid == 0)
            {
                //Get either manually entered text, or text from a file
                Console.WriteLine("Would you like to analyse entered text (enter 0) or text from a file (enter 1)?: ");
                string choice = Console.ReadLine();
            
                if (choice == "0")
                {
                    valid = 1;
                    Console.WriteLine("Please enter the text for analysis: ");
                    text = Input.manualTextInput();
                    if (text == "")
                    {
                        Console.WriteLine("No text was entered. Please try again...");
                        valid = 0;
                    }
                }
                else if (choice == "1")
                {
                    valid = 1;
                    Console.WriteLine("Please enter the filepath for textfile analysis: ");
                    text = Input.fileTextInput(Console.ReadLine());
                    if (text == "")
                    {
                        Console.WriteLine("Text file is empty/path is invalid. Please try again...");
                        valid = 0;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid text/choice entered, please try again...");
                    valid = 0;
                }
            }

            //Create an 'Analyse' object
            //Pass the text input to the 'analyseText' method
            Analyse Analyse = new Analyse();

            //Receive a list of integers back
            //Report the results of the analysis

            report report = new report();

            report.outputResult(Analyse.analyseText(text));


            //TO ADD: Get the frequency of individual letters?


        }
        
        
    
    }
}
