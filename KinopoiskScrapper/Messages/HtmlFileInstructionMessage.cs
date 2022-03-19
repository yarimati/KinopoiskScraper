namespace KinopoiskScraper.Messages
{
    internal class HtmlFileInstructionMessage : Interfaces.Message
    {
        public override void ShowMessage(params string[] data)
        {
            Console.WriteLine("How to export film ratings?");
            Console.WriteLine("1. Create folder for pages on Desktop.");
            Console.WriteLine(@"2. Open your films ratings tab. Example: (https://www.kinopoisk.ru/user/{yourAccountId}/votes/).");
            Console.WriteLine("3. Select maximum availible films on the page. max - 200.");
            Console.WriteLine(@"4. Right click on page and choose ""Save as..."" or press ""Ctrl + S"".");
            Console.WriteLine("5. Save in that folder on Desktop.");
            Console.WriteLine("6. Do same action for rest pages. (change name for new pages)");
            Console.WriteLine(@"7. Specify path below for that folder. Example: (C:\Users\{yourName}\Desktop\films)");
            Console.WriteLine();
        }
    }
}
