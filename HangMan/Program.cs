using System;
using System.Text;
using System.Collections.Generic;

namespace HangMan
{
    class Program
    {
        // Turn all letters in any string into underscores
        //public static StringBuilder HideWord(string word)
        //{
        //    StringBuilder hiddenWord = new StringBuilder();

        //    foreach (char c in word)
        //    {
        //        if (c != char.Parse(" "))
        //        {
        //            hiddenWord.Append("_");
        //        }
        //        else
        //        {
        //            hiddenWord.Append(' ');
        //        }
        //    }
        //    return hiddenWord;
        //}

        static void Main(string[] args)
        {
            int wrongGuesses = 0;
            int guesses = 0;
            string guess;

            List<string> wordList = new List<string> {"Banana", "The United Kingdom", "Cow"};

            // Pick a random word from the list (stored in winningWord)
            Random random = new Random();
            string winningWord = wordList[random.Next(wordList.Count)];

            // Creating a censored version of the winningWord
            StringBuilder hiddenWord = new StringBuilder();

            foreach (char c in winningWord)
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

            // Game loop
            while (wrongGuesses < 3)
            {
                Console.WriteLine(winningWord);
                Console.WriteLine(hiddenWord);

                Console.WriteLine("Guess a letter!");

                // Taking the first character of the user's input
                guess = Console.ReadLine();
                char guessedLetter = guess[0];

                // Replace appropriate underscores with user's guessedLetter
                for (int i = 0; i < winningWord.Length; i++)
			    {
                    if (guessedLetter == winningWord[i])
                    {
                        hiddenWord.Replace(char.Parse("_"), winningWord[i], i, 1);
                    }
			    }

                // Inform user and register result
                if (winningWord.Contains(guessedLetter))
                {
                    Console.WriteLine("Your letter is in the word.");
                }
                else
	            {
                    Console.WriteLine("Your letter is not in the word.");
                    wrongGuesses++;
	            }
            }

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