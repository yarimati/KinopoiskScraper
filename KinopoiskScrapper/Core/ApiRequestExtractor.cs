using Newtonsoft.Json;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace KinopoiskScraper.Core
{
    internal class ApiRequestExtractor : IExtractor
    {
        public List<Film>? ExtractFilms(params string[] data)
        {
            var dtos = GetFilmsDto(data[0]);

            if (dtos is null)
                return null;

            List<Film> films = new();

            foreach (var dto in dtos)
                films.Add(new Film { NameRus = dto.alt, NameEng = String.Empty, Rating = int.Parse(dto.value) });

            return films.OrderByDescending(f => f.Rating).ToList();
        }

        private List<FilmDto> GetFilmsDto(string link)
        {
            var userId = Regex.Match(link, @"\d+").Value;
            if (userId is null || userId.Length < 3)
            {
                MessageHandler.Handle(new WrongLinkMessage());
                return null;
            }

            var threeLastDigit = userId.Substring(userId.Length - 3);

            List<FilmDto> dtos = new List<FilmDto>();

            using (WebClient wc = new WebClient())
            {
                try
                {
                    string json = Encoding.UTF8.GetString(wc.DownloadData($@"https://www.kinopoisk.ru/graph_data/last_vote_data/{threeLastDigit}/last_vote_{userId}__all.json"));

                    int pFrom = json.IndexOf("[");
                    int pTo = json.LastIndexOf("]") + 1;

                    var result = json.Substring(pFrom, pTo - pFrom);

                    dtos = JsonConvert.DeserializeObject<List<FilmDto>>(result);
                }
                catch (Exception ex)
                {
                    MessageHandler.Handle(new UnexpectedBehaviourMessage(), ex.Message);
                    return null;
                }
            }
            return dtos;
        }
    }
}
