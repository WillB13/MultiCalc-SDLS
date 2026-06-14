public class BaseActivity
{
    private string _name;
    private string _description;
    protected int _duration;

    public BaseActivity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    protected void StartActivity()
    {
        Console.Clear();

        Console.WriteLine($"Welcome to the {_name} Activity");
        Console.WriteLine(_description);

        Console.Write("\nHow long would you like your session? ");
        _duration = int.Parse(Console.ReadLine());

        Console.WriteLine("\nPrepare to begin...");
        RunSpinner(3);
    }

    protected void EndActivity()
    {
        Console.WriteLine("\nWell done!");

        RunSpinner(3);

        Console.WriteLine(
            $"\nYou have completed another {_duration} seconds of the {_name} Activity.");

        RunSpinner(3);
    }

    protected void RunSpinner(int seconds)
    {
        string[] spinner = { "|", "/", "-", "\\" };

        DateTime end = DateTime.Now.AddSeconds(seconds);
        int i = 0;

        while (DateTime.Now < end)
        {
            Console.Write(spinner[i]);
            Thread.Sleep(250);
            Console.Write("\b \b");

            i = (i + 1) % spinner.Length;
        }
    }

    protected void RunCountDown(string message, int seconds)
    {
        Console.Write(message);

        for (int i = seconds; i > 0; i--)
        {
            Console.Write($" {i}");
            Thread.Sleep(1000);
        }

        Console.WriteLine();
    }
}