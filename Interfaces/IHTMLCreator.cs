using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GradeSheetCreator.Model;

namespace GradeSheetCreator.Interfaces
{
    public interface IHTMLCreator
    {
        public string GetWebView(List<Model_Gradesheet> gradesheets);
    }
}