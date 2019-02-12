using dotnet_code_challenge.Services;
using System.IO;
using Xunit;

namespace dotnet_code_challenge.Test
{
    public class WolferhamptonRaceReaderTest
    {
        [Fact]
        public void WolferhamptonRaceReaderServiceParsesFile()
        {
            var testWolferhamptonFilePath = Path.Combine(Directory.GetCurrentDirectory(), "TestFeedData", "Wolferhampton_Race1.json");

            var wolferhamptonFileReaderService = new WolferhamptonRaceFileReaderService();

            var horses = wolferhamptonFileReaderService.ReadWolferhamptonRaceFile(testWolferhamptonFilePath);

            Assert.Equal(2, horses.Count);
            Assert.Equal("Toolatetodelegate", horses[0].Name);
            Assert.Equal(10M, horses[0].Price);
            Assert.Equal("Fikhaar", horses[1].Name);
            Assert.Equal(4.4M, horses[1].Price);
        }
    }
}
