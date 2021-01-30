using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;

namespace Infrastructure.Services
{
    public class AttemptsService : IAttemptsService
    {
        public async Task<List<string>> GetAttempts(string file, int seconds)
        {
            if (!File.Exists(file))
            {
                return null;
            }

            var attemptsData = await File.ReadAllLinesAsync(file);
            var time = DateTime.Now;
            var beforeTime = time.AddSeconds(-seconds);

            var attempts = new List<Attempt>();
            foreach (var attempt in attemptsData)
            {
                var data = attempt.Split("|");
                attempts.Add(new Attempt
                {
                    AttemptDateTime = DateTime.Parse(data[0]),
                    tfnNumber = data[1]
                });
            }

            var attemptsWithinTime = attempts.Where(a => a.AttemptDateTime > beforeTime).Select(a => a.tfnNumber).ToList();
            return attemptsWithinTime;
        }

        public bool CheckIfLinking(string tfnNumber, List<string> previousAttempts)
        {
            var firstValue = tfnNumber;
            string nextValue;
            var isLinking = new List<bool>();

            // Iterate backwards
            for (int attempt = previousAttempts.Count -1; attempt >= 0; attempt--)
            {
                nextValue = previousAttempts[attempt];
                var linked = false;

                for (int i = 0; i < (firstValue.Length - 4); i++)
                {
                    var subString = firstValue.Substring(i, 4);
                    if (nextValue.Contains(subString))
                    {
                        linked = true;
                    }
                }

                isLinking.Add(linked);
                firstValue = nextValue;
            }

            return isLinking.Any() && isLinking.All(l => l == true);
        }

        public void AddAttempt(string file, string tfnNumber)
        {
            if (File.Exists(file))
            {
                File.AppendAllText(file,
                   DateTime.Now.ToString() + "|" + tfnNumber + Environment.NewLine);
            }
        }
    }
}