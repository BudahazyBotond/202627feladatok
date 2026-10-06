using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Halmazok_lib
{
    public class RendezettHalmaz<T> : Halmaz<T> where T : IComparable<T>
    {
        public RendezettHalmaz() : base() {
        }
        public RendezettHalmaz(IEnumerable<T> elemek) : base(elemek.OrderBy(x=>x).Distinct()){
        }
        public IEnumerable<T> RendezettElemek() => Elemei.OrderBy(x => x);
        public new void Hozzaad(T elem){
            if(!Elemei.Contains(elem)){
                Elemei.Add(elem);
            }
        }
        public bool RendezettTartalmaz(T elem) => Elemei.Contains(elem);
        public override string ToString() => string.Join(", ", RendezettElemek());
    }
}
