 using System;
using System.Formats.Asn1;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise2 Project.");



        Console.Write("Please enter your Grade percentage from 0 to 100: ");
        string grade = Console.ReadLine();
        int gradeValue = int.Parse(grade);

        string letter = "";

        if (gradeValue == 100)
        {
            letter ="A+";
        }
        else if (gradeValue >= 90)
        {
            letter ="A";
        }
        else if (gradeValue >= 80)
        {
            letter ="B";
        }
        else if (gradeValue >= 70)
        {
            letter ="C";
        }
        else if (gradeValue >= 60)
        {
            letter ="D";
        }
        else
        {
            letter = "F";
        }

        Console.WriteLine($"You grade is: {letter}");

        if (gradeValue >= 70)
        {
            Console.WriteLine("Congratulations! You passed the class!");
        }
        else
        {
            Console.WriteLine("Sorry, you didn't pass. Don't be afraid to ask for help next time!");
        }
    }
}