using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GradeSheetCreator.Interfaces;
using System.Text.Json;

namespace GradeSheetCreator.Data
{
    public class Data_ExamDetails: IExamDetails
    {
        private Dictionary<string, string>? ConfigReader() {
            try {
                string jsonContent = File.ReadAllText("./Config/ExamDetail.json");
                Dictionary<string,string>? examDetails = JsonSerializer.Deserialize<Dictionary<string,string>>(jsonContent);

                return examDetails;
            }
            catch {
                return null;
            }

        }

        public Dictionary<string, string>? GetExamDetails() {
            return ConfigReader();
        }

        public string? GetExamDetail(string examDetail) {
            Dictionary<string,string>? examDetails = ConfigReader();

            if (examDetails is null) return null;
            if (!examDetails.TryGetValue(examDetail, out string? value)) return null;

            return value;

        }
        
    }
}