using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoAlany_lib
{
    public class Tanar : Szemely, IVizsgalat
    {
        double avgGrades;

        public Tanar(string name, DateOnly date, double avgGrades) : base(name, date)
        {
            this.avgGrades = avgGrades;
        }
        public bool IsGoodSubject() =>
            avgGrades >= 3.5 && Age < 30 ?
            true : false;
        public override string ToString()
        {
            return $"{base.ToString()} " +
                $"{(IsGoodSubject() ? "Jó" : "Rossz")} Tanár";
        }
    }
}
