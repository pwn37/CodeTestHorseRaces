using dotnet_code_challenge.Services;
using dotnet_code_challenge.Domain;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace dotnet_code_challenge.Test
{
    public class FeedDataAggregatorServiceTest
    {
        [Fact]
        public void FeedDataAggregatorServiceAggregatesFileOutputs()
        {
            var mockCaulfieldRaceFileReaderService = new Mock<ICaulfieldRaceFileReaderService>();
            mockCaulfieldRaceFileReaderService.Setup(x => x.ReadCaulfieldRaceFile(It.IsAny<string>()))
                .Returns(new List<Horse>
                {
                    new Horse { Name = "abc", Price = 12M },
                    new Horse { Name = "def", Price = 120M }
                });

            var mockWolferhamptonRaceFileReaderService = new Mock<IWolferhamptonRaceFileReaderService>();
            mockWolferhamptonRaceFileReaderService.Setup(x => x.ReadWolferhamptonRaceFile(It.IsAny<string>()))
                .Returns(new List<Horse>
                {
                    new Horse { Name = "ghi", Price = 7M }
                });

            var feedDataAggregatorService = new FeedDataAggregatorService(mockCaulfieldRaceFileReaderService.Object, mockWolferhamptonRaceFileReaderService.Object);

            var horses = feedDataAggregatorService.GenerateAggregateFeedData();

            Assert.Equal(3, horses.Count);
            Assert.Equal("ghi", horses[0].Name);
            Assert.Equal("abc", horses[1].Name);
            Assert.Equal("def", horses[2].Name);
        }
    }
}
