namespace KinopoiskScraper.Utilities
{
    public static class MessageHandler
    {
        public static void Handle(KinopoiskScraper.Message.Message message, params string[] data) => message.ShowMessage(data);
    }
}