public class ReflectingActivity : BaseActivity
{
    private System.Collections.Generic.List<string> _prompts = new System.Collections.Generic.List<string>()
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private System.Collections.Generic.List<string> _questions = new System.Collections.Generic.List<string>()
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What did you learn about yourself through this experience?",
        "What could you learn from this experience?",
        "How can you keep this experience in mind in the future?"
    };

    private System.Random _random = new System.Random();

    public ReflectingActivity()
        : base(
            "Reflection",
            "This activity will help you reflect on times in your life when you have shown strength and resilience.")
    {
    }

    public void RunActivity()
    {
        StartActivity();

        System.Console.WriteLine("\nConsider the following prompt:");
        System.Console.WriteLine();

        string prompt = _prompts[_random.Next(_prompts.Count)];

        System.Console.WriteLine($"--- {prompt} ---");

        System.Console.WriteLine("\nPress Enter when you have thought about it.");
        System.Console.ReadLine();

        System.Console.WriteLine("\nReflect on the following questions:");

        System.DateTime end = System.DateTime.Now.AddSeconds(_duration);

        while (System.DateTime.Now < end)
        {
            string question = _questions[_random.Next(_questions.Count)];

            System.Console.WriteLine($"\n> {question}");
            RunSpinner(5);
        }

        EndActivity();
    }
}