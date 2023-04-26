using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What is your grade percentage? ");
        int grade = int.Parse(Console.ReadLine());

        char letter = 'F';

        if (grade >= 90)
        {
            letter = 'A';
        } else if (grade >=80)
        {
            letter = 'B';
        } else if (grade >= 70)
        {
            letter = 'C';
        } else if (grade >= 60)
        {
            letter = 'D';
        }
        Console.WriteLine($"Your grade is {letter}");
        if (grade >= 70)
        {
            Console.WriteLine("Congratulations! you pass the class.");
        } else
        {
            Console.WriteLine("Sorry you didn't pass the class.");
        }
    }
}