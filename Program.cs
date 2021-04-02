using System;
using System.Collections.Generic;

namespace PigLatin2
{
    class Program
    {
        public static List<string> wordList = new List<string>();

        static void Translator(string word, int firstVowel)
        {
            if (firstVowel < 0)
            {
                Console.Write($"{word}ay ");
            }
            else if (firstVowel == 0)
            {
                Console.Write($"{word}way ");
            }
            else
            {
                Console.Write($"{word.Substring(firstVowel)}{word.Substring(0, firstVowel)}ay ");
            }
        }

        static void InputSeperator(string sentence)
        {
            string[] temp = sentence.Split();

            foreach (string word in temp)
            {
                wordList.Add(word);
            }
        }
        static void Main(string[] args)
        {
            bool loop = true;
            string input;
            int firstVowel = -1;

            Console.Write($"Welcome to the Pig Latin Translator!\n\n");

            do
            {
                Console.Write($"Enter a line to be translated: ");
                input = Console.ReadLine();

                input = input.ToLower();

                InputSeperator(input);

                Console.WriteLine();


                foreach (string word in wordList)
                {
                    bool hasNonLetter = CheckForNonLetter(word);

                    if (hasNonLetter == false)
                    {

                        firstVowel = FindVowel(word);
                        Translator(word, firstVowel);
                    }
                    else
                    {
                        Console.Write($"{word} ");
                    }

                }

                loop = ContinueYN();

                wordList.Clear();
            } while (loop);
        }

        static bool CheckForNonLetter(string word)
        {
            bool nonLetter = false;

            foreach (char letter in word)

            {
                if (char.IsSymbol(letter) || char.IsDigit(letter) || letter == ' ')
                {
                    nonLetter = true;
                }
            }

            return nonLetter;
        }
        static void InvalidMessages(int error)
        {
            switch (error)
            {
                case 1:
                    Console.Write($"\n\nThat was not a valid answer.\nPlease enter either y or n: ");

                    break;


            }
        }
        static bool ContinueYN()
        {
            bool loopAgain = true;

            string input;

            bool notvalid = true;

            do
            {
                Console.Write($"\n\nTranslate another line? (y/n): ");
                input = Console.ReadLine().ToLower();

                if (input != "y" && input != "n")
                {
                    InvalidMessages(1);
                }
                else
                {
                    notvalid = false;

                    if (input == "n")
                    {
                        loopAgain = false;
                    }
                }
            } while (notvalid);

            return loopAgain;

        }

        static int FindVowel(string word)
        {
            int vowelIndex = -1;


            for (int i = 0; i < word.Length; i++)

            {
                if (word[i] == 'a' || word[i] == 'e' || word[i] == 'i' || word[i] == 'o' || word[i] == 'u')
                {
                    vowelIndex = i;
                    return vowelIndex;
                }
            }


            return vowelIndex;
        }
    }
}
