using System;

namespace LinearSearch
{

    /// <summary>
    /// Demonstrates a linear search on an array of strings
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = { "the", "quick", "brown", "fox", "jumps", "over", "the", "lazy", "dog" };
            int location;

            Console.WriteLine("String array to be searched:");
            DisplayArray(words);

            location = LinearSearch(words, "the");
            OutputSearchResult(location, "the");

            location = LinearSearch(words, "fox");
            OutputSearchResult(location, "fox");

            location = LinearSearch(words, "zebra");
            OutputSearchResult(location, "zebra");

            ExitPrompt();
        }

        /// <summary>
        /// String-based linear search (finds a string in an array of strings)
        /// </summary>
        /// <param name="words">Array of strings to be searched</param>
        /// <param name="word">The string being searched</param>
        /// <returns>Index of word in words if it exists, -1 otherwise</returns>
        public static int LinearSearch(string[] words, string word)
        {
            // TODO: Search code goes here...
            int pos = -1;
            int n = words.Length;
            for (int i = 0; i < n; i++)
            {
                if (words[i] == word)
                {
                    pos = i;
                    break;
                }//end if
            }//end for
            return pos;
        }

        /// <summary>
        /// Displays the elements of a string array
        /// </summary>
        /// <param name="words">String array to be displayed</param>
        static void DisplayArray(string[] words)
        {
            foreach (string element in words)
            {
                Console.Write("\t" + element + "\n");
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Displays the outcome of the linear search
        /// </summary>
        /// <param name="pos">The index of the string if it was found, -1 otherwise</param>
        /// <param name="word">The string being searched</param>
        static void OutputSearchResult(int pos, string word)
        {
            if (pos < 0)
            {
                Console.WriteLine($"The word \"{word}\" not found in the list\n ");
            }
            else
            {
                Console.WriteLine($"The word \"{word}\" found in position {pos} of the array\n");
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.WriteLine();

        }

        /// <summary>
        /// Prompts the user to exit the program
        /// </summary>
        static void ExitPrompt()
        {
            Console.WriteLine("Press any key to exit program...");
            Console.ReadKey();
        }
    }
}