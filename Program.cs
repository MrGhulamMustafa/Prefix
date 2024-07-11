using System;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            void Pre()
            {
                // Taking array of string elements from user.
                Console.Write("Enter space-separated strings >> ");
                string[] str = Console.ReadLine().Split(" ");

                if (str.Length == 0)
                {
                    Console.WriteLine("No strings entered.");
                    return;
                }

                // Convert all strings to lowercase
                for (int i = 0; i < str.Length; i++)
                {
                    str[i] = str[i].ToLower();
                }

                // Find the shortest string in the array
                int minLength = str[0].Length;
                foreach (string s in str)
                {
                    if (s.Length < minLength)
                    {
                        minLength = s.Length;
                    }
                }

                // Find the longest common prefix
                string prefix = "";
                for (int i = 0; i < minLength; i++)
                {
                    char currentChar = str[0][i];
                    bool allMatch = true;

                    for (int j = 1; j < str.Length; j++)
                    {
                        if (str[j][i] != currentChar)
                        {
                            allMatch = false;
                            break;
                        }
                    }

                    if (allMatch)
                    {
                        prefix += currentChar;
                    }
                    /*else
                    {
                        break;
                    }*/
                }

                // If there exists a common prefix
                if (prefix.Length > 0)
                {
                    Console.WriteLine("Longest common prefix: " + prefix);
                }
                // If there is no common prefix
                else
                {
                    Console.WriteLine("There is no common prefix.");
                }
            }

            Pre();
        }
    }
}
