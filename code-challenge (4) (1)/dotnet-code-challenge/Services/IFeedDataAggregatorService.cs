using dotnet_code_challenge.Domain;
using System.Collections.Generic;

namespace dotnet_code_challenge.Services
{
    public interface IFeedDataAggregatorService
    {
        IList<Horse> GenerateAggregateFeedData();
    }
}