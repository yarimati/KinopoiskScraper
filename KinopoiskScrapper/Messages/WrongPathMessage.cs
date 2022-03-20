namespace KinopoiskScraper.Message
{
    public class WrongPathMessage : Interfaces.Message
    {
        public override void ShowMessage()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine();
            Console.WriteLine("Wrong path try again.");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.ReadKey();
        }
    }
}
