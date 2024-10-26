using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GradeSheetCreator.Interfaces;
using System.Text.Json;

namespace GradeSheetCreator.Data
{
    public class Data_Subjects: ISubjects
    {
        private static Dictionary<string, string>? ConfigReader() {
            try {
                string jsonContent = File.ReadAllText("./Config/Subjects.json");
                Dictionary<string,string>? subjects = JsonSerializer.Deserialize<Dictionary<string,string>>(jsonContent);

                return subjects;
            }
            catch {
                return null;
            }

        }

        public Dictionary<string, string>? GetSubjects() {
            return ConfigReader();
        }

        public string? GetSubject(string subject) {
            Dictionary<string,string>? subjects = ConfigReader();

            if (subjects is null) return null;
            if (!subjects.TryGetValue(subject, out string? value)) return null;

            return value;

        }
        
    }
}