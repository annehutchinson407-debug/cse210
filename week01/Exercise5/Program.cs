using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise5 Project.");

        DisplayWelcomeText();
        string name = PromptName();
        int number = PromptNumber();
        int squaredNumber = squared(number);

        DisplayResult(name, squaredNumber);
    }

    static void DisplayWelcomeText()
    {
        Console.WriteLine("Welcome to the Programm!");
    }
    static string PromptName()
    {
        Console.Write("What is your name? ");
        string name = Console.ReadLine();
        return name;
    }
    static int PromptNumber()
    {
        Console.Write("What is your favorite Number? ");
        int number = int.Parse(Console.ReadLine());
        return number;
    }
    static int squared(int number)
    {
        int square = number * number;
        return square;
    }
    static void DisplayResult(string name, int square)
    {
        Console.WriteLine($"{name}, your favorite number squared is {square}.");
    }
}