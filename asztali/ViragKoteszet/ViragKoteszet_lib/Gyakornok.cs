using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViragKoteszet_lib
{
    public sealed class Gyakornok : Dolgozo
    {
        Random r = new Random();
        public List<int> ElvegezhetoTermekekAzonositoi {  get; init; }
        public Gyakornok(int id, string nev, IEnumerable<int> azonositok) : base(id, nev)
        {
            ElvegezhetoTermekekAzonositoi = azonositok.ToList();
        }
        public override int Gyakorlottsag
        {
            get
            {
                switch (r.Next(1, 4))
                {
                    case 1: return 70;
                    case 2: return 80;
                    case 3: return 90;
                    default: throw new Exception();
                }
            }
        }
        public override int MunkaraForditottIdo
        {
            get
            {
                return feladatok.FeladatokElkeszetesiIdeje * (200 - Gyakorlottsag);
            }
        }
        public override void UjFeladatHozzaadasa(Termek termek)
        {
            if (ElvegezhetoTermekekAzonositoi.Contains(termek.Id))
            {
                base.UjFeladatHozzaadasa(termek);
            }
            else
            {
                throw new HibasFeladatException();
            }
        }
        public override string ToString()
        {
            return $"{Nev}(Gyakornok); {MunkaraForditottIdo}";
        }
    }
}
