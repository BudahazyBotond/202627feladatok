using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoAlany_lib
{
    public class Szemely
    {
        public string Name { get; init; }
        private DateOnly birthDate;

        public Szemely(string name, DateOnly date)
        {
            Name = name;
            birthDate = date;
            if (Age < 14)
            {
                throw new HibasEletkorException();
            }
        }

        public int Age => DateTime.Now.Year - birthDate.Year;
        public override string ToString()
        {
            return $"{Name} ({Age})";
        }
    }
}
