using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erettsegi_lib
{
    public class Vizsga
    {
        //"id"	"bizottsag"	"vizsgatargy"	"vizsgazoid"	"tanarid"
        public string Id { get; init; }
        public string Bizottsag { get; init; }
        public string Vizsgatargy { get; init; }
        public string VizsgazoId { get; init; }
        public string TanarId { get; init; }
        public Vizsga(string id, string bizottsag, string vizsgatargy, string vizsgazoId, string tanarId)
        {
            Id = id;
            Bizottsag = bizottsag;
            Vizsgatargy = vizsgatargy;
            VizsgazoId = vizsgazoId;
            TanarId = tanarId;
        }
        public string Azonosito => $"Vizsga_{Id}_{Vizsgatargy}";
    }
}
