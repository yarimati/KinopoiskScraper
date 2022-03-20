namespace KinopoiskScraper
{
    internal class ScraperManager
    {
        private readonly Dictionary<string, Type> _extractors = new()
        {
            { "1", typeof(ApiRequestExtractor) },
            { "2", typeof(HtmlFileExtractor) },
        };
        private readonly Dictionary<string, Type> _fileSavers = new()
        {
            { "1", typeof(ExcelFileSaver) },
            { "2", typeof(TxtFileSaver) },
        };

        public void Start()
        {
            MessageHandler.Handle(new GreetingMessage());

            var extractorKey = Console.ReadLine();
            Console.WriteLine();

            if (_extractors.TryGetValue(extractorKey, out var type))
            {
                var instance = (IExtractor)Activator.CreateInstance(type);
                var films = instance.ExtractFilms();

                Save(films);
            }
            else 
                MessageHandler.Handle(new WrongNumberMessage());
        }

        private void Save(List<Film> films)
        {
            MessageHandler.Handle(new FileSaverInstructionMessage());
            var fileSaverKey = Console.ReadLine();

            if (_fileSavers.TryGetValue(fileSaverKey, out var type))
            {
                using (var saver = (IFileSaver)Activator.CreateInstance(type, films))
                    saver.SaveOnDisk();
            }
            else
                MessageHandler.Handle(new WrongNumberMessage());
        }
    }
}
