using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lift_lib
{
    public class Liftek
    {
        private readonly List<Lift> elevators = new List<Lift>();

        public Liftek(IEnumerable<Lift> elevatorsparam)
        {
            elevators = elevatorsparam.ToList();
        }
        public Lift this[int i]
        {
            get { return elevators[i]; }
            set
            {
                if (elevators[i] is null)
                {
                    throw new ArgumentException("Nincs ezen az indexen lift!");
                }
                elevators[i] = value;
            }
        }
        public int ElevatorNumber => elevators.Count();
    }
}
