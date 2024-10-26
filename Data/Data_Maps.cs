using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GradeSheetCreator.Interfaces;
using System.Text.Json;

namespace GradeSheetCreator.Data
{
    public class Data_Maps: IMaps
    {
        private static Dictionary<string, object>? ConfigReader() {
            try {
                string jsonContent = File.ReadAllText("./Config/Maps.json");
                Dictionary<string, object>? maps = JsonSerializer.Deserialize<Dictionary<string,object>>(jsonContent);

                return maps;
            }
            catch {
                return null;
            }

        }

        public Dictionary<string, object>? GetMaps() {
            return ConfigReader();
        }

        public object? GetMap(string map) {
            Dictionary<string, object>? maps = ConfigReader();

            if (maps is null) return null;
            if (!maps.TryGetValue(map, out object? value)) return null;
            return value;
        }
        
    }
}