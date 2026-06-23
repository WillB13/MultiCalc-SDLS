using System;

{
    public static void Main(string[] args)
    {
        for (int i = 0; i < 20; i++);
        {
            Console.WriteLine("+");
            Thread.Sleep(250);
            Console.Write("\b");
            Console.Write("-");
            Thread.Sleep(250);
            Console.Write("\b");
        }

    }
}