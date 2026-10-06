namespace Iskolak
{
    public class Iskola
    {
        private List<Diak> diakok = new List<Diak>();
        private List<Tantargy> tantargyak = new List<Tantargy>();

        public void DiakHozzaad(Diak diak)
        {
            diakok.Add(diak);
        }

        public void TantargyHozzaad(Tantargy tantargy)
        {
            tantargyak.Add(tantargy);
        }

        public Diak this[int azonosito]
        {
            get
            {
                Diak? diak = diakok.FirstOrDefault(d => d.Azonosito == azonosito);
                if (diak == null)
                {
                    throw new KeyNotFoundException($"Nincs ilyen azonosítójú diák: {azonosito}");
                }
                return diak;
            }
        }

        public Tantargy this[string nev]
        {
            get
            {
                Tantargy? tantargy = tantargyak.FirstOrDefault(t => t.Nev == nev);
                if (tantargy == null)
                {
                    throw new KeyNotFoundException($"Nincs ilyen nevű tantárgy: {nev}");
                }
                return tantargy;
            }
        }
    }
}
