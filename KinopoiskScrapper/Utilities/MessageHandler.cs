namespace KinopoiskScraper.Utilities
{
    public static class MessageHandler
    {
        public static void Handle(Interfaces.Message message, params string[] data) => message.ShowMessage(data);
    }
}