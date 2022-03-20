namespace KinopoiskScraper.Message
{
    public class ExcelBusyMessage : Interfaces.Message
    {
        public string Message { get; set; }
        public ExcelBusyMessage(string msg)
        {
            Message = msg;
        }
        public override void ShowMessage()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine();
            Console.WriteLine($"Close Excel and try again.");
            Console.WriteLine($"Exception message: {Message}");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.ReadKey();
        }
    }
}
