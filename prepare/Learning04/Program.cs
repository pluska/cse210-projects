using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment test1 = new Assignment("samuel Bennet", "Multiplication");
        Console.WriteLine(test1.GetSummary());

        MathAssignment test2 = new MathAssignment("samuel Bennet", "Fractions", "1.2", "1-10");
        Console.WriteLine(test2.GetSummary());
        Console.WriteLine(test2.GetHomeworkList());

        WrittingAssignment test3 = new WrittingAssignment("samuel Bennet", "Personal", "The story of my life");
        Console.WriteLine(test3.GetSummary());
        Console.WriteLine(test3.GetWrittingInformation());
    }
}