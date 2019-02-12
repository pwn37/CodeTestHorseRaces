using dotnet_code_challenge.Domain;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace dotnet_code_challenge.Services
{
    public class CaulfieldRaceFileReaderService : ICaulfieldRaceFileReaderService
    {
        public IList<Horse> ReadCaulfieldRaceFile(string filePath)
        {
            var horses = new List<Horse>();
            using (FileStream raceFileStream = new FileStream(filePath, FileMode.Open))
            {
                XDocument xd = XDocument.Load(raceFileStream);
                XElement fileRoot = xd.Document.Root;

                var horseElements = fileRoot.Descendants("race").Elements("horses").Descendants("horse");

                var priceElements = fileRoot.Descendants("price").Descendants("horse");

                horses = horseElements.Join(
                    priceElements, 
                    h => h.Element("number").Value, 
                    p => p.Attribute("number").Value, 
                    (h, p) => new Horse
                    {
                        Name = h.Attribute("name").Value,
                        Price = decimal.Parse(p.Attribute("Price").Value)
                    }).ToList();
            }

            return horses;
        }
    }
}
