using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ConsoleApplication
{
    class Program
    {
        static Random random = new Random();
        const int LotteryDigitsCount = 5;
        const string messageString = "{0}. Your digit: {1} - lottery digit: {2} => {3}";

        static void Main(string[] args)
        {
            Console.WriteLine("It is a simple lottery game");
            var playGame = true;
            while (playGame)
            {

                var arrayOfLotteryDigits = new List<int>();
                for (int i = 0; i < LotteryDigitsCount; i++)
                {
                    arrayOfLotteryDigits.Add(random.Next(0, 9));
                }

                Console.WriteLine("Lottery digits has been defined!");
                Console.WriteLine("Enter 5 digits to start our game!");
                Console.WriteLine("---------------------------");
                var arrayOfUserSelectedDigits = new List<int>();
                for (int i = 1; i <= LotteryDigitsCount; i++)
                {
                    var inputNumber = 0;
                    Console.WriteLine($"Please enter number {i}");
                    while (!Int32.TryParse(Console.ReadLine(), out inputNumber))
                    {
                        Console.WriteLine("Please enter only numbers!");
                    }
                    arrayOfUserSelectedDigits.Add(inputNumber);
                }

                System.Console.WriteLine(Environment.NewLine);
                System.Console.WriteLine("Be ready lottery is starting");
                Thread.Sleep(1000);

                //dictionary to sotre digit index and equality status
                var resultDictionary = new Dictionary<int, bool>();
                for (int i = 0; i < LotteryDigitsCount; i++)
                {
                    var currentLotteryDigit = arrayOfLotteryDigits[i];
                    var currentUserSelectedDigit = arrayOfUserSelectedDigits[i];
                    resultDictionary.Add(i, currentLotteryDigit == currentUserSelectedDigit);

                    Console.WriteLine(string.Format(messageString,
                                     i,
                                     currentUserSelectedDigit,
                                     currentLotteryDigit,
                                     resultDictionary[i] ? "Same" : "Not Same"));

                    Thread.Sleep(200);
                }

                var matchedDigitsCount = resultDictionary.Count(r => r.Value == true);
                System.Console.WriteLine($"You earned {matchedDigitsCount * 10} points\n");

                Console.WriteLine("To play againg enter 'y' otherwise press any key");
                playGame = Console.ReadLine() == "y";
            }
        }
    }
}
