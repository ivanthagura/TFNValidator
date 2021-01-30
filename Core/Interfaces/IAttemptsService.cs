using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IAttemptsService
    {
        void AddAttempt(string file, string tfnNumber);
        Task<List<string>> GetAttempts(string attemptsFile, int seconds);
        bool CheckIfLinking(string tfnNumber, List<string> previousAttempts);
    }
}