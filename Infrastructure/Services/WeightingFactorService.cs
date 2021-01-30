using System.Collections.Generic;
using System.IO;
using Core.Interfaces;

namespace Infrastructure.Services
{
    public class WeightingFactorService : IWeightingFactorService
    {
        public List<KeyValuePair<int, int>> GetWeightingFactors(string file)
        {
            int counter = 0;
            var weightFactors = new List<KeyValuePair<int, int>>();
            if (!File.Exists(file))
            {
                return null;
            }

            var lines = File.ReadLines(file);
            foreach (var weight in lines)
            {
                var weightFactor = new KeyValuePair<int, int>(counter, int.Parse(weight));
                weightFactors.Add(weightFactor);
                counter++;
            }

            return weightFactors;
        }
    }
}