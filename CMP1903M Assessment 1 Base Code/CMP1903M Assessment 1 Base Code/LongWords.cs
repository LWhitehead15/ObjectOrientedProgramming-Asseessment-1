using System;
using System.IO;


namespace CMP1903M_Assessment_1_Base_Code
{
	// Handles the ouput of a textfile including all words longer than 7 letters.
	public class LongWords
	{
		public static void WriteFile(List<string> words)
		{

			// Retrieves a user inputted directory.
			Console.WriteLine("\nLong words detected. Processing output file now...");
			string path = Input.SetDirectory();

			// If filepath exists already, it will be deleted and remade.
			if (System.IO.File.Exists(path + "LongWords.txt"))
			{
				System.IO.File.Delete(path + "LongWords.txt");
				File.AppendAllText((path + "LongWords.txt"), string.Join(Environment.NewLine, words));
			}
			else // Filepath will be made.
			{
				File.AppendAllText((path + "LongWords.txt"), string.Join(Environment.NewLine, words));
			}

            Console.WriteLine("\nA textfile can be found at (" + path + "LongWords.txt) \n that includes " + words.Count + " words longer than 7 letters in that input.");
		}
	}
}
