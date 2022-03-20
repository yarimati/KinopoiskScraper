namespace KinopoiskScraper.Messages
{
    public class UninstalledExcelMessage : Interfaces.Message
    {
        public override void ShowMessage(params string[] data)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine();
            Console.WriteLine($"Seems like you have not installed excel.");
            Console.WriteLine($"Exception message: {data[0]}");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.ReadKey();
        }
    }
}
