using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomNumber = new Random();
        int numberGuess = randomNumber.Next(1, 101);

        int guess = -1;
        while (guess != numberGuess)
        {
            Console.Write("What is your guess? ");
            guess = int.Parse(Console.ReadLine());

            if (numberGuess > guess)
            {
                Console.WriteLine("Higher");
            }
            else if (numberGuess < guess)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("You guessed it!");
            }

        }                    
    }
}