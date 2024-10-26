using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GradeSheetCreator.Interfaces
{
    public interface IMaps
    {
        public Dictionary<string, object>? GetMaps();

        public object? GetMap(string map);
    }
}