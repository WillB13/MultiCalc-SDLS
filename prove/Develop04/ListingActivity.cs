class ListingActivity : BaseActivity
{
    private List<string> _prompts = new List<string>()
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    private Random _random = new Random();

    public ListingActivity()
        : base(
            "Listing",
            "This activity will help you reflect on the good things in your life.")
    {
    }

    public void RunActivity()
    {
        StartActivity();

        string prompt = _prompts[_random.Next(_prompts.Count)];

        Console.WriteLine("\nList as many responses as you can to:");
        Console.WriteLine($"--- {prompt} ---");

        Console.WriteLine();

        RunCountDown("You may begin in", 5);

        List<string> items = new List<string>();

        DateTime end = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < end)
        {
            Console.Write("> ");
            items.Add(Console.ReadLine());
        }

        Console.WriteLine($"\nYou listed {items.Count} items!");

        EndActivity();
    }
}