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

        public static void NewGameState(StringBuilder word)
        {
            Console.Clear();
            Console.WriteLine("The word is: " + word);
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
            string winningWord = wordList[random.Next(wordList.Count)].ToUpper();

            // Creating a censored version of the winningWord
            StringBuilder hiddenWord = HideWord(winningWord);

            // Game start
            NewGameState(hiddenWord);
            Console.WriteLine("Guess a letter!");

            // Game loop
            while (wrongGuesses < 6)
            {
                // Taking the first character of the user's input
                // (!!!) Result may be null if user doesn't input anything, which will crash the program
                guessedLetter = Console.ReadLine().ToUpper()[0];

                // Inform user and register result
                if (guessedLettersList.Contains(guessedLetter))
                {
                    NewGameState(hiddenWord);
                    Console.WriteLine("You have already guessed the letter " + guessedLetter + ". Guess again!");
                }
                else if (winningWord.Contains(guessedLetter))
                {
                    // Replace appropriate underscores with the correct letter
                    for (int i = 0; i < winningWord.Length; i++)
                    {
                        if (guessedLetter == winningWord[i])
                        {
                            hiddenWord.Replace(char.Parse("_"), winningWord[i], i, 1);
                        }
                    }
                    NewGameState(hiddenWord);
                    Console.WriteLine("The letter " + guessedLetter + " is in the word. Guess again!");

                    correctGuesses++;
                }
                else
                {
                    NewGameState(hiddenWord);
                    Console.WriteLine("The letter " + guessedLetter + " is not in the word. Guess again!");
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