namespace KinopoiskScraper.Core
{
    public class ExcelFileSaver : IFileSaver, IDisposable
    {
        private object _misValue = System.Reflection.Missing.Value;
        private Excel.Workbook _xlWorkBook;
        private Excel.Worksheet _xlWorkSheet;
        private Excel.Application _xlApp;

        public void SaveOnDisk(List<Film> films)
        {
            if (films is null)
                return;

            if (!TryToCreateExcelApplication(out _xlApp))
                return;

            _xlWorkSheet.Cells[1, 1] = "NameRus";
            _xlWorkSheet.Cells[1, 2] = "NameEng";
            _xlWorkSheet.Cells[1, 3] = "Rating";

            int i = 2;

            foreach (var film in films)
            {
                _xlWorkSheet.Cells[i, 1].Value = film.NameRus;
                _xlWorkSheet.Cells[i, 2].Value = film.NameEng;
                _xlWorkSheet.Cells[i, 3].Value = film.Rating;

                i++;
            }

            string resultPath = Directory.GetCurrentDirectory() + @"\Films.xls";

            try
            {
                _xlWorkBook.SaveAs(resultPath, Excel.XlFileFormat.xlWorkbookNormal, _misValue, _misValue, _misValue, _misValue, Excel.XlSaveAsAccessMode.xlExclusive, _misValue, _misValue, _misValue, _misValue, _misValue);
            }
            catch (Exception ex)
            {
                MessageHandler.Handle(new ExcelBusyMessage(), ex.Message);
            }
            MessageHandler.Handle(new SuccessfulMessage(), resultPath);
        }

        private bool TryToCreateExcelApplication(out Excel.Application xlApp)
        {
            try
            {
                xlApp = new Excel.Application();
                if (xlApp == null)
                {
                    MessageHandler.Handle(new ExcelNotInstalledMessage());
                    return false;
                }

                _xlWorkBook = xlApp.Workbooks.Add(_misValue);
                _xlWorkSheet = (Excel.Worksheet)_xlWorkBook.Worksheets.get_Item(1);
                return true;
            }
            catch (Exception ex)
            {
                MessageHandler.Handle(new UninstalledExcelMessage(), ex.Message);
                xlApp = null;
                return false;
            }
        }
        public void Dispose()
        {
            try
            {
                _xlWorkBook.Close(true, _misValue, _misValue);
                _xlApp.Quit();

                System.Runtime.InteropServices.Marshal.ReleaseComObject(_xlApp);
            }
            catch (Exception ex)
            {
                MessageHandler.Handle(new UnexpectedBehaviourMessage(), ex.Message);
            }
        }
    }
}