using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lift_lib
{
    public class Lift : IMozog
    {
        public int MaxFloor { get; init; }
        public int CurrentFloor;
        Random r = new Random();
        public Lift(int maxFloor)
        {
            MaxFloor = maxFloor;
            CurrentFloor = r.Next(1, maxFloor);
        }
        public void Felfele()
        {
            if (r.Next(1, 100) == 1)
            {
                throw new Exception("A lift elromlott.");
            }
            if (CurrentFloor == MaxFloor)
            {
                throw new HibasIranyException();
            }
            CurrentFloor++;
        }
        public void Lefele()
        {
            if (r.Next(1, 100) == 1)
            {
                throw new Exception("A lift elromlott.");
            }
            if (CurrentFloor == 1)
            {
                throw new HibasIranyException();
            }
            CurrentFloor--;
        }
        public override string ToString()
        {
            return $"Legalsó szint: 1, Legfelső szint: {MaxFloor}" +
                $", jelenlegi szint: {CurrentFloor}";
        }
    }
}
