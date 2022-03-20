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

            bool isEnteredKeyCalled = false;

            foreach (var extractor in _extractors)
            {
                if (extractor.Key == extractorKey)
                {
                    isEnteredKeyCalled = true;
                    var instance = (IExtractor)Activator.CreateInstance(extractor.Value);
                    var films = instance.ExtractFilms();

                    Save(films);

                    break;
                }
            }

            if (!isEnteredKeyCalled)
            {
                MessageHandler.Handle(new WrongNumberMessage());
                return;
            }
        }

        private void Save(List<Film> films)
        {
            MessageHandler.Handle(new FileSaverInstructionMessage());
            var fileSaverkey = Console.ReadLine();

            foreach (var fileSaver in _fileSavers)
            {
                if (fileSaver.Key == fileSaverkey)
                {
                    using (var saver = (IFileSaver)Activator.CreateInstance(fileSaver.Value, films))
                        saver.SaveOnDisk();

                    break;
                }
            }
        }
    }
}
