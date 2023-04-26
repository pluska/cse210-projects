using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        Boolean mustContinue = true;
        List<int> numbers = new List<int>();
        do
        {
            Console.WriteLine("Enter number: ");
            numbers.Add(int.Parse(Console.ReadLine()));
        } while (mustContinue);

    int sum = 0;
    int largest = 0;
        foreach (int number in numbers)
        {
            if (number > largest)
            {
                largest = number;
            }
            sum += number;
        }

        Console.WriteLine($"The number is: {sum}");
        Console.WriteLine($"the average is: {sum/numbers.Count}");
        Console.WriteLine($"The largest number is: {largest}");
    }
}