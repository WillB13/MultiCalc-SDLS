using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();

        int uNumber = -1;
        while (uNumber != 0)
        {
            Console.Write("Enter a number (enter 0 to stop): ");
            
            string Response = Console.ReadLine();
            uNumber = int.Parse(Response);
            
            if (uNumber != 0)
            {
                numbers.Add(uNumber);
            }
        }
        int sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
        }

        Console.WriteLine($"The sum of the numbers is: {sum}");

        float average = ((float)sum) / numbers.Count;
        Console.WriteLine($"The average of the numbers is: {average}");
        
        int max = numbers[0];

        foreach (int number in numbers)
        {
            if (number > max)
            {
                max = number;
            }
        }
        Console.WriteLine($"The max is: {max}");
    }
}