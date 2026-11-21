//Added more scriptures, added a randomizer to pick a new scripture each run


using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        Scripture[] scriptures =
        {
            new Scripture(
                new Reference("Proverbs", 3, 5, 6),
                "Trust in the Lord with all thine heart; and lean not unto thine own understanding. " +
                "In all thy ways acknowledge him, and he shall direct thy paths."),
            new Scripture(
                new Reference("Ephesians", 6, 4),
                "Fathers, do not provoke your children to anger, but bring them up in the discipline " +
                "and instruction of the Lord."),
            new Scripture(
                new Reference("Romans", 12, 2),
                "Do not be conformed to this world, but be transformed by the renewal of your mind."),
            new Scripture(
                new Reference("Philippians", 1, 6),
                "Being confident of this, that he who began a good work in you will carry it on to completion until the day of Christ Jesus."),
            new Scripture(
                new Reference("2 Timothy", 2, 15),
                "Do your best to present yourself to God as one approved, a worker who has no need of being ashamed, rightly handling the word of truth.")
        };
        Scripture scripture = scriptures[Random.Shared.Next(scriptures.Length)];

        ClearScreen();
        Console.WriteLine(scripture);

        while (!scripture.IsCompletelyHidden)
        {
            Console.WriteLine();
            Console.Write("Please press enter to hide more words, or type quit to exit: ");
            string input = Console.ReadLine();

            if (string.Equals(input?.Trim(), "quit", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Have a blessed day!");
                break;
            }

            scripture.HideRandomWords(3);
            ClearScreen();
            Console.WriteLine(scripture);
        }
    }

    private static void ClearScreen()
    {
        if (!Console.IsOutputRedirected)
        {
            Console.Clear();
        }
    }
}
