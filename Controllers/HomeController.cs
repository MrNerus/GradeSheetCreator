using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GradeSheetCreator.Data;
using GradeSheetCreator.Interfaces;
using GradeSheetCreator.Model;
using GradeSheetCreator.Worker;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Html;

namespace GradeSheetCreator.Controllers
{
    public class HomeController : ControllerBase
    {
        private readonly IMaps maps;
        private readonly IAdministrativeDetails administrativeDetails;
        private readonly IExamDetails examDetails;
        private readonly ILevels levels;
        private readonly ISubjects subjects;
        private readonly ILedgerReader ledgerReader; 
        private readonly IHTMLCreator htmlCreator;
        public HomeController()
        {
            maps = new Data_Maps();
            administrativeDetails = new Data_AdministrativeDetails();
            examDetails = new Data_ExamDetails();
            levels = new Data_Levels();
            subjects = new Data_Subjects();
            ledgerReader = new Data_LedgerReader(maps, administrativeDetails, examDetails, levels, subjects);
            htmlCreator = new HTMLCreator();
        }

       [HttpGet("/Result/")]
        public IActionResult GetResult() {
            try {
                WebViewService webViewService = new(ledgerReader, htmlCreator);
                string gradesheets = webViewService.GetGradesheets();
                return Content(gradesheets, "text/html");
            }
            catch (Exception e) {
                return Content($"{e.Message}");
            }
        }
    }
}