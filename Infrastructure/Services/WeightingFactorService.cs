using System.Collections.Generic;
using System.IO;
using System.Net;
using Core.Errors;
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
                throw new RestException(HttpStatusCode.InternalServerError, new { Error = "Internal Server Error: Please try again after a while" });
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