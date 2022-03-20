namespace KinopoiskScraper.Utilities
{
    public static class MessageHandler
    {
        public static void Handle(Interfaces.Message message) => message.ShowMessage();
    }
}