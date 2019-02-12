using dotnet_code_challenge.Services;
using System.IO;
using Xunit;

namespace dotnet_code_challenge.Test
{
    public class CaulfieldRaceReaderTest
    {
        [Fact]
        public void CaulfieldRaceReaderServiceParsesFile()
        {
            var testCaulfieldFilePath = Path.Combine(Directory.GetCurrentDirectory(), "TestFeedData", "Caulfield_Race1.xml");

            var caulfieldFileReaderService = new CaulfieldRaceFileReaderService();

            var horses = caulfieldFileReaderService.ReadCaulfieldRaceFile(testCaulfieldFilePath);

            Assert.Equal(2, horses.Count);
            Assert.Equal("Advancing", horses[0].Name);
            Assert.Equal(4.2M, horses[0].Price);
            Assert.Equal("Coronel", horses[1].Name);
            Assert.Equal(12M, horses[1].Price);
        }
    }
}
