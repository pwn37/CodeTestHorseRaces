using dotnet_code_challenge.Domain;
using System.Collections.Generic;

namespace dotnet_code_challenge.Services
{
    public interface ICaulfieldRaceFileReaderService
    {
        IList<Horse> ReadCaulfieldRaceFile(string filePath);
    }
}