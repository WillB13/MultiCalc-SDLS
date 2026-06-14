class BreathingActivity : BaseActivity
{
    public BreathingActivity (string description) : base("Breathing", description)
    {

    }

    public void RunActivity()
    {
        StartActivity();
        DateTime end = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < end)
        {
            RunCountDown("\nBreathe in...", 4);
            RunCountDown("Now breathe out...", 4);
        }

        EndActivity();
        
    }
}