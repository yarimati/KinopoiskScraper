namespace KinopoiskScraper.Utilities
{
    public static class Xpath
    {
        public static readonly string NameRusHtmlNode = @"//div[@class=""nameRus""]";
        public static readonly string NameEngHtmlNode = @"//div[@class=""nameEng""]";
        public static readonly string MyRatingHtmlNode = @"//div[@title=""поставить оценку""]";
        public static readonly string OthersRatingHtmlNode = @"//div[@class=""vote""]";
        public static readonly string OddItemHtmlNodes = @"//div[@class=""item""]";
        public static readonly string EvenItemHtmlNodes = @"//div[@class=""item even""]";
    }
}