using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoAlany_lib
{
    public sealed class Diak : Szemely, IVizsgalat
    {
        public int NumberOfCheaters { get; init; }

        public Diak(string name, DateOnly date, int cheats) : base(name, date)
        {
            NumberOfCheaters = cheats;
        }
        public bool IsGoodSubject() => NumberOfCheaters == 0 ?
            true : false;
        public override string ToString()
        {
            return $"{base.ToString()} " +
                $"{(IsGoodSubject() ? "Jó" : "Rossz")} Diák";
        }
    }
}
