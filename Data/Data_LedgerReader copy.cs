// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Runtime.InteropServices;
// using System.Threading.Tasks;
// using DocumentFormat.OpenXml.Packaging;
// using DocumentFormat.OpenXml.Spreadsheet;
// using GradeSheetCreator.Interfaces;
// using GradeSheetCreator.Model;
// using LightWeightExcelReader;


// namespace GradeSheetCreator.DataX
// {
//     public class Data_LedgerReader (IMaps maps, IAdministrativeDetails administrativeDetails, IExamDetails examDetails, ILevels levels, ISubjects subjects) : ILedgerReader
//     {
//         private readonly IMaps _maps = maps;
//         private readonly IAdministrativeDetails _administrativeDetails = administrativeDetails;
//         private readonly IExamDetails _examDetails = examDetails;
//         private readonly ISubjects _subjects = subjects;
//         private readonly ILevels _levels = levels;
//         public static string GetExcelCellName(int row, int col)
//         {
//             string columnName = "";
//             while (col > 0)
//             {
//                 col--;
//                 columnName = (char)('A' + (col % 26)) + columnName;
//                 col /= 26;
//             }
//             return $"{columnName}{row}";
//         }
//         public List<Model_Gradesheet> GetGradesheets(){

//             var excelReader = new ExcelReader("./Excel/ResultCalc.xlsx");
//             var xlWorksheet = excelReader["MyAwesomeSpreadsheet"];
//             xlWorksheet["A1"].ToString();
//             // using (SpreadsheetDocument spreadsheetDocument = SpreadsheetDocument.Open("./Excel/ResultCalc.xlsx", false))
//             // {
//             //     WorkbookPart bkPart = spreadsheetDocument.WorkbookPart ?? throw new Exception("Error in reading excel");
//             //     Workbook workbook = bkPart.Workbook;
//             //     Sheet s = workbook.Descendants<Sheet>().Where(sht => sht.Name == "Entry").FirstOrDefault();
//             //     WorksheetPart wsPart = (WorksheetPart)bkPart.GetPartById(s.Id);
//             //     SheetData sheetdata = wsPart.Worksheet.Elements<SheetData>().FirstOrDefault();
//                 // var xlWorksheet = spreadsheetDocument.WorkbookPart.Workbook.;
//             //     for (int row = 1; row <= worksheet.Dimension.End.Row; row++)
//             //     {
//             //         for (int col = 1; col <= worksheet.Dimension.End.Column; col++)
//             //         {
//             //             Console.WriteLine($"{worksheet.Cells[row, col].Value} ");
//             //         }
//             //         Console.WriteLine(); // New line after each row
//             //     }
//             // }
//             // Excel.Application xlApp = new();
//             // Excel.Workbook xlWorkbook = xlApp.Workbooks.Open("./Excel/ResultCalc.xlsx", ReadOnly: true);
//             // Excel._Worksheet xlWorksheet = (Excel._Worksheet) xlWorkbook.Sheets["Entry"];

//             int startingRow = (int) (_maps.GetMap("StartingRow") ?? throw new InvalidDataException("\"StartingRow\" is missing in Maps.json"));

//             int nameIndex = (int) (_maps.GetMap("Col_Name") ?? throw new InvalidDataException("\"Col_Name\" is missing in Maps.json"));
//             string endingRow = (string) (_maps.GetMap("EndingRow") ?? throw new InvalidDataException("\"EndingRow\" is missing in Maps.json"));
//             int studentid = (int) (_maps.GetMap("Col_Id") ?? throw new InvalidDataException("\"Col_Id\" is missing in Maps.json"));
//             int subject1Start = (int) (_maps.GetMap("Col_Subject1Start") ?? throw new InvalidDataException("\"Col_Subject1Start\" is missing in Maps.json"));

//             int offset_CreditScore = (int) (_maps.GetMap("Offset_CreditScore") ?? throw new InvalidDataException("\"Offset_CreditScore\" is missing in Maps.json"));
//             int offset_GradePoint = (int) (_maps.GetMap("Offset_GradePoint") ?? throw new InvalidDataException("\"Offset_GradePoint\" is missing in Maps.json"));
//             int offset_Grade = (int) (_maps.GetMap("Offset_Grade") ?? throw new InvalidDataException("\"Offset_Grade\" is missing in Maps.json"));

//             int workingDays = (int) (_maps.GetMap("Col_WorkingDays") ?? throw new InvalidDataException("\"Col_WorkingDays\" is missing in Maps.json"));
//             int presentDays = (int) (_maps.GetMap("Col_PresentDays") ?? throw new InvalidDataException("\"Col_PresentDays\" is missing in Maps.json"));

//             int averageGradePoint = (int) (_maps.GetMap("Col_AverageGradePoint") ?? throw new InvalidDataException("\"Col_AverageGradePoint\" is missing in Maps.json"));
//             int averageGrade = (int) (_maps.GetMap("Col_AverageGrade") ?? throw new InvalidDataException("\"Col_AverageGrade\" is missing in Maps.json"));
//             int remarks = (int) (_maps.GetMap("Col_Remarks") ?? throw new InvalidDataException("\"Col_Remarks\" is missing in Maps.json"));
//             int subjectGap = (int) (_maps.GetMap("Gap_Subject") ?? throw new InvalidDataException("\"Gap_Subject\" is missing in Maps.json"));
//             int totalSubject = (int) (_maps.GetMap("Total_Subject") ?? throw new InvalidDataException("\"Total_Subject\" is missing in Maps.json"));

//             int counter = startingRow;
//             int subjectCounter = 1;

//             List<Model_Gradesheet> gradesheets = [];
//             while (true)
//             {
//                 var studentNameCell = xlWorksheet.Cell(counter, nameIndex).Value;
//                 if (studentNameCell is null) break;
//                 var studentName = studentNameCell.ToString();
//                 if (studentName is null) break;
//                 if (studentName.Equals(endingRow, StringComparison.CurrentCultureIgnoreCase)) break;
//                 if (studentName.Equals("", StringComparison.CurrentCultureIgnoreCase)) break;

//                 Model_StudentDetail studentDetail = new() {
//                     Name = xlWorksheet.Cell(counter, nameIndex).Value.ToString() ?? "Error",
//                     Levels = _levels.GetLevel(xlWorksheet.Cell(2, 1).Value.ToString() ?? "UnMarked") ?? "",
//                     Section = xlWorksheet.Cell(2, 2).Value.ToString() ?? "",
//                     StudentId = xlWorksheet.Cell(counter, studentid).Value.ToString() ?? "",
//                     GPA = float.Parse(xlWorksheet.Cell(counter, averageGradePoint).Value.ToString() ?? "0"),
//                     GP = float.Parse(xlWorksheet.Cell(counter, averageGrade).Value.ToString() ?? "0"),
//                     Remarks = xlWorksheet.Cell(counter, remarks).Value.ToString() ?? "",
//                     WorkingDays = int.Parse(xlWorksheet.Cell(counter, workingDays).Value.ToString() ?? "0"),
//                     PresentDays = int.Parse(xlWorksheet.Cell(counter, presentDays).Value.ToString() ?? "0")
//                 };

//                 List<Model_SubjectDetail> subjects = [];
//                 while (subjectCounter <= totalSubject) {
//                     int offsetSubject = subject1Start + (subjectCounter - 1) * subjectGap;
//                     if (float.Parse(xlWorksheet.Cell(counter, offsetSubject + offset_CreditScore).Value.ToString() ?? "0") == 0) {
//                         subjectCounter += 1;
//                         continue;
//                     }

//                     Model_SubjectDetail subject = new() {
//                         Name = _subjects.GetSubject(subjectCounter.ToString()) ?? "",
//                         CreditScore = float.Parse(xlWorksheet.Cell(counter, offsetSubject + offset_CreditScore).Value.ToString() ?? "0"),
//                         GradePoint = float.Parse(xlWorksheet.Cell(counter, offsetSubject + offset_GradePoint).Value.ToString() ?? "0"),
//                         Grade = xlWorksheet.Cell(counter, offsetSubject + offset_Grade).Value.ToString() ?? "",
//                         Priority = subjectCounter
//                     };

//                     subjects.Add(subject);
//                 }

//                 Model_Gradesheet gradesheet = new() {
//                     Sn = counter,
//                     AdministrativeDetails = _administrativeDetails,
//                     ExamDetails = _examDetails,
//                     StudentDetail = studentDetail,
//                     SubjectDetail = [.. subjects.OrderBy(x => x.Priority)],
//                 };

//                 gradesheets.Add(gradesheet);
//             }


//             // Clean up
//             // xlWorkbook.Close(false);
//             // xlApp.Quit();

//             return gradesheets.OrderBy(x => x.Sn).ToList();
//             }
//         }
//     }
// }