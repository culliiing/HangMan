using System;
using System.Text;
using System.Collections.Generic;

namespace HangMan
{
    class Program
    {
        public static void DrawGraphics(int stage)
        {
            Console.WriteLine("Welcome to HangMan!");
            Console.WriteLine("_________________________________________________");

            if (stage >= 6)
            {
                Console.WriteLine("########");
                Console.WriteLine("#     | ");
                Console.WriteLine("#     O");
                Console.WriteLine("#    /I\\");
                Console.WriteLine("#    / \\");
                Console.WriteLine("#_______");
            }
            else if (stage == 5)
            {
                Console.WriteLine("########");
                Console.WriteLine("#     | ");
                Console.WriteLine("#     O");
                Console.WriteLine("#    /I\\ ");
                Console.WriteLine("#    /  ");
                Console.WriteLine("#_______");
            }
            else if (stage == 4)
            {
                Console.WriteLine("########");
                Console.WriteLine("#     | ");
                Console.WriteLine("#     O");
                Console.WriteLine("#    /I\\ ");
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
            Console.WriteLine("\r\nThe word is: " + word);
            Console.WriteLine("You have " + (6 - stage) + " wrong attempts left.");
        }

        static void Main(string[] args)
        {
            bool playGame = true;

            // Program loop
            while (playGame)
            {
                int wrongGuesses = 0;
                char guessedLetter;
                string guess;

                List<string> wordList = new() {"Banana", "Mother-in-law", "Cow", "High School", "Destitute", "Dungeons and Dragons", "Pikachu", "Eevee", "Charizard", "Snorlax"};
                List<char> guessedLettersList = new();
                List<string> guessesList = new();

                // Pick a random word from the wordList
                Random random = new Random();
                string winningWord = wordList[random.Next(wordList.Count)].ToUpper();

                // Creating a censored version of the winningWord
                StringBuilder hiddenWord = HideWord(winningWord);

                // Game start
                NewGameState(hiddenWord.ToString(), wrongGuesses);
                Console.WriteLine("\r\nGuess a letter! \nYou may also guess the exact word if you have figured it out!");

                // Game loop
                while (wrongGuesses < 6 && hiddenWord.ToString().Contains("_") == true)
                {
                    // Take user input
                    guess = Console.ReadLine().ToUpper();

                    if (!string.IsNullOrEmpty(guess))
                    {
                        guessedLetter = guess[0];

                        // Check if user guessed a word
                        if (guess.Length > 1)
                        {
                            if (guess == winningWord)
                            {
                                break;
                            }
                            else if (guessesList.Contains(guess))
                            {
                                NewGameState(hiddenWord.ToString(), wrongGuesses);
                                Console.WriteLine("\r\nYou have already guessed the word '" + guess + "'. Guess again!");
                            }
                            else
                            {
                                wrongGuesses++;
                                NewGameState(hiddenWord.ToString(), wrongGuesses);
                                Console.WriteLine("\r\n'" + guess + "'" + " is not the word. Guess again!");
                                guessesList.Add(guess);
                            }
                        }
                        // Check if user guessed a letter
                        else //if guess.Length == 1
                        {
                            if (guessedLettersList.Contains(guessedLetter))
                            {
                                NewGameState(hiddenWord.ToString(), wrongGuesses);
                                Console.WriteLine("\r\nYou have already guessed the letter " + guessedLetter + ". Guess again!");
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
                                Console.WriteLine("\r\nThe letter " + guessedLetter + " is in the word. Guess again!");
                                guessedLettersList.Add(guessedLetter);
                            }
                            else
                            {
                                wrongGuesses++;
                                NewGameState(hiddenWord.ToString(), wrongGuesses);
                                Console.WriteLine("\r\nThe letter " + guessedLetter + " is not in the word. Guess again!");
                                guessedLettersList.Add(guessedLetter);

                            }
                        }
                    }
                }

                // End of game results
                NewGameState(winningWord, wrongGuesses);
                if (wrongGuesses >= 6)
                {
                    Console.WriteLine("GAME OVER! The man has been hanged. You ran out of guesses.");                }
                else
                {
                    NewGameState(winningWord, wrongGuesses);
                    Console.WriteLine("\r\nCongratulations! You have saved the man and beat the game!");
                }

                Console.WriteLine("Press Q and then Enter to quit, or press any other key and then Enter to continue.");
                string keyStroke = Console.ReadLine().ToUpper();
                if (keyStroke == "Q")
                {
                    playGame = false;
                }
            }
            //Console.ReadKey();
        }
    }
}