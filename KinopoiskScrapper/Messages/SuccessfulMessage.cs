namespace KinopoiskScraper.Message
{
    public class SuccessfulMessage : Interfaces.Message
    {
        public string DestinationPath { get; set; }
        public SuccessfulMessage(string path)
        {
            DestinationPath = path;
        }
        public override void ShowMessage()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine($"Successful! Destination path: {DestinationPath}");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
