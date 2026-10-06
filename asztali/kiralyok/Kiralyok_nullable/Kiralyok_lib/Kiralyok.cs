using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace HungarianKings_LIB
{
    public class Kiralyok
    {
        private readonly List<Kiraly> list = new List<Kiraly>();

        public Kiralyok(IEnumerable<string> lines)
        {
            foreach (var line in lines)
            {
                string[] parts = line.Split(";");
                list.Add(new Kiraly(
                        int.Parse(parts[0]),
                        parts[1],
                        EmptyToNull(parts[2]),
                        int.Parse(parts[3]),
                        int.Parse(parts[4]),
                        parts[5],
                        int.Parse(parts[6]),
                        int.Parse(parts[7]),
                        EmptyToInt(parts[8])
                    ));
            }
        }

        private string? EmptyToNull(string? text) =>
            string.IsNullOrEmpty(text) ? null : text;

        private int? EmptyToInt(string? text) =>
            string.IsNullOrEmpty(text) ? null : int.Parse(text);

        public IEnumerable<Kiraly> ByCrownYear(int min, int max) =>
            list.Where(x => x.CrownYear >= min && x.CrownYear <= max);

        public IEnumerable<Kiraly> ByBirthDesc() =>
            list.DistinctBy(x => x.Name).OrderByDescending(x => x.Born);

        public IEnumerable<Kiraly> LongestRule(int count) =>
            list.OrderByDescending(x => x.YearsRuled).Take(count);

        public IEnumerable<Kiraly> YoungerThan(int age) =>
            list.DistinctBy(x => x.Name)
                .OrderBy(x => x.AgeAtStart)
                .Where(x => x.AgeAtStart < age);

        public Dictionary<string, int> HouseCounts =>
            list.DistinctBy(x => x.Name)
                .GroupBy(x => x.House)
                .OrderByDescending(x => x.Count())
                .ToDictionary(x => x.Key, x => x.Count());

        public IEnumerable<Kiraly> RuledBeforeCrown =>
            list.Where(x => x.RuledBeforeCrown());

        public IEnumerable<Kiraly> WithNickname =>
            list.Where(x => x.Nickname != null)
                .OrderByDescending(x => x.Born);
        public void WriteToFile(string fileName, IEnumerable<Kiraly> items)
        {
            using StreamWriter sw = new StreamWriter(fileName);
            foreach (var r in items)
            {
                sw.Write($"{r.FullName()} ");
                sw.WriteLine(r.CrownYear?.ToString() ?? "-");
            }
        }
    }

}