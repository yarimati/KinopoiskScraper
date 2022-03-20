namespace KinopoiskScraper.Messages
{
    public class WrongNumberMessage : Interfaces.Message
    {
        public override void ShowMessage()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine();
            Console.WriteLine($"You entered wrong number");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.ReadKey();
        }
    }
}
