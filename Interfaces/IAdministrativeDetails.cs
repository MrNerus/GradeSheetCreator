using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GradeSheetCreator.Interfaces
{
    public interface IAdministrativeDetails
    {

        public Dictionary<string, string>? GetAdministrativeDetails();

        public string? GetAdministrativeDetail(string level);
        
    }
}