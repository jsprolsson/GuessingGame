using System;
using System.Collections.Generic;

namespace NumberGuessingGame
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Hey! Want to play a game? Y/N ");
            string answer = Console.ReadLine();
            answer.ToUpper();

            switch (answer)                                                     
            {
                case "Y":
                    Game guessingGame = new Game();
                    guessingGame.PlayGame();
                    break;
                case "N":
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid input.");
                    break;
            }


        }

        class Game
        {
            bool isCorrect = false;
            List<int> guessedNumbers = new List<int>();
            int mainRandomNumber = GetRandomNumbers();

            public void PlayGame()
            {
                do
                {
                    Console.WriteLine("Guess a number: ");
                    int userInput = int.Parse(Console.ReadLine());


                    if (userInput == mainRandomNumber)
                    {
                        Console.WriteLine("Correct!");
                        isCorrect = true;
                    }
                    if (guessedNumbers.Contains(userInput))
                    {
                        Console.WriteLine("You've already guessed " + userInput + " !");
                        Console.WriteLine("--------------------------------------------------");
                        Console.WriteLine("Gissa igen!");

                        guessedNumbers.Add(userInput);

                        Console.WriteLine("Press ENTER to continue.....");
                        Console.ReadKey();
                        Console.Clear();
                    }
                    else
                    {
                        guessedNumbers.Add(userInput);
                    }



                } while (!isCorrect);
            }



        }

        static int GetRandomNumbers()
        {
            Random random = new Random();
            int[] interval = new int[2];                    //Tar en input från user, foreachen splittar siffrorna mellan commatecknet och delar ut det i två olika array-platser.
            int counter = 0;                                //randomNumber randomiserar en siffra utifrån intervallet som användaren skrivit in. Returnerar till main.

            Console.Write("Write a two number interval in which you want randomized number to be between, separated by space: ");
            string userNumberInput = Console.ReadLine();

            foreach (var number in userNumberInput.Split(' '))
            {
                interval[counter] = Convert.ToInt32(number);
                counter++;
            }

            int randomNumber = random.Next(interval[0], interval[1]);

            Console.WriteLine(randomNumber);

            return randomNumber;


        }

    }
}
