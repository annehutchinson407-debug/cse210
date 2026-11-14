using System;

class Program
{
    private static readonly string[] Prompts =
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        "What is something new I learned today?",
        "What is one thing I am grateful for right now?",
        "How have I shown my gratitude today?",
        "Who did I spend the most time with today?",
        "What challenge did I overccome today?",
        "What tasks have I accomplished today?",
        "How did I prepare for a better future today?"
    };

    private static readonly Random Random = new Random();

    static void Main(string[] args)
    {
        Journal journal = new Journal();
        bool running = true;

        while (running)
        {
            Console.WriteLine("Welcome to the Journal Program!");
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Save");
            Console.WriteLine("4. Load");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");

            string choice = Console.ReadLine();
            if (choice == null)
            {
                break;
            }
            if (choice == "1")
            {
                WriteEntry(journal);
            }
            else if (choice == "2")
            {
                journal.Display();
            }
            else if (choice == "3")
            {
                SaveJournal(journal);
            }
            else if (choice == "4")
            {
                LoadJournal(journal);
            }
            else if (choice == "5")
            {
                running = false;
                Console.Write("Have a nice day!");
            }
            else
            {
                Console.WriteLine("Please choose an option from 1-5.");
            }
        }
    }

    private static void WriteEntry(Journal journal)
    {
        string prompt = Prompts[Random.Next(Prompts.Length)];
        Console.WriteLine(prompt);
        Console.Write("> ");
        string response = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(response))
        {
            journal.AddEntry(new Entry(DateTime.Now.ToString("yyyy-MM-dd"), prompt, response));
            Console.WriteLine("Your entry has been added.");
        }
        else
        {
            Console.WriteLine("An empty response was not added.");
        }
    }

    private static void SaveJournal(Journal journal)
    {
        Console.Write("Enter the filename to save to: ");
        string filename = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(filename))
        {
            Console.WriteLine("A filename is required.");
            return;
        }
        try
        {
            journal.SaveToFile(filename);
            Console.WriteLine("Journal saved.");
        }
        catch (Exception exception) when (
            exception is IOException ||
            exception is UnauthorizedAccessException ||
            exception is ArgumentException ||
            exception is NotSupportedException)
        {
            Console.WriteLine("Could not save the journal: " + exception.Message);
        }
    }

    private static void LoadJournal(Journal journal)
    {
        Console.Write("Enter the filename to load from: ");
        string filename = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(filename))
        {
            Console.WriteLine("A filename is required.");
            return;
        }
        try
        {
            journal.LoadFromFile(filename);
            Console.WriteLine("Journal loaded.");
        }
        catch (Exception exception) when (
            exception is IOException ||
            exception is UnauthorizedAccessException ||
            exception is ArgumentException ||
            exception is NotSupportedException ||
            exception is FormatException)
        {
            Console.WriteLine("Could not load the journal: " + exception.Message);
        }
    }
}
