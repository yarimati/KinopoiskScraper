namespace KinopoiskScraper.Utilities
{
    public class ExcelManager
    {
        public static void SaveOnDisk(List<Film> films, string path)
        {
            if (films is null)
                return;

            string resultPath = path + @"\Films.xls";

            Excel.Application xlApp = new Excel.Application();

            if (xlApp == null)
            {
                MessageHandler.Handle(new ExcelNotInstalledMessage());
                return;
            }

            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;

            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            xlWorkSheet.Cells[1, 1] = "NameRus";
            xlWorkSheet.Cells[1, 2] = "NameEng";
            xlWorkSheet.Cells[1, 3] = "Rating";

            int i = 2;

            foreach (var film in films)
            {
                xlWorkSheet.Cells[i, 1].Value = film.NameRus;
                xlWorkSheet.Cells[i, 2].Value = film.NameEng;
                xlWorkSheet.Cells[i, 3].Value = film.Rating;

                i++;
            }

            try
            {
                xlWorkBook.SaveAs(resultPath, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                xlWorkBook.Close(true, misValue, misValue);
                xlApp.Quit();

                System.Runtime.InteropServices.Marshal.ReleaseComObject(xlApp);

                MessageHandler.Handle(new SuccessfulMessage(), resultPath);
            }
            catch (Exception ex)
            {
                MessageHandler.Handle(new ExcelBusyMessage(), ex.Message);
            }
        }
    }
}