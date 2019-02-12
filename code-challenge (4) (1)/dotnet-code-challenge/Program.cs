using dotnet_code_challenge.Services;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace dotnet_code_challenge
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<ICaulfieldRaceFileReaderService, CaulfieldRaceFileReaderService>()
                .AddSingleton<IWolferhamptonRaceFileReaderService, WolferhamptonRaceFileReaderService>()
                .AddSingleton<IFeedDataAggregatorService, FeedDataAggregatorService>()
                .BuildServiceProvider();

            var horses = serviceProvider.GetRequiredService<IFeedDataAggregatorService>().GenerateAggregateFeedData();

            foreach (var horse in horses)
            {
                Console.WriteLine($"Horse: name {horse.Name} price {horse.Price}.");
            }

            Console.ReadKey();
        }
    }
}
