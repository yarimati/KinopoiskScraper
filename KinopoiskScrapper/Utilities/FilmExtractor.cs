namespace KinopoiskScraper.Utilities
{
    public class FilmExtractor
    {
        public static List<Film>? ExtractFilms(string path)
        {
            if (path is null || !Directory.Exists(path))
            {
                MessageHandler.Handle(new WrongPathMessage());
                return null;
            }

            string[] files = Directory.GetFiles(path, "*.html");

            if (files.Length < 1)
            {
                MessageHandler.Handle(new FilesNotFoundMessage());
                return null;
            }

            int fileCounter = 0;
            var doc = new HtmlDocument();
            var films = new List<Film>();

            while (fileCounter < files.Length)
            {
                string html = File.ReadAllText(files[fileCounter]);

                doc.LoadHtml(html.ToString());

                var oddItemHtmlNodes = doc.DocumentNode.SelectNodes(Xpath.OddItemHtmlNodes);
                var evenItemHtmlNodes = doc.DocumentNode.SelectNodes(Xpath.EvenItemHtmlNodes);

                films.AddRange(GetFilms(oddItemHtmlNodes));
                films.AddRange(GetFilms(evenItemHtmlNodes));

                fileCounter++;
            }

            return films.OrderByDescending(f => f.Rating).ToList();
        }

        public static List<Film> GetFilms(HtmlNodeCollection collection)
        {
            var films = new List<Film>();
            foreach (var item in collection)
            {
                var film = GetFilm(item.OuterHtml);
                if (film is not null)
                    films.Add(film);
            }
            return films;
        }

        private static Film? GetFilm(string outerHtml)
        {
            HtmlDocument document = new();
            document.LoadHtml(outerHtml);
            int rating = 0;

            var nameRusHtmlNode = document.DocumentNode.SelectSingleNode(Xpath.NameRus);
            var nameEngHtmlNode = document.DocumentNode.SelectSingleNode(Xpath.NameEng);
            var myRatingHtmlNode = document.DocumentNode.SelectSingleNode(Xpath.MyRatingHtmlNode);
            var othersRatingHtmlNode = document.DocumentNode.SelectSingleNode(Xpath.OthersRatingHtmlNode);

            if (nameRusHtmlNode is null || nameEngHtmlNode is null)
                return null;

            if (myRatingHtmlNode is not null && !string.IsNullOrEmpty(myRatingHtmlNode.InnerText))
                rating = int.Parse(myRatingHtmlNode.InnerText);
            // kind of fizzbuzz, othersRatingHtmlNode most important that`s why it is last.
            if (othersRatingHtmlNode is not null && !string.IsNullOrEmpty(othersRatingHtmlNode.InnerText))
                rating = int.Parse(othersRatingHtmlNode.InnerText);

            return new Film()
            {
                NameRus = nameRusHtmlNode.InnerText,
                NameEng = nameEngHtmlNode.InnerText,
                Rating = rating
            };
        }
    }
}