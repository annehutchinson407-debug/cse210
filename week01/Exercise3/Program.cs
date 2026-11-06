using System;
using System.Security.Cryptography;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise3 Project.");

        Console.WriteLine("Guess the Magic Number between 1 and 500: ");

        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 501);
        int guess = -1;

        while (guess != magicNumber)
        {
            Console.Write("Guess the Magic Number: ");
            guess = int.Parse(Console.ReadLine());

            if (magicNumber > guess)
            {
                Console.WriteLine("Higher");
            }
            else if (magicNumber < guess)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("Congrats, you guessed the Magic Number!");
            }
        }
    }
}