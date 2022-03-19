namespace KinopoiskScraper.Interfaces
{
    public interface IExtractor
    {
        List<Film>? ExtractFilms(params string[] data);
    }
}
