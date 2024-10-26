using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GradeSheetCreator.Model
{
    public class Model_StudentDetail
    {
        public string Name {get; set;} = String.Empty;
        public string Levels {get; set;} = String.Empty;
        public string Section {get; set;} = String.Empty;
        public string StudentId {get; set;} = String.Empty;
        public float Percentage {get; set;} = 0;
        public float GPA {get; set;} = 0;
        public string GP {get; set;} = String.Empty;
        public string Remarks {get; set;} = String.Empty;
        public int WorkingDays {get; set;} = 0;
        public int PresentDays {get; set;} = 0;
        public int AbsentDays {get; set;} = 0;
    }
}