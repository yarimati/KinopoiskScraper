namespace KinopoiskScraper.Message
{
    public class SuccessfulMessage : Message
    {
        public override void ShowMessage(params string[] data)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine($"Successful! Destination path: {data[0]}");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.ReadKey();
        }
    }
}
