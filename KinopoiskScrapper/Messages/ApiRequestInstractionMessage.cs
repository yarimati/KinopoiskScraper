namespace KinopoiskScraper.Messages
{
    internal class ApiRequestInstractionMessage : Interfaces.Message
    {
        public override void ShowMessage()
        {
            Console.WriteLine("How to export film ratings?");
            Console.WriteLine(@"Paste below your kinopoisk link. Example (https://www.kinopoisk.ru/user/14585828).");
            Console.WriteLine();
        }
    }
}
