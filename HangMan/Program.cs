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

        public static bool LetterInWordChecker(char letter, string word)
        {            
            if (word.Contains(letter))
            {
                Console.WriteLine("Your letter is in the word.");
                return true;
            }
            else
            {
                Console.WriteLine("Your letter is not in the word.");
                return false;
                //wrongGuesses++;
            }

        }

        static void Main(string[] args)
        {
            int wrongGuesses = 0;
            int correctGuesses = 0;
            char guessedLetter;

            List<string> wordList = new List<string> {"Banana", "The United Kingdom", "Cow"};

            List<char> guessedLettersList = new List<char>();

            // Pick a random word from the list (stored in winningWord)
            Random random = new Random();
            string winningWord = wordList[random.Next(wordList.Count)];

            // Creating a censored version of the winningWord
            StringBuilder hiddenWord = HideWord(winningWord);

            // Game loop
            while (wrongGuesses < 6)
            {
                Console.Clear();

                Console.WriteLine(winningWord);
                Console.WriteLine(hiddenWord);

                Console.WriteLine("Guess a letter!");

                // Taking the first character of the user's input
                // (!!!) Result may be null if user doesn't input anything, which will crash the program
                guessedLetter = Console.ReadLine()[0];

                // Inform user and register result
                if (guessedLettersList.Contains(guessedLetter))
                {
                    Console.WriteLine("You have already guessed this letter. Please guess a different letter.");
                }
                else if (winningWord.Contains(guessedLetter))
                {
                    Console.WriteLine("Your letter is in the word.");

                    // Replace appropriate underscores with the correct letter
                    for (int i = 0; i < winningWord.Length; i++)
                    {
                        if (guessedLetter == winningWord[i])
                        {
                            hiddenWord.Replace(char.Parse("_"), winningWord[i], i, 1);
                        }
                    }
                    correctGuesses++;
                }
                else
                {
                    Console.WriteLine("Your letter is not in the word.");
                    wrongGuesses++;
                }

                guessedLettersList.Add(guessedLetter);
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