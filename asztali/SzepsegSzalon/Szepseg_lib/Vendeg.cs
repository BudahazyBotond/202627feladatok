
namespace Szepseg_lib
{
    public class Vendeg
    {
        public int VendegId { get; init; }
        public string Nev { get; init; }
        public string Cim { get; init; }
        public string Telefon { get; init; }
        public Vendeg(int id, string nev, string cim, string tel)
        {
            VendegId = id;
            Nev = nev;
            Cim = cim;
            Telefon = tel;
        }
    }

}
