using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace XmasFair_lib
{
    public class Stand
    {
        //new Stand("Bódog bódéja", "étel")
        public string Name { get; init; }
        public List<string> StandType { get; init; } = new();
        public List<Good> Goods { get; init; } = new();
        public int DailyIncome { get; set; } = 0;
        public Stand(string name, IEnumerable<string> standType)
        {
            if (name == null || name.Length == 0 || standType == null || standType.ToList().Find(x=> x != string.Empty) == null)
            {
                throw new ArgumentException();
            }
            Name = name;
            StandType.AddRange(standType);
        }

        public Stand(string name, string standType)
        {
            if (name == null || name.Length == 0 || standType == null || standType == string.Empty)
            {
                throw new ArgumentException();
            }
            Name = name;
            StandType.Add(standType);
        }
        public void Add(Good good)
        {
            if(!StandType.Contains(good.Type) || Goods.Select(x=>x.Name).Contains(good.Name))
            {
                throw new ArgumentException();
            }

            Goods.Add(good);
        }
        public int NumGoods => Goods.Count();
        public bool Sell(string name, int amount)
        {
            if(name == null || !Goods.Select(x=>x.Name).Contains(name))
            {
                throw new ArgumentException();
            }
            if (amount <= 0) return false;
            DailyIncome += amount * Goods.Find(x => x.Name == name)!.Value;
            return true;
        }
    }
}
