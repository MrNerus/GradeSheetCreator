using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GradeSheetCreator.Interfaces
{
    public interface ISubjects
    {
        public Dictionary<string, string>? GetSubjects() { return null; }
        public string? GetSubject(string subject) { return null; }
    }
}