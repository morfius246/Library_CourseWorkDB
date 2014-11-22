using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Library_CourseWorkDB.Models;
using Org.BouncyCastle.Tsp;
using PdfRpt.Core.Contracts;
using PdfRpt.FluentInterface;
using WebGrease.Css.Extensions;

namespace Library_CourseWorkDB.BAL
{
    public static class PdfManager
    {
        public static string AppPath
        {
            get { return HttpRuntime.AppDomainAppPath; }
        }

        public static IPdfReportData GetReport(string pdfName, ReadingCard readingCard, BookCopy bookCopy)
        {
            return new PdfReport().DocumentPreferences(doc =>
            {
                doc.RunDirection(PdfRunDirection.LeftToRight);
                doc.Orientation(PageOrientation.Portrait);
                doc.PageSize(PdfPageSize.A4);
                doc.DocumentMetadata(new DocumentMetadata
                {
                    Author = "NTUU \"KPI\"",
                    Application = "PdfRpt",
                    Keywords = "NTUU \"KPI\" Library Symonenko Borys Alexander Grebenyk",
                    Subject = "Get book report",
                    Title = "Report"
                });
            }).DefaultFonts(fonts =>
            {
                fonts.Path(Environment.GetEnvironmentVariable("SystemRoot") + "\\fonts\\arial.ttf",
                                  Environment.GetEnvironmentVariable("SystemRoot") + "\\fonts\\verdana.ttf");
            })
            .PagesFooter(footer =>
            {
                footer.DefaultFooter(DateTime.Now.ToString("MM/dd/yyyy"));
            })
            .PagesHeader(header =>
            {
                header.DefaultHeader(defaultHeader =>
                {
                    defaultHeader.RunDirection(PdfRunDirection.LeftToRight);
                    defaultHeader.Message("НТУУ\"КПІ\"\nЗаявка");
                });
            })
            .MainTableTemplate(template =>
            {
                template.BasicTemplate(BasicTemplate.RainyDayTemplate);
            })
            .MainTablePreferences(table =>
            {

                table.ColumnsWidthsType(TableColumnWidthType.Relative);
                table.NumberOfDataRowsPerPage(11);
            }).MainTableDataSource(dataSource =>
            {
                string authors = null;
                bookCopy.Book.AuthorsList.ForEach(a => authors += a.GetShortName());
                var listOfRows = new[]
                {
                    new{rowName = "Прізвище", value = readingCard.LastName.ToString()},
                    new{rowName = "№ квитка", value = readingCard.ID.ToString()},
                    new{rowName = "Дата", value = DateTime.Now.Date.ToShortDateString()},
                    new{rowName = "Шифр - Інв.номер", value = bookCopy.Book.UDC.Code + "-" + bookCopy.InventaryNumber},
                    new{rowName = "Автор", value = authors},
                    new{rowName = "Заголовок", value = bookCopy.Book.Publishing + " "+ bookCopy.Book.Pages},
                    new{rowName = "Рік", value = bookCopy.Book.EditionYear.ToString()},
                    new{rowName = "Підпис читача", value = "_____________________________________________"},
                    new{rowName = "<<______________>>", value = "_____________________________________________ ("+DateTime.Now.Year.ToString()+"р. )"},
                }.ToList();

                dataSource.AnonymousTypeList(listOfRows);
            }).MainTableColumns(columns =>
            {
                columns.AddColumn(column =>
                {
                    column.PropertyName("rowName");
                    column.CellsHorizontalAlignment(HorizontalAlignment.Left);
                    column.IsVisible(true);
                    column.Order(0);
                    column.Width(1);
                    column.HeaderCell(null);
                });
                columns.AddColumn(column =>
                {
                    column.PropertyName("value");
                    column.CellsHorizontalAlignment(HorizontalAlignment.Left);
                    column.IsVisible(true);
                    column.Order(1);
                    column.Width(3);
                    column.HeaderCell(null);
                    
                });
            }).MainTableEvents(events =>
            {
                events.DataSourceIsEmpty(message: "There is no data available to display.");
            }).Generate(data => data.AsPdfFile(AppPath + "\\Pdf\\" + pdfName + ".pdf"));

        }
    }
}