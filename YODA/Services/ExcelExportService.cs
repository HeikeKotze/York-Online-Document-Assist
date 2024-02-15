using Blazorise.DataGrid;
using DocumentFormat.OpenXml.Wordprocessing;
using System.Diagnostics;
using System.Net.Mail;
using YODA.Repos;
using YODA.Repos.Models;
using DocumentFormat.OpenXml;
using System.Collections.Generic;
using System.IO;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;

namespace YODA.Services
{
    public class ExcelExportService : IExcelExportService
    {
        private readonly dbfirstcontext _dbc;
        public ExcelExportService(dbfirstcontext dbc)
        {
            _dbc = dbc;
        }
        public List<List<object>> ConvertDataToExcelFormat(List<OffenceBreach> data)
        {
            var fulllist = _dbc.OffenceBreaches.ToList();

            // Create a new list to store the converted data
            var excelData = new List<List<object>>();

            var headers = new List<object>
            {
                "Employee ID",
                "Offence ID",
                "Site ID",
                "Date"
                // Add more headers as needed
            };
            excelData.Add(headers);

            // Iterate over each item in the data parameter
            foreach (var searchData in data)
            {
                // Search for the matching item in the full list
                var matchedItem = fulllist.FirstOrDefault(item => item.Id == searchData.Id); // Adjust the condition based on your requirement

                // If a matching item is found, add it to the new list
                if (matchedItem != null)
                {
                    var rowData = new List<object>();

                    // Example: Map properties of the OffenceBreach object to cell values
                    rowData.Add(matchedItem.EmployeeID);
                    rowData.Add(matchedItem.OffenceID);
                    rowData.Add(matchedItem.SiteID);
                    rowData.Add(matchedItem.Date.Value.ToString("yyyy-mm-dd"));
                    // Add more properties as needed

                    excelData.Add(rowData);
                }
            }

            return excelData;

        }

        public byte[] ExportToExcel(List<List<object>> data, string fileName)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (SpreadsheetDocument document = SpreadsheetDocument.Create(memoryStream, SpreadsheetDocumentType.Workbook))
                {
                    WorkbookPart workbookPart = document.AddWorkbookPart();
                    workbookPart.Workbook = new Workbook();

                    WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
                    var sheetData = new SheetData();
                    worksheetPart.Worksheet = new Worksheet(sheetData);

                    Sheets sheets = document.WorkbookPart.Workbook.AppendChild(new Sheets());
                    Sheet sheet = new Sheet() { Id = document.WorkbookPart.GetIdOfPart(worksheetPart), SheetId = 1, Name = "Statuses" };
                    sheets.Append(sheet);

                    // Populate the worksheet with data
                    foreach (var rowData in data)
                    {
                        Row row = new Row();
                        foreach (var cellValue in rowData)
                        {
                            Cell cell = new Cell();
                            cell.DataType = CellValues.String;
                            cell.CellValue = new CellValue(cellValue.ToString());
                            row.Append(cell);
                        }
                        sheetData.Append(row);
                    }

                    workbookPart.Workbook.Save();
                }

                return memoryStream.ToArray();
            }
        }
    }
}
