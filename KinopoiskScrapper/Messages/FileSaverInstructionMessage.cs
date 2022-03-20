namespace KinopoiskScraper.Messages
{
    public class FileSaverInstructionMessage : Interfaces.Message
    {
        public override void ShowMessage()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine();
            Console.WriteLine($"Which way do you prefer to save data?");
            Console.WriteLine($"1. Excel (must have installed on pc)");
            Console.WriteLine($"2. Txt file");
            Console.WriteLine($"Type number below and press enter");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine();
        }
    }
}
