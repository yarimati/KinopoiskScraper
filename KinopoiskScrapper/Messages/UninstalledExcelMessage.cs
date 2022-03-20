namespace KinopoiskScraper.Messages
{
    public class UninstalledExcelMessage : Interfaces.Message
    {
        public string Message { get; set; }
        public UninstalledExcelMessage(string msg)
        {
            Message = msg;
        }
        public override void ShowMessage()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine();
            Console.WriteLine($"Seems like you have not installed excel.");
            Console.WriteLine($"Exception message: {Message}");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.ReadKey();
        }
    }
}
