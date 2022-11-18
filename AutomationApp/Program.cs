namespace AutomationApp
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            using (var app = new AutomatedApp(Constants.AppId))
            {
                Tests.TestScenario1(app);
            }
        }
    }
}