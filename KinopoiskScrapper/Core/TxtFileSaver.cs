namespace KinopoiskScraper.Core
{
    internal class TxtFileSaver : IFileSaver
    {
        private List<Film> _films;
        public TxtFileSaver(List<Film> films)
        {
            _films = films;
        }
        public void SaveOnDisk()
        {
            if (_films == null)
                return;

            using (StreamWriter sw = new(FilePath.TxtDestinationPath))
            {
                sw.WriteLine("NameRus\t|\tNameEng\t|\t{Rating}");
                sw.WriteLine();
                foreach (var film in _films)
                {
                    sw.WriteLine($"{film.NameRus}\t\t{film.NameEng}\t\t{{{film.Rating}}}");
                }
            }
            MessageHandler.Handle(new SuccessfulMessage(), FilePath.TxtDestinationPath);
        }
    }
}
