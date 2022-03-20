namespace KinopoiskScraper.Interfaces
{
    public interface IFileSaver : IDisposable
    {
        public void SaveOnDisk();
    }
}
