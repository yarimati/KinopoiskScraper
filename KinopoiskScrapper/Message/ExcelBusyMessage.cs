namespace KinopoiskScraper.Message
{
    public class ExcelBusyMessage : Message
    {
        public override void ShowMessage(params string[] data)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine();
            Console.WriteLine($"Close Excel and try again.");
            Console.WriteLine($"Exception message: {data[0]}");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.ReadKey();
        }
    }
}
