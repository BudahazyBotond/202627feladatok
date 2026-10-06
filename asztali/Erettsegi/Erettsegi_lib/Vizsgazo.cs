using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erettsegi_lib
{
    public class Vizsgazo : ISzemely
    {
        //"id"	"diaknev"	"evfolyam"	"osztaly"
        public string Id { get; init; }
        public string Nev { get; init; }
        public int Evfolyam { get; init; }
        public string Osztaly { get; init; }
        public Vizsgazo(string id, string nev, int evfolyam, string osztaly)
        {
            Id = id;
            Nev = nev;
            Evfolyam = evfolyam;
            Osztaly = osztaly;
        }
        public string TeljesOsztaly => $"{Evfolyam}/{Osztaly}";
        public override string ToString()
        {
            return $"{Id}: {Nev} {TeljesOsztaly}";
        }
    }
}
