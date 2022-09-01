using System;
using System.Text;
using System.Collections.Generic;

namespace HangMan
{
    class Program
    {

        static void Main(string[] args)
        //{
        //    int wrongGuesses = 0;
        //    Random random = new Random();

        //    List<string> wordList = new List<string> {"banana", "koolaid", "program" };

        //    // winningWord väljer ett ord från wordList
        //    string winningWord = wordList[random.Next(wordList.Count)];
        //    StringBuilder hiddenWord = new StringBuilder();

        //    // Bokstäverna från winningWord ersätts med understräck och lagras i hiddenWord
        //    foreach (char c in winningWord)
        //    {
        //        hiddenWord.Append("_ ");
        //    }



        //    Console.WriteLine(hiddenWord.ToString());



        //    //string word= hiddenWord.ToString(); 
        //    //char Line = char.Parse(hiddenWord.ToString());

        //    Console.WriteLine("Guess a letter");

        //    //string guess = Console.ReadLine();
        //    //char guessedLetter = char.Parse(guess);

        //    //Console.WriteLine(hiddenWord);

        //    //foreach (char c in winningWord)
        //    //{
        //    //    if (c == guessedLetter && wrongGuesses! <= 6)
        //    //    {
        //    //        hiddenWord.Replace(char.Parse("_"), guessedLetter, i, 1);
        //    //        Console.WriteLine("hello?");
        //    //        break;

        //    //    }
        //    //    else if (c != guessedLetter && wrongGuesses! <= 6)
        //    //    {
        //    //        Console.WriteLine("Letter" + guessedLetter + "is not in the word.");
        //    //        wrongGuesses++;
        //    //    }
        //    //}

        //    Console.WriteLine("The Program is Over");
        //    Console.ReadKey();
        //}

        {
            int guesses = 0;
            bool hit = false;

            string winningWord = "banana";
            StringBuilder hiddenWord = new StringBuilder("______");
            //string word= hiddenWord.ToString(); 

            //char Line = char.Parse(hiddenWord.ToString());

            //int i = 0;

            Console.WriteLine("Guess a letter!");
            Console.WriteLine(hiddenWord);


            while (guesses <= 6)
            {
                string guess = Console.ReadLine();
                char guessedLetter = char.Parse(guess);

                for (int i = 0; i < winningWord.Length; i++)
                {
                  
                    if (winningWord[i] == guessedLetter)
                    {
                        hiddenWord.Replace(char.Parse("_"), guessedLetter, i, 1);
                        Console.WriteLine("hello?");
                        hit = true;
                    }
                    else if (winningWord[i] != guessedLetter && hit != true)
                    {
                        Console.WriteLine("Letter" + guessedLetter + "is not in the word.");
                        guesses++;
                        Console.WriteLine("you have guessed " + guesses + " times");
                    }
                    hit = false;
                    
                }

            }

        Console.WriteLine(hiddenWord);

            Console.WriteLine("The Program is Over");
            Console.ReadKey();
        }
    }
}