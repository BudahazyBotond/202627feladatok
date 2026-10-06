
namespace Erettsegi_lib
{
    public class Tanar : ISzemely
    {
        //"id"	"nev"
        public string Id { get; init; }
        public string Nev { get; init; }
        public Tanar(string id, string nev)
        {
            Id = id;
            Nev = nev;
        }
    }

}
