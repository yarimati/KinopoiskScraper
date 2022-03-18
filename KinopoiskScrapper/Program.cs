MessageHandler.Handle(new GreetingMessage());

string? directoryPath = Console.ReadLine();

var films = FilmExtractor.ExtractFilms(directoryPath);
ExcelManager.SaveOnDisk(films, directoryPath);