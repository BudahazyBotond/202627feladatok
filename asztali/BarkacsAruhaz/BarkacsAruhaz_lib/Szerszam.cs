using System.Globalization;

namespace BarkacsAruhaz_lib
{
    public class Szerszam
    {
        public string Azonosito { get; init; }
        public string Megnevezes { get; init; }
        public string KeziSzerszamKategoria { get; init; }
        public int Ar { get; init; }
        public Szerszam(string azonosito, string megnevezes, string kategoria, int ar)
        {
            Azonosito = azonosito;
            Megnevezes = megnevezes;
            KeziSzerszamKategoria = kategoria;
            Ar = ar;
        }
        public bool KeziSzerszam => KeziSzerszamKategoria == "kéziszerszám";
        public override string ToString()
        {
            return $"{Megnevezes} - {Ar:C0}";
        }
    }
}
