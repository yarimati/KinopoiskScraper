MessageHandler.Handle(new GreetingMessage());

var extractorType = Console.ReadLine();
Console.WriteLine();

if (extractorType is "1")
{
    MessageHandler.Handle(new ApiRequestInstractionMessage());
    ExtractData(new ApiRequestExtractor());
}
else if (extractorType is "2")
{
    MessageHandler.Handle(new HtmlFileInstructionMessage());
    ExtractData(new HtmlFileExtractor());
}
else
{
    MessageHandler.Handle(new HtmlFileInstructionMessage());
    return;
}

static void ExtractData(IExtractor extractor)
{
    string? userMsg = Console.ReadLine();
    var films = extractor.ExtractFilms(userMsg);

    MessageHandler.Handle(new FileSaverInstructionMessage());
    var fileSaverType = Console.ReadLine();

    if (fileSaverType is "1")
        SaveData(new ExcelFileSaver(films));
    else if (fileSaverType is "2")
        SaveData(new TxtFileSaver(films));
}

static void SaveData(IFileSaver fileSaver)
{
    fileSaver.SaveOnDisk();
}