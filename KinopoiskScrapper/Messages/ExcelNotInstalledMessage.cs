namespace KinopoiskScraper.Message
{
    public class ExcelNotInstalledMessage : Message
    {
        public override void ShowMessage(params string[] data)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine();
            Console.WriteLine($"Excel is not installed");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.ReadKey();
        }
    }
}
