using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViragKoteszet_lib
{
    public class Dolgozo
    {
        public Dolgozo(int id, string nev)
        {
            Id = id;
            Nev = nev;
        }
        public int Id { get; init; }
        public string Nev { get; init; }
        public FeladatLista feladatok = new FeladatLista();

        public virtual int Gyakorlottsag { get; }
        public virtual int MunkaraForditottIdo { get; }
        public virtual void UjFeladatHozzaadasa(Termek termek)
        {
            feladatok += termek;
        }
        public override string ToString()
        {
            return $"{Nev}; {MunkaraForditottIdo}";
        }
    }
}
