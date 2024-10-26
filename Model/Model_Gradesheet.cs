using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GradeSheetCreator.Interfaces;

namespace GradeSheetCreator.Model
{
    public class Model_Gradesheet
    {
        public int Sn { get; set; }
        public required IAdministrativeDetails AdministrativeDetails;
        public required IExamDetails ExamDetails;
        public Model_StudentDetail StudentDetail = new();
        public List<Model_SubjectDetail> SubjectDetail = [];
    }
}