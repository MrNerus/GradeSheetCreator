using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GradeSheetCreator.Interfaces;
using GradeSheetCreator.Model;

namespace GradeSheetCreator.Worker
{
    public class HTMLCreator() : IHTMLCreator
    {
        private static string Wrap(string gradesheets) {
            string html = $@"
                <!DOCTYPE html>
                <html lang='en'>
                <head>
                    <meta charset='UTF-8'>
                    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
                    <title>Grade Sheet</title>
                    <style>
                        *{{padding: 0; margin: 0; box-sizing: border-box; border: 0px solid black;}}
                        html {{ font-size: 12px;}}
                        @font-face {{
                            font-family: 'comic';
                            src: url('/Files/Font/DynaPuff.ttf') format('truetype');
                        }}
                        @font-face {{
                            font-family: 'comic2';
                            src: url('/Files/Font/Grandstander.ttf') format('truetype');
                        }}

                        body {{ background-color: #ddffdd;}}
                        body > * {{
                            min-height: 100%;
                            width: 148mm;
                            height: 210mm;
                        }}
                        .page {{ 
                            background-color: #ffffdd;
                            border-radius: 1rem;
                            border: 1px solid white;
                            box-shadow: 0.25rem 0.5rem 0.25rem 0.25rem #88888888;
                        }}
                        .content {{ width: 138mm; height: 200mm; }}
                        p, h1, h2, h3, h4, h5, h6 {{ line-height: 150%;}}
                        h1 {{font-size: 1.4rem;}}

                        .flex {{ display: flex;}}
                        .center {{align-items: center; justify-content: center;}}
                        .align_center {{align-items: center;}}
                        .align_start {{align-items: flex-start;}}
                        .align_end {{align-items: flex-end;}}
                        .justify_center {{ justify-content: center;}}
                        .justify_start {{ justify-content: flex-start;}}
                        .justify_end {{ justify-content: flex-end;}}
                        .justify_space {{ justify-content: space-between;}}
                        .vertical {{ flex-direction: column;}}
                        .horizontal {{ flex-direction: row;}}

                        .gapHalf {{ gap: 0.5rem;}}
                        .gap {{ gap: 1rem;}}
                        .gap2 {{ gap: 2rem;}}

                        .paddingHalf {{padding: 0.5rem;}}
                        .padding {{padding: 1rem;}}
                        .padding2 {{padding: 2rem;}}
                        .paddingTopHalf {{padding-top: 0.5rem;}}
                        .paddingTop {{padding-top: 1rem;}}
                        .paddingTop2 {{padding-top: 2rem;}}
                        .paddingBottomHalf {{padding-bottom: 0.5rem;}}
                        .paddingBottom {{padding-bottom: 1rem;}}
                        .paddingBottom2 {{padding-bottom: 2rem;}}
                        .paddingLeftHalf {{padding-left: 0.5rem;}}
                        .paddingLeft {{padding-left: 1rem;}}
                        .paddingLeft2 {{padding-left: 2rem;}}
                        .paddingRightHalf {{padding-right: 0.5rem;}}
                        .paddingRight {{padding-right: 1rem;}}
                        .paddingRight2 {{padding-right: 2rem;}}
                        .paddingHorizontalHalf {{padding-left: 0.5rem; padding-right: 0.5rem; }}
                        .paddingHorizontal {{padding-left: 1rem; padding-right: 1rem; }}
                        .paddingHorizontal2 {{padding-left: 2rem; padding-right: 2rem; }}
                        .paddingVerticalHalf {{padding-top: 0.5rem; padding-bottom: 0.5rem; }}
                        .paddingVertical {{padding-top: 1rem; padding-bottom: 1rem; }}
                        .paddingVertical2 {{padding-top: 2rem; padding-bottom: 2rem; }}

                        .marginHalf {{margin: 0.5rem;}}
                        .margin {{margin: 1rem;}}
                        .margin2 {{margin: 2rem;}}
                        .marginTopHalf {{margin-top: 0.5rem;}}
                        .marginTop {{margin-top: 1rem;}}
                        .marginTop2 {{margin-top: 2rem;}}
                        .marginBottomHalf {{margin-bottom: 0.5rem;}}
                        .marginBottom {{margin-bottom: 1rem;}}
                        .marginBottom2 {{margin-bottom: 2rem;}}
                        .marginLeftHalf {{margin-left: 0.5rem;}}
                        .marginLeft {{margin-left: 1rem;}}
                        .marginLeft2 {{margin-left: 2rem;}}
                        .marginRightHalf {{margin-right: 0.5rem;}}
                        .marginRight {{margin-right: 1rem;}}
                        .marginRight2 {{margin-right: 2rem;}}
                        .marginHorizontalHalf {{margin-left: 0.5rem; margin-right: 0.5rem; }}
                        .marginHorizontal {{margin-left: 1rem; margin-right: 1rem; }}
                        .marginHorizontal2 {{margin-left: 2rem; margin-right: 2rem; }}
                        .marginVerticalHalf {{margin-top: 0.5rem; margin-bottom: 0.5rem; }}
                        .marginVertical {{margin-top: 1rem; margin-bottom: 1rem; }}
                        .marginVertical2 {{margin-top: 2rem; margin-bottom: 2rem; }}

                        .borderHalf {{border: 1px;}}
                        .border {{border: 2px;}}
                        .border2 {{border: 3px;}}
                        .borderTopHalf {{border-top: 1px;}}
                        .borderTop {{border-top: 2px;}}
                        .borderTop2 {{border-top: 3px;}}
                        .borderBottomHalf {{border-bottom: 1px;}}
                        .borderBottom {{border-bottom: 2px;}}
                        .borderBottom2 {{border-bottom: 3px;}}
                        .borderLeftHalf {{border-left: 1px;}}
                        .borderLeft {{border-left: 2px;}}
                        .borderLeft2 {{border-left: 3px;}}
                        .borderRightHalf {{border-right: 1px;}}
                        .borderRight {{border-right: 2px;}}
                        .borderRight2 {{border-right: 3px;}}
                        .borderHorizontalHalf {{border-left: 1px; border-right: 1px; }}
                        .borderHorizontal {{border-left: 2px; border-right: 2px; }}
                        .borderHorizontal2 {{border-left: 3px; border-right: 3px; }}
                        .borderVerticalHalf {{border-top: 1px; border-bottom: 1px; }}
                        .borderVertical {{border-top: 2px; border-bottom: 2px; }}
                        .borderVertical2 {{border-top: 3px; border-bottom: 3px; }}

                        .borderLightGray {{ border-color: lightgrey;}}
                        .borderBlack {{ border-color: black;}}

                        .borderSolid {{border-style: solid;}}

                        .width100 {{width: 100%;}}
                        .height100 {{min-height: 100%;}}
                        .heightAuto {{height: auto;}}

                        .reportHeaders {{ display: grid; grid-template-columns: 1.2fr 3fr 1.5fr 3fr;}}
                        .reportDetails {{ display: grid; grid-template-columns: 1fr 5fr 1fr 1fr 1fr;}}
                        .reportDetails_Footer {{display: grid; grid-template-columns: 1fr 1fr;}}
                        .reportFooter {{ display: grid; grid-template-columns: 1fr 3fr; }}

                        .comic {{ font-family: 'comic'; }}
                        .comic2 {{ font-family: 'comic2'; }}

                        .italic {{ font-style: italic;}}

                        @media print {{
                            @page {{
                                size: 148mm 210mm;
                                margin: 0;
                            }}
                            .page {{
                                clear: both;
                                page-break-after: always;
                                background-color: white !important;
                                border-radius: 0 !important;
                                border: none !important;
                                box-shadow: none !important;
                            }}

                            body {{gap: 0 !important;}}
                        }}

                    </style>
                </head>
                <body class='flex vertical width100 gap'>
                    {gradesheets}
                </body>
                </html> 
                ";
            return html;
        }

        public string GetWebView(List<Model_Gradesheet> gradesheets) {
            List<string> pages = gradesheets.Select(Plot).ToList();
            string webView = Wrap(string.Join("\n", pages));
            return webView;
        }
        private string Plot(Model_Gradesheet gradesheet){
            var examHeading = gradesheet.ExamDetails.GetExamDetail("Heading") ?? throw new InvalidDataException("ExamDetail.json is missing \"Heading\" field.");
            var examType = gradesheet.ExamDetails.GetExamDetail("Type");
            var resultDate = gradesheet.ExamDetails.GetExamDetail("ResultDate");

            var studentName = gradesheet.StudentDetail.Name ?? throw new InvalidDataException($"One or more student has no name.");
            var studentClass = gradesheet.StudentDetail.Levels;
            var studentId = gradesheet.StudentDetail.StudentId;
            var studentSection = gradesheet.StudentDetail.Section;
            
            var reportData = gradesheet.SubjectDetail.Select(x => $@"<tr class='reportDetails borderBottomHalf borderSolid borderLightGray paddingBottomHalf marginBottomHalf'>
                                    <td class='comic2 flex center'>{x.Priority}</td>
                                    <td class='comic2 flex justify_start'>{x.Name}</td>
                                    <td class='comic2 flex center'>{x.CreditScore}</td>
                                    <td class='comic2 flex center'>{x.GradePoint}</td>
                                    <td class='comic2 flex center'>{x.Grade}</td>
                                </tr>").ToList() ?? throw new InvalidDataException($"\"{gradesheet.StudentDetail.StudentId}\" has no subject.");

            var gradePointAverage = gradesheet.StudentDetail.GPA;
            var gradeAverage = gradesheet.StudentDetail.GP;
            var remarks = gradesheet.StudentDetail.Remarks;
            var workingDays = gradesheet.StudentDetail.WorkingDays;
            var presentDays = gradesheet.StudentDetail.PresentDays;

            var instituteName = gradesheet.AdministrativeDetails.GetAdministrativeDetail("Name") ?? throw new InvalidDataException($"AdministrativeDetail.json is missing \"Name\" field.");
            var instituteAddress = gradesheet.AdministrativeDetails.GetAdministrativeDetail("Address") ?? throw new InvalidDataException($"AdministrativeDetail.json is missing \"Address\" field.");
            var instituteMotto = gradesheet.AdministrativeDetails.GetAdministrativeDetail("Motto") ?? throw new InvalidDataException($"AdministrativeDetail.json is missing \"Motto\" field.");
            var instituteAffiliation = gradesheet.AdministrativeDetails.GetAdministrativeDetail("Affiliation") ?? throw new InvalidDataException($"AdministrativeDetail.json is missing \"Affiliation\" field.");
            var instituteEstd = gradesheet.AdministrativeDetails.GetAdministrativeDetail("Estd") ?? throw new InvalidDataException($"AdministrativeDetail.json is missing \"Estd\" field.");
            var instituteDepartment = gradesheet.AdministrativeDetails.GetAdministrativeDetail("Department") ?? throw new InvalidDataException($"AdministrativeDetail.json is missing \"Department\" field.");

            string gradesheetHTML = $@"
                <div class='page flex center'>
                    <div class='content flex vertical justify_space'>
                        <section class='flex align_center justify_center vertical'>
                            <p class='comic'>A Progress Report on</p>
                            <h1 class='comic'>{examHeading}</h1>
                        </section>
                        <section>
                            <table class='width100'>
                                <tr class='reportHeaders'>
                                    <td class='comic paddingBottomHalf'>Name:</td>
                                    <td class='comic2 paddingBottomHalf flex align_end'>{studentName}</td>
                                    <td class='comic paddingBottomHalf'>Exam Type:</td>
                                    <td class='comic2 paddingBottomHalf flex align_end'>{examType}</td>
                                    <td class='comic paddingBottomHalf'>Class:</td>
                                    <td class='comic2 paddingBottomHalf flex align_end'>{studentClass}</td>
                                    <td class='comic paddingBottomHalf'>Id:</td>
                                    <td class='comic2 paddingBottomHalf flex align_end'>{studentId}</td>
                                    <td class='comic paddingBottomHalf'>Section:</td>
                                    <td class='comic2 paddingBottomHalf flex align_end'>{studentSection}</td>
                                    <td class='comic paddingBottomHalf'></td>
                                    <td class='comic2 paddingBottomHalf flex align_end'> </td>
                                </tr>
                            </table>
                        </section>
                        <section>
                            <table>
                                <tr class='reportDetails borderBottom2 borderSolid borderLightGray paddingBottomHalf marginBottomHalf'>
                                    <th class='comic flex center'>S.N.</th>
                                    <th class='comic flex align_center justify_start'>Subject</th>
                                    <th class='comic flex center'>Credit Score</th>
                                    <th class='comic flex center'>Grade Point</th>
                                    <th class='comic flex center'>Grade</th>
                                </tr>
                                {string.Join("\n", reportData)}
                            </table>
                        </section>
                        <section class='reportDetails_Footer'>
                            <div class='flex vertical'>
                                <p><span class='comic'>Grade Point Average: </span><span class='comic2'>{gradePointAverage}</span>
                                <p><span class='comic'>Average Grade: </span><span class='comic2'>{gradeAverage}</span>
                                <p><span class='comic'>Attendance: </span><span class='comic2'>{presentDays} out of {workingDays} days present</span>
                                <p><span class='comic'>Remarks: </span><span class='comic2'>{remarks}</span>
                            </div>
                            <div class='flex vertical align_center justify_end'>
                                <p class='comic2'>.............................................</p>
                                <p class='comic'>Authorized Signature</p>
                                <p class='comic'>Result published on {resultDate}</p>
                            </div>
                        </section>
                        <section class='reportFooter'>
                            <div class='flex center'>
                                <img src='/Files/Image/Logo.png' class='width100 heightAuto'>
                            </div>
                            <div class='flex vertical align_start paddingLeft2 borderLeft2 borderSolid borderLightGray marginLeft'>
                                <h1 class='comic'>{instituteName}</h1>
                                <p class='comic2'>{instituteAffiliation}</p>
                                <p class='comic2 italic'>{instituteMotto}</p>
                                <p class='comic2'>{instituteAddress}</span></p>
                                <p class='comic2'>Established On <span>{instituteEstd}</span></p>
                                <p class='comic2'>{instituteDepartment}</p>
                            </div>
                        </section>
                    </div>
                </div>
            ";
            
            return gradesheetHTML;
        }  
    }
}