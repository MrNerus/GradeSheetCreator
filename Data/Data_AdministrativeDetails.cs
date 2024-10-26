using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GradeSheetCreator.Interfaces;
using System.Text.Json;

namespace GradeSheetCreator.Data
{
    public class Data_AdministrativeDetails: IAdministrativeDetails
    {
        private Dictionary<string, string>? ConfigReader() {
            try {
                string jsonContent = File.ReadAllText("./Config/AdministrativeDetail.json");
                Dictionary<string,string>? administrativeDetails = JsonSerializer.Deserialize<Dictionary<string,string>>(jsonContent);

                return administrativeDetails;
            }
            catch {
                return null;
            }

        }

        public Dictionary<string, string>? GetAdministrativeDetails() {
            return ConfigReader();
        }

        public string? GetAdministrativeDetail(string administrativeDetail) {
            Dictionary<string,string>? administrativeDetails = ConfigReader();

            if (administrativeDetails is null) return null;
            if (!administrativeDetails.TryGetValue(administrativeDetail, out string? value)) return null;

            return value;

        }
    }
}