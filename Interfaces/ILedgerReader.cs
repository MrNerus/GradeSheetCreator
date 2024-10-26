using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GradeSheetCreator.Interfaces;
using GradeSheetCreator.Model;

namespace GradeSheetCreator.Interfaces
{
    public interface ILedgerReader {
        public List<Model_Gradesheet> GetGradesheets();
    }
}