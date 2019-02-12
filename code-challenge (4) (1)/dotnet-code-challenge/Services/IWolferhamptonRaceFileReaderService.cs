using dotnet_code_challenge.Domain;
using System.Collections.Generic;

namespace dotnet_code_challenge.Services
{
    public interface IWolferhamptonRaceFileReaderService
    {
        IList<Horse> ReadWolferhamptonRaceFile(string filePath);
    }
}