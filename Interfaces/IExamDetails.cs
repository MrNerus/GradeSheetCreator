using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GradeSheetCreator.Interfaces
{
    public interface IExamDetails
    {

        public Dictionary<string, string>? GetExamDetails();
        public string? GetExamDetail(string examDetail);
        
    }
}