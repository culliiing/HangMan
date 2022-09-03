using System;
using System.Text;
using System.Collections.Generic;

namespace HangMan
{
    class Program
    {
        public static void DrawGraphics(int stage)
        {
            if (stage >= 6)
            {
                Console.WriteLine("########");
                Console.WriteLine("#     | ");
                Console.WriteLine("#     O/");
                Console.WriteLine("#    /I ");
                Console.WriteLine("#    // ");
                Console.WriteLine("#_______");
            }
            else if (stage == 5)
            {
                Console.WriteLine("########");
                Console.WriteLine("#     | ");
                Console.WriteLine("#     O/");
                Console.WriteLine("#    /I ");
                Console.WriteLine("#    /  ");
                Console.WriteLine("#_______");
            }
            else if (stage == 4)
            {
                Console.WriteLine("########");
                Console.WriteLine("#     | ");
                Console.WriteLine("#     O/");
                Console.WriteLine("#    /I ");
                Console.WriteLine("#       ");
                Console.WriteLine("#_______");
            }
            else if (stage == 3)
            {
                Console.WriteLine("########");
                Console.WriteLine("#     | ");
                Console.WriteLine("#     O ");
                Console.WriteLine("#    /I ");
                Console.WriteLine("#       ");
                Console.WriteLine("#_______");
            }
            else if (stage == 2)
            {
                Console.WriteLine("########");
                Console.WriteLine("#     | ");
                Console.WriteLine("#     O ");
                Console.WriteLine("#     I ");
                Console.WriteLine("#       ");
                Console.WriteLine("#_______");
            }
            else if (stage == 1)
            {
                Console.WriteLine("########");
                Console.WriteLine("#     | ");
                Console.WriteLine("#     O ");
                Console.WriteLine("#       ");
                Console.WriteLine("#       ");
                Console.WriteLine("#_______");
            }
            else if (stage <= 0)
            {
                Console.WriteLine("########");
                Console.WriteLine("#     | ");
                Console.WriteLine("#       ");
                Console.WriteLine("#       ");
                Console.WriteLine("#       ");
                Console.WriteLine("#_______");
            }
        }

        // Turn all letters in any string into underscores
        public static StringBuilder HideWord(string word)
        {
            StringBuilder hiddenWord = new StringBuilder();

            foreach (char c in word)
            {
                if (c == char.Parse(" "))
                {
                    hiddenWord.Append(" ");
                }
                else if (c == char.Parse("-"))
                {
                    hiddenWord.Append("-");
                } 
                else
                {
                    hiddenWord.Append("_");
                }
            }
            return hiddenWord;
        }

        public static void NewGameState(string word, int stage)
        {
            Console.Clear();
            DrawGraphics(stage);
            Console.WriteLine("The word is: " + word);
        }

        static void Main(string[] args)
        {
            int wrongGuesses = 0;
            char guessedLetter;
            string guess;

            List<string> wordList = new() {"Banana", "Mother-in-law", "Cow", "High School"};
            List<char> guessedLettersList = new();
            List<string> guessesList = new();

            // Pick a random word from the wordList
            Random random = new Random();
            string winningWord = wordList[random.Next(wordList.Count)].ToUpper();

            // Creating a censored version of the winningWord
            StringBuilder hiddenWord = HideWord(winningWord);

            // Game start
            NewGameState(hiddenWord.ToString(), wrongGuesses);
            Console.WriteLine("Guess a letter! You may also guess the exact word if you have ");

            // Game loop
            while (wrongGuesses < 6 && hiddenWord.ToString().Contains("_") == true)
            {
                // (!!!) Result may be null if user doesn't input anything, which will crash the program (FIX LATER.)
                guess = Console.ReadLine().ToUpper();
                guessedLetter = guess[0];

                // Inform user and register result of the guess
                if (guess.Length > 1 && guessesList.Contains(guess))
                {
                    NewGameState(hiddenWord.ToString(), wrongGuesses);
                    Console.WriteLine("You have already guessed the word '" + guess + "'. Guess again!");
                }
                else if (guess == winningWord)
                {
                    break;
                }
                else if (guess.Length > 1)
                {
                    wrongGuesses++;
                    NewGameState(hiddenWord.ToString(), wrongGuesses);
                    Console.WriteLine("'" + guess + "'" + " is not the word. Guess again!");
                    guessesList.Add(guess);
                }
                else if (guessedLettersList.Contains(guessedLetter))
                {
                    NewGameState(hiddenWord.ToString(), wrongGuesses);
                    Console.WriteLine("You have already guessed the letter " + guessedLetter + ". Guess again!");
                }
                else if (winningWord.Contains(guessedLetter))
                {
                    // Replace appropriate underscores with the guessedLetter
                    for (int i = 0; i < winningWord.Length; i++)
                    {
                        if (guessedLetter == winningWord[i])
                        {
                            hiddenWord.Replace(char.Parse("_"), winningWord[i], i, 1);
                        }
                    }

                    NewGameState(hiddenWord.ToString(), wrongGuesses);
                    Console.WriteLine("The letter " + guessedLetter + " is in the word. Guess again!");
                    guessedLettersList.Add(guessedLetter);
                }
                else
                {
                    wrongGuesses++;
                    NewGameState(hiddenWord.ToString(), wrongGuesses);
                    Console.WriteLine("The letter " + guessedLetter + " is not in the word. Guess again!");
                    guessedLettersList.Add(guessedLetter);
                }
            }

            // End of game results
            NewGameState(winningWord, wrongGuesses);
            if (wrongGuesses >= 6)
            {
                Console.WriteLine("GAME OVER! The man has been hanged. You ran out of guesses.");
            }
            else
            {
                NewGameState(winningWord, wrongGuesses);
                Console.WriteLine("Congratulations! You have saved the man and beat the game!");
            }

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}