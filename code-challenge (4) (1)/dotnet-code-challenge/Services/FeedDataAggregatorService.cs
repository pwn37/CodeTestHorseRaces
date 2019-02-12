using dotnet_code_challenge.Domain;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace dotnet_code_challenge.Services
{
    public class FeedDataAggregatorService : IFeedDataAggregatorService
    {
        private readonly ICaulfieldRaceFileReaderService _caulfieldRaceFileReaderService;
        private readonly IWolferhamptonRaceFileReaderService _wolferhamptonRaceFileReaderService;
        private readonly string CaulfieldFilePath = Path.Combine(Directory.GetCurrentDirectory(), "FeedData", "Caulfield_Race1.xml");
        private readonly string WolferhamptonFilePath = Path.Combine(Directory.GetCurrentDirectory(), "FeedData", "Wolferhampton_Race1.json");

        public FeedDataAggregatorService(ICaulfieldRaceFileReaderService caulfieldRaceFileReaderService, 
            IWolferhamptonRaceFileReaderService wolferhamptonRaceFileReaderService)
        {
            _caulfieldRaceFileReaderService = caulfieldRaceFileReaderService;
            _wolferhamptonRaceFileReaderService = wolferhamptonRaceFileReaderService;
        }

        public IList<Horse> GenerateAggregateFeedData()
        {
            var caulfieldHorses = _caulfieldRaceFileReaderService.ReadCaulfieldRaceFile(CaulfieldFilePath);
            var wolferhamptonHorses = _wolferhamptonRaceFileReaderService.ReadWolferhamptonRaceFile(WolferhamptonFilePath);

            return caulfieldHorses.Concat(wolferhamptonHorses).OrderBy(x => x.Price).ToList();
        }
    }
}
