namespace KinopoiskScraper.Message
{
    public class GreetingMessage : Interfaces.Message
    {
        public override void ShowMessage()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Choose option");
            Console.WriteLine("Extract films rating from link press - 1 (without English name)");
            Console.WriteLine("Extract films rating from html document press - 2");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine();
        }
    }
}
