using System.Collections.Generic;
using Core.Interfaces;

namespace Infrastructure.Services
{
    public class TFNService : ITFNService
    {
        const int DIVISION = 11;

        public bool ValidateTFN(string tfnNumber, List<KeyValuePair<int, int>> weightingFactors)
        {
            var sum = 0;
            var numberArray = tfnNumber.ToCharArray();

            // sum the resulting products
            for (int i = 0; i < tfnNumber.Length; i++)
            {
                var number = int.Parse(numberArray[i].ToString());
                sum += number * weightingFactors[i].Value;
            }

            // Get remainder of sum of values
            var remainder = sum % DIVISION;

            if (remainder == 0)
            {
                return true;
            }

            return false;
        }
    }
}