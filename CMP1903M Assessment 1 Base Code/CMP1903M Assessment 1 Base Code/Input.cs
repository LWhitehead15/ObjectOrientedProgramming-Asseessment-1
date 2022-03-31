using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_Assessment_1_Base_Code
{
    public class Input
    {
        //Handles the text input for Assessment 1. Made public.
        public string text = "nothing";
        
        //Method: manualTextInput
        //Arguments: none
        //Returns: string
        //Gets text input from the keyboard
        public string manualTextInput()
        {
            text = Console.ReadLine();

            // Allows * to indicate another line entry.

            while ((text.Length > 0) && (text.EndsWith("*")))
            {
                text = text + " " + Console.ReadLine();
            }

            return text;
        }

        //Method: fileTextInput
        //Arguments: string (the file path)
        //Returns: string
        //Gets text input from a .txt file

        // Reviews mentioned a lack of error checking on the file.
        // Try method and specific error checking added.
        public string fileTextInput(string fileName)
        { 
            //Try used to catch errors.
            try
            {
                if (File.Exists(fileName))
                {
                    //If file is found, read all text within. Function automatically closes file at the end.
                    text = System.IO.File.ReadAllText(fileName);

                    Console.WriteLine("");
                    Console.WriteLine("This is the retrieved text for analysis:");

                    // Displays contents with a limit of 100 characters per line
                    string[] words = text.Split(" ");
                    for (int i = 0; i < words.Length - 1; i++)
                    {
                        Console.Write(words[i] + " ");

                        if (i % 11 == 0 && i > 0)
                        {
                            Console.WriteLine(words[i]);
                        }
                    }
                }

                //If not found, allow retry.
                else
                {
                    Console.WriteLine("File at this address doesn't exist... Check directory/filename for any mistakes.");
                    text = null;

                }
            }
            //Any other error will flag but allow retry. Handled.
            catch (Exception ex)
            {
                Console.WriteLine("The file you are trying to use is already in use or locked... Please check your text file.");
                text = null;
            }
            
            return text;
        }

        // Handles user choice for input.
        public string ChooseEntry()
        {

            // Create boolean valid and string choice variables.
            bool valid = false;
            string choice = "";

            while (valid == false)
            {
                Console.WriteLine("Would you like to analyse entered text (enter 0) or text from a file (enter 1)?: ");
                choice = Console.ReadLine();
                
                //If 0 is entered, manual text entry.
                if (choice == "0")
                {
                    valid = true;
                    Console.WriteLine("Please enter the text for analysis (use a * to end a line and begin a new one): ");
                    text = manualTextInput();
                    //If empty, allow retry.
                    if ((text == "") || (text == null))
                    {
                        Console.WriteLine("No text was entered. Please try again...");
                        valid = false;
                    }
                }
                //If 1 is entered, filepath entry.
                else if (choice == "1")
                {
                    valid = true;
                    Console.WriteLine("Please enter the filepath for textfile analysis: ");
                    text = fileTextInput(Console.ReadLine());
                    //If null, allow retry.
                    if (text == null || text == "")
                    {
                        valid = false;
                    }
                    //If empty, allow retry.
                }
                // Any other input is erroneous.
                else
                {
                    Console.WriteLine("Invalid text/choice entered, please try again...");
                    valid = false;
                }
            }
            return text;

        }

        public static string SetDirectory()
        {
            // ask user where they'd like to put output file.

            Console.WriteLine("Would you like text files stored in the programs directory or a custom one?: (enter 0 for same) (enter 1 for custom)");
            string choice = Console.ReadLine();
            bool valid = false;
            string filepath = "";

            while (valid == false)
            {
                if (choice == "0")
                {
                    filepath = (Directory.GetCurrentDirectory() + "\\"); // Will output to program bin folder
                    valid = true;
                }
                else if (choice == "1") // Will check if directory chosen exists. Will repeat until a suitable option is reached.
                {
                    Console.WriteLine("Please enter the directory letter you would like to use:");
                    filepath = Console.ReadLine().ToUpper();

                    if (filepath.Length == 1 && filepath.All(char.IsLetter) && Directory.Exists(filepath + ":"))
                    {
                        filepath = filepath + ":\\";
                        valid = true;
                    } else
                    {
                        Console.WriteLine("Invalid input detected. Please try again....");
                        valid = false;
                    }
                } else
                {
                    Console.WriteLine("Invalid choice. Please try again...");
                    valid = false;
                }
            }
            return filepath;
        }

    }
}
