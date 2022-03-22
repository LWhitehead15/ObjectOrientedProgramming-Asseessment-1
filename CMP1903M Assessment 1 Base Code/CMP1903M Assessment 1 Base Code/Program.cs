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

            //Create 'Input' object
            Input Input = new Input();

            //Get either manually entered text, or text from a file
            Console.Write("Would you like to analyse entered text (enter 0) or text from a file (enter 1)?: ");
            int choice = Console.ReadLine();

            if choice == 0
            {
            Console.Write("Please enter the text for analysis: ");
            string text = Input.manualTextInput(Console.ReadLine());
            }
            //Create an 'Analyse' object
            //Pass the text input to the 'analyseText' method


            //Receive a list of integers back


            //Report the results of the analysis


            //TO ADD: Get the frequency of individual letters?

           
        }
        
        
    
    }
}
