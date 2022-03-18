using System.Diagnostics;

namespace KinopoiskScraper.Models
{
    [DebuggerDisplay("Id = {Id}, NameRus = {NameRus}, NameEng = {NameEng}, Rating = {Rating}")]
    public class Film
    {
        public string? NameRus { get; set; }
        public string? NameEng { get; set; }
        public int Rating { get; set; }
    }
}
