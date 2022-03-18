namespace KinopoiskScraper.Message
{
    public class FilesNotFoundMessage : Message
    {
        public override void ShowMessage(params string[] data)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine();
            Console.WriteLine(@"No ""html"" files found, try again.");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.ReadKey();
        }
    }
}
