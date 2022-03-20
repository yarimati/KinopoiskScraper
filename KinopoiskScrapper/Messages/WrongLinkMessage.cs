namespace KinopoiskScraper.Messages
{
    public class WrongLinkMessage : Interfaces.Message
    {
        public override void ShowMessage()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine();
            Console.WriteLine($"User not found or wrong link");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.ReadKey();
        }
    }
}
