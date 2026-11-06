using System;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise4 Project.");


        List<int> numbers = new List<int>();
        int addend = -1;
        while (addend != 0)
        {
            Console.Write("Enter a Number (enter 0 to quit): ");
            string answer = Console.ReadLine();
            addend = int.Parse(answer);

            if (addend != 0)
            {
                numbers.Add(addend);
            }
        }
        int sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
        }
        Console.WriteLine($"The added up Sum is: {sum}");
        float average = ((float) sum ) / numbers.Count;

        Console.WriteLine($"The average Number is: {average}");

        int max = numbers[0];
        foreach (int number in numbers)
        {
            if (number > max)
            {
                max = number;
            }
        }
        Console.WriteLine($"The biggest Number is: {max}");
    }
}