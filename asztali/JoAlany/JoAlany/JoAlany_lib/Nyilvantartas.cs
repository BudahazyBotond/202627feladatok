using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoAlany_lib
{
    public class Nyilvantartas
    {
        private readonly List<Szemely> persons = new List<Szemely>();
        public IEnumerable<Szemely> AllPerson => persons;
        public Nyilvantartas(IEnumerable<string> File)
        {
            foreach (var row in File)
            {
                SzemelyFactory personFactory = new SzemelyFactory();
                persons.Add(personFactory.Factory(row));
            }
        }

        public Szemely this[int i]
        {
            get => persons[i];
            set => persons[i] = value;
        }
        public IEnumerable<Diak> AllStudents => persons.OfType<Diak>();
        public int StundetsCount => AllStudents.Count();
        public IEnumerable<Tanar> AllTeachers => persons.OfType<Tanar>();
        public int TeachersCount => AllTeachers.Count();
        public double AvarageAgeOfTeachers =>
            AllTeachers.Average(x => x.Age);
        public Dictionary<int, int> StudentsAndCheatsDict =>
            AllStudents.GroupBy(x => x.NumberOfCheaters).ToDictionary(x => x.Key, x => x.Count());
    }
}
