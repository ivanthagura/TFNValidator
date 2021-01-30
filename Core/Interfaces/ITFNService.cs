using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface ITFNService
    {
        bool ValidateTFN(string tfnNumber, List<KeyValuePair<int, int>> weightingFactors);
    }
}