using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forma_1_Lib
{
    public class Versenyzok
    {
        List<Versenyzo> list = new List<Versenyzo>();
        public Versenyzok(string[] file)
        {
            foreach (var line in file.Skip(1))
            {
                list.Add(new Versenyzo(line.Split(';')));
            }
        }
        public IEnumerable<Versenyzo> Hills()=> list.Where(x => x.Name.Contains(" Hill")).DistinctBy(x=>x.Name).OrderBy(x=>x.BirthDate);
        public IEnumerable<Versenyzo> Winners()=> list.Where(x => x.Place == "1").DistinctBy(x => x.Name).OrderBy(x=>x.Name);
        public Versenyzo? FirstRace(string name)=> list.Where(x=>x.Name==name).OrderBy(x => x.Date).First();
        public Dictionary<string,int> Top3MistakesOfFerrari()=> list.Where(x => x.Type == "Ferrari" && x.Mistake != null).GroupBy(x => x.Mistake).OrderByDescending(x=>x.Count()).Take(3).ToDictionary(x=>x.Key, x=>x.Count());
        public int NoTeam() => list.Where(x=>x.Team == null).DistinctBy(x=>x.Name).Count();
        public string[] CountryAfterHungary(string country) => list.OrderBy(x=>x.Date).DistinctBy(x=>x.Location).Where(x => x.Location != country).Where(x=>x.Date>list.OrderBy(x => x.Date).DistinctBy(x => x.Location).Where(x => x.Location == country).First().Date).Select(x => x.Location).OrderBy(x => x).ToArray();
        public void WriteFile(string fileName, string country)
        {
            StreamWriter file = new StreamWriter(fileName);
            foreach (var item in list.Where(x => x.Location == country&&x.Place!=null).OrderBy(x=>x.Date).ThenBy(x=>x.Place).GroupBy(x=>x.Date).Take(6))
            {
                file.WriteLine($"{item.Key.Year}");
                foreach (var item2 in item)
                {
                    file.WriteLine($"\t{item2.Place}. {item2.Name} ({item2.Team} {item2.Type})");
                }
            }
            file.Close();
        }
    }
}
