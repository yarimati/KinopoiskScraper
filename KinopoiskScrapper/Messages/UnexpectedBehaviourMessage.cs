namespace KinopoiskScraper.Messages
{
    public class UnexpectedBehaviourMessage : Interfaces.Message
    {
        public override void ShowMessage(params string[] data)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine();
            Console.WriteLine($"Something went wrong");
            Console.WriteLine($"Exception message: {data[0]}");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.ReadKey();
        }
    }
}
