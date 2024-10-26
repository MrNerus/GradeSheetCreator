using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GradeSheetCreator.Model
{
    public class Model_SubjectDetail
    {
        public string Name {get; set;} = String.Empty;
        public DateTime ExamDate {get; set;} = DateTime.Parse("2024-01-01");
        public float FullMarks {get; set;} = 0;
        public float PassMarks {get; set;} = 0;
        public float ObtainedMarks {get; set;} = 0;
        public float CreditScore {get; set;} = 0;
        public float Percent {get; set;} = 0;
        public float GradePoint {get; set;} = 0;
        public string Grade {get; set;} = "NG";
        public int Priority {get; set;} = 1;

    }
}