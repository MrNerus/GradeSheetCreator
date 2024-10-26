using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GradeSheetCreator.Interfaces
{
    public interface ILevels
    {
        public Dictionary<string, string>? GetLevels() { return null; }
        public string? GetLevel(string level) { return null; }
    }
}