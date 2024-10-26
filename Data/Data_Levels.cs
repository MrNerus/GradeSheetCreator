using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GradeSheetCreator.Interfaces;
using System.Text.Json;

namespace GradeSheetCreator.Data
{
    public class Data_Levels: ILevels
    {
        private Dictionary<string, string>? ConfigReader() {
            try {
                string jsonContent = File.ReadAllText("./Config/Levels.json");
                Dictionary<string,string>? levels = JsonSerializer.Deserialize<Dictionary<string,string>>(jsonContent);

                return levels;
            }
            catch {
                return null;
            }

        }

        public Dictionary<string, string>? GetLevels() {
            return ConfigReader();
        }

        public string? GetLevel(string level) {
            Dictionary<string,string>? levels = ConfigReader();

            if (levels is null) return null;
            if (!levels.TryGetValue(level, out string? value)) return null;

            return value;

        }
        
    }
}