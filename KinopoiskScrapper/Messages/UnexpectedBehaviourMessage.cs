namespace KinopoiskScraper.Messages
{
    public class UnexpectedBehaviourMessage : Interfaces.Message
    {
        public string Message { get; set; }
        public UnexpectedBehaviourMessage(string msg)
        {
            Message = msg;
        }
        public override void ShowMessage()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine();
            Console.WriteLine($"Something went wrong");
            Console.WriteLine($"Exception message: {Message}");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.ReadKey();
        }
    }
}
