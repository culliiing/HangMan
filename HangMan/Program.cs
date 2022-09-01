using System;
using System.Text;
using System.Collections.Generic;

namespace HangMan
{
    class Program
    {
        // Turn all letters in any string into underscores
        public static StringBuilder HideWord(string word)
        {
            StringBuilder hiddenWord = new StringBuilder();

            foreach (char c in word)
            {
                if (c != char.Parse(" "))
                {
                    hiddenWord.Append("_");
                }
                else
                {
                    hiddenWord.Append(' ');
                }
            }
            return hiddenWord;
        }

        static void Main(string[] args)
        {
            int wrongGuesses = 0;

            List<string> wordList = new List<string> {"Banana", "The United Kingdom", "Something"};

            // Pick a random word from the list (stored in winningWord)
            Random random = new Random();
            string winningWord = wordList[random.Next(wordList.Count)];

            Console.WriteLine(winningWord);
            Console.WriteLine(HideWord(winningWord));


            //Console.WriteLine("Guess a letter!");
            //Console.WriteLine(HideWord(winningWord));

            //while (wrongGuesses <= 6)
            //{
            //    string guess = Console.ReadLine();
            //    char guessedLetter = char.Parse(guess);

            //    for (int i = 0; i < winningWord.Length; i++)
            //    {
                  
            //        if (winningWord[i] == guessedLetter)
            //        {
            //            hiddenWord.Replace(char.Parse("_"), guessedLetter, i, 1);
            //            Console.WriteLine("hello?");
            //            hit = true;
            //        }
            //        else if (winningWord[i] != guessedLetter && hit != true)
            //        {
            //            Console.WriteLine("Letter" + guessedLetter + "is not in the word.");
            //            wrongGuesses++;
            //            Console.WriteLine("you have guessed " + wrongGuesses + " times");
            //        }
            //        hit = false;
                    
            //    }

            //}

            Console.WriteLine("The Program is Over");
            Console.ReadKey();
        }
    }
}