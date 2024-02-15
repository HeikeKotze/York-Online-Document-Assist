
using YODA.Repos.Models;
using DocumentFormat.OpenXml;

namespace YODA.Services
{
    public interface IExcelExportService
    {
        List<List<object>> ConvertDataToExcelFormat(List<OffenceBreach> data);
        public byte[] ExportToExcel(List<List<object>> data, string fileName);
    }
}
