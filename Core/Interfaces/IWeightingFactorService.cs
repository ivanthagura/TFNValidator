using System.Collections.Generic;

namespace Core.Interfaces
{
    public interface IWeightingFactorService
    {
        List<KeyValuePair<int, int>> GetWeightingFactors(string file);
    }
}