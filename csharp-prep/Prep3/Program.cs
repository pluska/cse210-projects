using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        int magic_number = randomGenerator.Next(1, 11);

        Console.WriteLine("type a guess. ");
        int guess_number = int.Parse(Console.ReadLine());

        do
        {
            if (magic_number > guess_number)
            {
                Console.WriteLine("Lower");
            } else if (magic_number < guess_number)
            {
                Console.WriteLine("Higher");
            }
            Console.WriteLine("type a guess. ");
            guess_number = int.Parse(Console.ReadLine());
        } while (magic_number != guess_number);

            Console.WriteLine("You guess it!");

    }
}