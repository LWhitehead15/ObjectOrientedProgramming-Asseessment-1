using System;
using System.IO;


namespace CMP1903M_Assessment_1_Base_Code
{
	// Handles the ouput of a textfile including all words longer than 7 letters.
	public class LongWords
	{
		public static void WriteFile(List<string> words)
		{
			// File path for textfile.
			string path = @"C:\Users\liamt\Documents\LongWordOutput.txt";

			// If it exists already, it will be deleted and remade.
			if (System.IO.File.Exists(path))
			{
				System.IO.File.Delete(path);
				File.AppendAllText(path, string.Join(Environment.NewLine, words));
			}
			else
			{
				File.AppendAllText(path, string.Join(Environment.NewLine, words));
			}

			Console.WriteLine("\n Long words detected. A textfile can be found at (" + path + ") \n that includes all words longer than 7 letters in that input.");
		}
	}
}
