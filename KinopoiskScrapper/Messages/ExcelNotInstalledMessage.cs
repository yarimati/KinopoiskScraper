namespace KinopoiskScraper.Message
{
    public class ExcelNotInstalledMessage : Interfaces.Message
    {
        public override void ShowMessage()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine();
            Console.WriteLine($"Excel is not installed");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.ReadKey();
        }
    }
}
