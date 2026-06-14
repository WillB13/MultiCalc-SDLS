using System;

class Program
{
    static void Main(string[] args)
    {
        bool running = true;

        while (running)
        {
            System.Console.Clear();
            System.Console.WriteLine("Menu Options:");
            System.Console.WriteLine("1. Start Breathing Activity");
            System.Console.WriteLine("2. Start Reflecting Activity");
            System.Console.WriteLine("3. Start Listing Activity");
            System.Console.WriteLine("4. Quit");
            
            System.Console.Write("\nSelect a choice: ");
            string choice = System.Console.ReadLine();

            switch (choice)
            {
                case "1":
                    // BreathingActivity expects 1 string argument for its description
                    BreathingActivity breathing = new BreathingActivity("This activity will help you relax by walking you through breathing in and out slowly.");
                    breathing.RunActivity();
                    break;

                case "2":
                    // ReflectingActivity takes 0 arguments because description is hardcoded inside it
                    ReflectingActivity reflecting = new ReflectingActivity();
                    reflecting.RunActivity();
                    break;

                case "3":
                    // ListingActivity takes 0 arguments because description is hardcoded inside it
                    ListingActivity listing = new ListingActivity();
                    listing.RunActivity();
                    break;

                case "4":
                    running = false;
                    break;

                default:
                    System.Console.WriteLine("\nInvalid option. Press Enter to try again.");
                    System.Console.ReadLine();
                    break;
            }
        }
    }
}