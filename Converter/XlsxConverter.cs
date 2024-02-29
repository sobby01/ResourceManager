using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using ClosedXML.Excel;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using ResourceManager.Exceptions;
using ResourceManager.Core;
using ResourceManager.Storage;
using System.Text.RegularExpressions;

namespace ResourceManager.Converter
{
    public class XlsxConverter : ConverterBase, ResourceManager.Converter.IConverter
    {
        private const string COMMENTS_KEY = "[Comments]";
        private double ColumnValueWidth = 40;
        private double ColumnCommentWidth = 40;


        public XlsxConverter(VSSolution solution)
            : base(solution)
        {
        }
        public XlsxConverter(IEnumerable<VSProject> projects)
            : base(projects)
        {
        }
        public XlsxConverter(IEnumerable<IResourceFileGroup> fileGroups, VSSolution solution)
            : base(fileGroups, solution)
        {
        }
        public XlsxConverter(VSProject project)
            : base(project)
        {
        }

        public void Export(string filePath)
        {
            using (var workbook = new XLWorkbook(XLEventTracking.Disabled))
            {
                IEnumerable<CultureInfo> cultures = null;
                if (Cultures != null)
                    cultures = Cultures.Select(vc => vc.Culture);
                else
                    cultures = Solution.Cultures.Keys;

                IEnumerable<VSProject> projects = Projects;
                if (Projects == null)
                    projects = (IEnumerable<VSProject>)Solution.Projects.Values;

                foreach (var project in projects)
                {
                    var data = GetData(project, cultures);

                    if (IncludeProjectsWithoutTranslations || data.Count() > 0)
                    {
                        AddProjectInSingleWorksheet(project, workbook, cultures, data);
                        //AddProjectPerWorksheet(project, workbook, cultures, data);
                    }
                    //AddProject(project, workbook, cultures, data);
                }

                workbook.SaveAs(filePath);
            }
        }
        private IEnumerable<ResourceDataGroupBase> GetData(VSProject project, IEnumerable<CultureInfo> cultures)
        {
            var data = new List<ResourceDataGroupBase>();
            IList<ResourceDataGroupBase> uncompletedDataGroups = null;

            if (ExportDiff)
                uncompletedDataGroups = project.GetUncompleteDataGroups(cultures);
            
            IEnumerable<IResourceFileGroup> resxGroups = project.ResxGroups.Values;
            if (FileGroups != null && FileGroups.Count() > 0)
                resxGroups = project.ResxGroups.Values.Intersect(FileGroups);

            foreach (IResourceFileGroup group in resxGroups)
            {
                IEnumerable<ResourceDataGroupBase> groupDataValues = group.AllData.Values
                    .Where(resxGroup => uncompletedDataGroups == null || uncompletedDataGroups.Contains(resxGroup));

                if (IgnoreInternalResources)
                {
                    groupDataValues = groupDataValues.Where(resxGroup => !resxGroup.Name.StartsWith(">>"));
                }

                data.AddRange(groupDataValues);
            }

            return data;
        }

        private void AddProjectInSingleWorksheet(VSProject project, XLWorkbook workbook, IEnumerable<CultureInfo> cultures, IEnumerable<ResourceDataGroupBase> data)
        {

            var culturesList = cultures.ToList();
            List<IXLWorksheet> xlWorkSheets = new List<IXLWorksheet>();
            string cultureName = culturesList[0].Name;
            string workSheetName = project.ShortName;
            CultureInfo defaultCulture = new CultureInfo("en-US");
            //int totalRows = data.Where(x => x.ResxData.ContainsKey(culture) &&
            //x.ResxData[culture].Comment != null &&
            //x.ResxData[culture].Comment.ToUpperInvariant() == "pending".ToUpperInvariant()).Count();

            int totalRows = data.Where(x => x.ResxData.ContainsKey(defaultCulture)).Count();
            if (totalRows <= 0) return;
            int c = 3;
            var worksheet = workbook.Worksheets.Add(workSheetName);
            worksheet.Style.NumberFormat.SetNumberFormatId(49); // Format: Text

            worksheet.Cell(1, 1).Value = project.Name;
            worksheet.Cell(1, 2).Value = "Keys";

            worksheet.Column(c).Width = ColumnValueWidth;
            worksheet.Column(c).Style.Alignment.SetWrapText(true);
            worksheet.Row(1).Style.Font.SetBold(true);
            worksheet.Columns(1, 2).Style.Font.SetFontColor(XLColor.Gray);
            worksheet.Columns(1, 2).Width = 12.0;

            worksheet.Style.Alignment.SetVertical(XLAlignmentVerticalValues.Top);
            worksheet.Cell(1, c).Value = "en-US";

            c++;
            foreach (var culture in culturesList)
            {
                if (culture.Name == "en-US") continue;

                worksheet.Cell(1, c).Value = culture.Name;
                c++;
            }
            ProcessDataInSingleSheet(data, culturesList, worksheet);
        }

        private void ProcessDataInSingleSheet(IEnumerable<ResourceDataGroupBase> data, List<CultureInfo> culturesList, IXLWorksheet worksheet)
        {
            try
            {
                CultureInfo defaultCulture = new CultureInfo("en-US");
                int rowIndex = 2;
                int totalIndexers = 0;
                int c = 3;
                foreach (ResourceDataGroupBase dataGroup in data)
                {
                    if (!dataGroup.ResxData.ContainsKey(defaultCulture))
                    {
                        continue;
                    }
                    totalIndexers++;
                    c = 3;
                    var cell = worksheet.Cell(rowIndex, c);
                    bool pendingFound = false;

                    foreach (var culture in culturesList)
                    {
                        if (culture == null || culture.Name == "en-US")
                        {
                            continue;
                        }

                        if (dataGroup.ResxData.ContainsKey(culture))
                        {
                            string comment = dataGroup.ResxData[culture].Comment;
                            string defaultValue = dataGroup.ResxData[defaultCulture].Value;
                            // Check if the comment is "pending" or if the value is empty
                            if (string.Equals(comment, "pending", StringComparison.OrdinalIgnoreCase) ||
                                string.IsNullOrWhiteSpace(dataGroup.ResxData[culture].Value) ||
                                string.Equals(dataGroup.ResxData[defaultCulture].Value, dataGroup.ResxData[culture].Value))
                            {
                                pendingFound = true;
                                break;
                            }
                        }
                    }

                    if (pendingFound)
                    {
                        // Write information to the Excel worksheet only once
                        worksheet.Cell(rowIndex, 1).Value = dataGroup.FileGroup.ID;
                        worksheet.Cell(rowIndex, 2).Value = dataGroup.Name;
                        var dataToWriteIncell = worksheet.Cell(rowIndex, c);
                        dataToWriteIncell.DataType = XLCellValues.Text;
                        dataToWriteIncell.Value = dataGroup.ResxData[new CultureInfo("en-US")].Value;
                        dataToWriteIncell.DataType = XLCellValues.Text;

                        c++;
                        foreach (var culture in culturesList)
                        {
                            try
                            {
                                if (culture == null || culture.Name == "en-US")
                                {
                                    continue;
                                }
                                string comment = dataGroup.ResxData[culture].Comment;
                                dataToWriteIncell = worksheet.Cell(rowIndex, c);
                                dataToWriteIncell.DataType = XLCellValues.Text;
                                // Check if the comment is "pending" or if the value is empty
                                if (string.Equals(comment, "done", StringComparison.OrdinalIgnoreCase) ||
                                    !string.Equals(dataGroup.ResxData[defaultCulture].Value, dataGroup.ResxData[culture].Value))
                                {
                                    dataToWriteIncell.Value = dataGroup.ResxData[culture].Value;
                                }
                                else
                                {
                                    dataToWriteIncell.Value = "";
                                }
                                dataToWriteIncell.DataType = XLCellValues.Text; // Set datatype after value is assigned
                                c++;
                            }
                            catch (Exception ex)
                            {

                            }
                        }
                        rowIndex++;
                    }
                    else
                    {
                        continue;// do not need to include the row.
                    }
                }
            }
            catch(Exception ex)
            {

            }
            
        }

        private void AddProjectPerWorksheet(VSProject project, XLWorkbook workbook, IEnumerable<CultureInfo> cultures, IEnumerable<ResourceDataGroupBase> data)
        {
            List<IXLWorksheet> xlWorkSheets = new List<IXLWorksheet>();

            foreach (var culture in cultures)
            {
                string cultureName = culture.Name;

                string workSheetName = project.ShortName + "_" + cultureName;

                //int totalRows = data.Where(x => x.ResxData.ContainsKey(culture) &&
                //x.ResxData[culture].Comment != null &&
                //x.ResxData[culture].Comment.ToUpperInvariant() == "pending".ToUpperInvariant()).Count();

                int totalRows = data.Where(x => x.ResxData.ContainsKey(culture)).Count();

                if (totalRows > 0)
                {
                    var worksheet = workbook.Worksheets.Add(workSheetName);

                    AddHeaderPerCulturePerSheet(worksheet, project, culture);

                    worksheet.Row(1).Style.Font.SetBold(true);
                    worksheet.Columns(1, 2).Style.Font.SetFontColor(XLColor.Gray);
                    worksheet.Columns(1, 2).Width = 12.0;

                    worksheet.Style.Alignment.SetVertical(XLAlignmentVerticalValues.Top);
                    ProcessData(data, culture, worksheet);
                }
            }
        }

        private void ProcessData(IEnumerable<ResourceDataGroupBase> data, CultureInfo culture, IXLWorksheet worksheet)
        {
            int rowIndex = 2;
            int c = 3;
            foreach (ResourceDataGroupBase dataGroup in data)
            {
                var cell = worksheet.Cell(rowIndex, c);

                if (dataGroup.ResxData.ContainsKey(culture))
                {
                    string comment = dataGroup.ResxData[culture].Comment;
                    if (comment != null && comment.ToUpperInvariant() == "pending".ToUpperInvariant())
                    {
                        worksheet.Cell(rowIndex, 1).Value = dataGroup.FileGroup.ID;
                        worksheet.Cell(rowIndex, 2).Value = dataGroup.Name;
                        cell.Value = dataGroup.ResxData[culture].Value;

                        if (dataGroup.ResxData[culture].Value == "")
                        {
                            CultureInfo cult = new CultureInfo("en-US");
                            cell.Value = dataGroup.ResxData[cult].Value;
                        }
                        cell.DataType = XLCellValues.Text; // need to set datatype after value is assigned, otherwise the datatype is parsed
                        rowIndex++;
                    }

                }
                else
                {
                    try
                    {
                        CultureInfo cult = new CultureInfo("en-US");
                        cell.Value = dataGroup.ResxData[cult].Value;

                        worksheet.Cell(rowIndex, 1).Value = dataGroup.FileGroup.ID;
                        worksheet.Cell(rowIndex, 2).Value = dataGroup.Name;

                        if (ExportComments)
                            worksheet.Cell(rowIndex, c++).Value = "";
                        cell.DataType = XLCellValues.Text; // need to set datatype after value is assigned, otherwise the datatype is parsed
                        rowIndex++;
                    }
                    catch(Exception ex)
                    {

                    }
                }
            }
        }

        private void AddHeaderPerCulturePerSheet(IXLWorksheet worksheet, VSProject project, CultureInfo culture)
        {
            worksheet.Style.NumberFormat.SetNumberFormatId(49); // Format: Text

            worksheet.Cell(1, 1).Value = project.Name;
            worksheet.Cell(1, 2).Value = "Keys";

            int c = 3;

            worksheet.Column(c).Width = ColumnValueWidth;
            worksheet.Column(c).Style.Alignment.SetWrapText(true);
            worksheet.Cell(1, c).Value = culture.Name;
        }

        private void AddProject(VSProject project, XLWorkbook workbook, IEnumerable<CultureInfo> cultures, IEnumerable<ResourceDataGroupBase> data)
        {
            var worksheet = workbook.Worksheets.Add(project.ShortName);           

            AddHeader(worksheet, project, cultures);

            int rowIndex = 2;
            foreach (ResourceDataGroupBase dataGroup in data)
            {
                AddData(dataGroup, worksheet, rowIndex, cultures);
                rowIndex++;
            }

            if (AutoAdjustLayout)
            {
                worksheet.Row(1).Style.Font.SetBold(true);
                worksheet.Columns(1, 2).Style.Font.SetFontColor(XLColor.Gray);
                worksheet.Columns(1, 2).Width = 12.0;

                worksheet.Style.Alignment.SetVertical(XLAlignmentVerticalValues.Top);
            }
        }
        private void AddHeader(IXLWorksheet worksheet, VSProject project, IEnumerable<CultureInfo> cultures)
        {
            worksheet.Style.NumberFormat.SetNumberFormatId(49); // Format: Text

            worksheet.Cell(1, 1).Value = project.Name;
            worksheet.Cell(1, 2).Value = "Keys";            

            int c = 3;
            foreach (var culture in cultures)
            {
                if (AutoAdjustLayout)
                {
                    worksheet.Column(c).Width = ColumnValueWidth;
                    worksheet.Column(c).Style.Alignment.SetWrapText(true);
                }
                worksheet.Cell(1, c++).Value = culture.Name;


                if (ExportComments)
                {
                    if (AutoAdjustLayout)
                    {
                        worksheet.Column(c).Width = ColumnCommentWidth;
                        worksheet.Column(c).Style.Alignment.SetWrapText(true);
                    }
                    worksheet.Cell(1, c++).Value = culture.Name + " " + COMMENTS_KEY;
                }
            }
        }

        private void AddData(ResourceDataGroupBase dataGroup, IXLWorksheet worksheet, int rowIndex, IEnumerable<CultureInfo> cultures)
        {
            worksheet.Cell(rowIndex, 1).Value = dataGroup.FileGroup.ID;
            worksheet.Cell(rowIndex, 2).Value = dataGroup.Name;

            int c = 3;
            foreach (var culture in cultures)
            {
                var cell = worksheet.Cell(rowIndex, c++);
                if (dataGroup.ResxData.ContainsKey(culture))
                {
                    string comment = dataGroup.ResxData[culture].Comment;
                    if(comment != null && comment.ToUpperInvariant() == "pending".ToUpperInvariant())
                    {
                        cell.Value = dataGroup.ResxData[culture].Value;
                        if (dataGroup.ResxData[culture].Value == "")
                        {
                           // cell.Value = dataGroup.ResxData[""].Value;
                        }
                        
                        if (ExportComments)
                        {
                            worksheet.Cell(rowIndex, c++).Value = dataGroup.ResxData[culture].Comment;
                        }
                    }
                    
                }
                else
                {
                    cell.Value = "";
                    if (ExportComments)
                        worksheet.Cell(rowIndex, c++).Value = "";
                }
                cell.DataType = XLCellValues.Text; // need to set datatype after value is assigned, otherwise the datatype is parsed
            }
        }

        /// <summary>
        /// Returns VS Project name of worksheet in Excel file
        /// </summary>
        /// <param name="worksheet"></param>
        /// <returns></returns>
        private string getProjectName(IXLWorksheet worksheet)
        {
            string firstCellVal = worksheet.FirstCell().Value.ToString();

            // Project names are saved in first cell, because excel worksheet names are limited to 31 characters. Keep old behaviour for compatibility
            if (firstCellVal == "ID")
                return worksheet.Name;
            else
                return firstCellVal; 
        }
        public int Import(string filePath)
        {
            int count = 0;

            using (var workbook = new XLWorkbook(filePath, XLEventTracking.Disabled))
            {
                foreach (var worksheet in workbook.Worksheets)
                {
                    string projectName = getProjectName(worksheet);
                    if (!Solution.Projects.ContainsKey(projectName))
                    {
                        continue;
                    }

                    var project = Solution.Projects[projectName];
                    var translations = TranslationRow.LoadRows(worksheet);

                    foreach (var t in translations)
                    {
                        ResourceDataGroupBase dataGroup = null;
                        if (!project.ResxGroups[t.ID].AllData.ContainsKey(t.Key))
                        {
                            dataGroup = project.ResxGroups[t.ID].CreateDataGroup(t.Key);
                            project.ResxGroups[t.ID].AllData.Add(t.Key, dataGroup);
                        }
                        else
                            dataGroup = project.ResxGroups[t.ID].AllData[t.Key];

                        foreach (var te in t.Translations)
                        {
                            if (!dataGroup.ResxData.ContainsKey(te.Key))
                            {
                                project.ResxGroups[t.ID].SetResourceData(t.Key, te.Value, te.Key);
                                count++;
                            }
                            else if (dataGroup.ResxData[te.Key].Value != te.Value)
                            {
                                dataGroup.ResxData[te.Key].Value = te.Value;
                                dataGroup.ResxData[te.Key].Comment = "done";
                                count++;
                            }
                        }
                        foreach (var te in t.Comments)
                        {
                            if (!dataGroup.ResxData.ContainsKey(te.Key))
                            {
                                project.ResxGroups[t.ID].SetResourceDataComment(t.Key, te.Value, te.Key);
                                count++;
                            }
                            else if (dataGroup.ResxData[te.Key].Comment != te.Value)
                            {
                                dataGroup.ResxData[te.Key].Comment = te.Value;
                                count++;
                            }
                        }
                    }
                }
            }
            return count;
        }

        

        protected class TranslationRow
        {
            public string ID { get; set; }
            public string Key { get; set; }

            private Dictionary<CultureInfo, string> translations = new Dictionary<CultureInfo, string>();
            private Dictionary<CultureInfo, string> comments = new Dictionary<CultureInfo, string>();
            public string this[CultureInfo culture]
            {
                get
                {
                    return translations[culture];
                }
                set
                {
                    translations[culture] = value;
                }
            }

            public Dictionary<CultureInfo, string> Translations
            {
                get
                {
                    return translations;
                }
            }
            public Dictionary<CultureInfo, string> Comments
            {
                get
                {
                    return comments;
                }
            }

            public static List<TranslationRow> LoadRows(IXLWorksheet worksheet)
            {
                var result = new List<TranslationRow>();

                var cultures = ReadCultures(worksheet);
                var commentColumnIndexes = cultures.Select(x => x.CommentColumnIndex);
                var textColumnIndexes = cultures.Select(x => x.TextColumnIndex);
                int lastColumn = commentColumnIndexes.Concat(textColumnIndexes).Max(x => x);

                foreach (var row in worksheet.RowsUsed().Skip(1))
                {
                    var textValues = row.Cells(1, lastColumn + 1).Select(cell => (cell.Value != null ? cell.Value.ToString() : null)).ToList<String>();
                
					if (textValues.Any())
                    {
                        var customer = new TranslationRow();
                        customer.ID = textValues[0];
                        customer.Key = textValues[1];

                        foreach(var culture in cultures) 
                        {
                            if (culture.TextColumnIndex > 0 && culture.TextColumnIndex < textValues.Count &&
                                !String.IsNullOrWhiteSpace(textValues[culture.TextColumnIndex]))
                            {
                                var utf8 = Encoding.UTF8;
                                byte[] utfBytes = utf8.GetBytes(textValues[culture.TextColumnIndex]);
                                string myString = utf8.GetString(utfBytes, 0, utfBytes.Length);

                                customer.Translations.Add(culture.Culture, myString);
                            }
                               
                            if (culture.CommentColumnIndex > 0 && culture.CommentColumnIndex < textValues.Count
                                && !String.IsNullOrWhiteSpace(textValues[culture.CommentColumnIndex]))
                            {
                                customer.Comments.Add(culture.Culture, textValues[culture.CommentColumnIndex]);
                            }
                                
                        }
                        result.Add(customer);
                    }
                    else
                    {
                        break;
                    }
                }

                return result;
            }

            public static CultureInfo CreateCultureInfo(string cultureString)
            {
                if (cultureString.ToUpperInvariant().Contains("es".ToUpperInvariant()))
                {
                    return new CultureInfo("es-ES");
                }
                else if (cultureString.ToUpperInvariant().Contains("pt".ToUpperInvariant()) || 
                    cultureString.ToUpperInvariant().Contains("br".ToUpperInvariant()))
                {
                    return new CultureInfo("pt-BR");
                }
                else if (cultureString.ToUpperInvariant().Contains("ru".ToUpperInvariant()))
                {
                    return new CultureInfo("ru-RU");
                }
                else if (cultureString.ToUpperInvariant().Contains("zh".ToUpperInvariant()))
                {
                    return new CultureInfo("zh-CN");
                }
                else if (cultureString.ToUpperInvariant().Contains("tr".ToUpperInvariant()))
                {
                    return new CultureInfo("tr-TR");
                }
                else if (cultureString.ToUpperInvariant().Contains("cs".ToUpperInvariant()))
                {
                    return new CultureInfo("cs-CZ");
                }
                else if (cultureString.ToUpperInvariant().Contains("de".ToUpperInvariant()))
                {
                    return new CultureInfo("de-DE");
                }
                else if (cultureString.ToUpperInvariant().Contains("th".ToUpperInvariant()))
                {
                    return new CultureInfo("th-TH");
                }
                else if (cultureString.ToUpperInvariant().Contains("fr".ToUpperInvariant()))
                {
                    return new CultureInfo("fr-FR");
                }
                else
                {
                    return null;
                }
            }


            public static IList<TranslationColumn> ReadCultures(IXLWorksheet worksheet)
            {
                var textValues = worksheet.Row(1).Cells().Where(cell => cell.Value != null).Select(cell => cell.Value.ToString()).ToList<String>();
                var cols = textValues.Skip(2).Where(s => !s.Contains(COMMENTS_KEY)).ToList<String>();

                var list = new List<TranslationColumn>();
                foreach (var s in cols)
                {
                    var cInfo = CreateCultureInfo(s);
                    if(cInfo != null)
                    {
                        var textColumn = new TranslationColumn(cInfo);
                        textColumn.TextColumnIndex = textValues.IndexOf(s);

                        string commentsKey = s;
                        string commentColumn = null;

                        commentsKey += " [Comments]";
                        commentColumn = textValues.Skip(2).Where(t => t.Equals(commentsKey)).FirstOrDefault();

                        if (commentColumn == null && String.IsNullOrEmpty(s))
                            commentColumn = textValues.Skip(2).Where(t => t.Equals(COMMENTS_KEY)).FirstOrDefault();

                        if (commentColumn != null)
                            textColumn.CommentColumnIndex = textValues.IndexOf(commentColumn);

                        list.Add(textColumn);
                    }
                   
                }

                return list;
            }
            public static int GetColumnsCount(IEnumerable<TranslationColumn> list)
            {
                int count = 0;

                foreach (var column in list)
                {
                    if (column.TextColumnIndex > -1)
                        count++;
                    if (column.CommentColumnIndex > -1)
                        count++;
                }

                return count;
            }
        }

        protected class TranslationColumn
        {
            public TranslationColumn(CultureInfo culture)
            {
                Culture = culture;
                TextColumnIndex = -1;
                CommentColumnIndex = -1;
            }

            public CultureInfo Culture
            {
                get;
                private set;
            }
            public int TextColumnIndex
            {
                get;
                set;
            }
            public int CommentColumnIndex
            {
                get;
                set;
            }
        }
    }
}
