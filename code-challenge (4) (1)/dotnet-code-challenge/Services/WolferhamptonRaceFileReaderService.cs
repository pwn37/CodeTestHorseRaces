using dotnet_code_challenge.Domain;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace dotnet_code_challenge.Services
{
    public class WolferhamptonRaceFileReaderService : IWolferhamptonRaceFileReaderService
    {
        public IList<Horse> ReadWolferhamptonRaceFile(string filePath)
        {
            var horses = new List<Horse>();

            using (StreamReader file = File.OpenText(filePath))
            using (JsonTextReader jsonReader = new JsonTextReader(file))
            {
                var json = (JObject)JToken.ReadFrom(jsonReader);

                var horseTokens = json["RawData"]["Participants"];

                var priceTokens = json["RawData"]["Markets"][0]["Selections"];

                horses = horseTokens.Join(
                    priceTokens,
                    h => h.SelectToken("Id").ToString(),
                    p => p.SelectToken("Tags").SelectToken("participant").ToString(),
                    (h, p) => new Horse
                    {
                        Name = h.SelectToken("Name").ToString(),
                        Price = decimal.Parse(p.SelectToken("Price").ToString())
                    }).ToList();
            }

            return horses;
        }
    }
}
