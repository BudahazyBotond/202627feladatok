using System.Runtime.InteropServices;

namespace Generic_lib
{
    public class SajatLista<ElemekTipusa>
    {

        public readonly ElemekTipusa[] elemek;
        public int ElemekSzama { get; private set; }
        public SajatLista(int kapacitas = 20)
        {
            elemek = new ElemekTipusa[kapacitas];
            ElemekSzama = 0;
        }
        public bool TeleVan => elemek.Length == ElemekSzama;
        public void Hozzaad(ElemekTipusa elem)
        {
            if (TeleVan)
            {
                throw new InvalidOperationException("A lista megtelt.");
            }
            elemek[ElemekSzama] = elem;
            ElemekSzama++;
        }
        public ElemekTipusa this[int index]
        {
            get
            {
                if (index < 0 || index >= ElemekSzama)
                {
                    throw new ArgumentOutOfRangeException(nameof(index), "Érvénytelen index.");
                }
                return elemek[index];
            }
            set
            {
                if (index < 0 || index >= ElemekSzama)
                {
                    throw new ArgumentOutOfRangeException(nameof(index), "Érvénytelen index.");
                }
                elemek[index] = value;
            }
        }
    }
    public class  RendezhetoLista<ElemekTipusa> : SajatLista<ElemekTipusa> where ElemekTipusa : IComparable<ElemekTipusa>
    {
        public void Rendez()
        {
            for (int i = 0; ElemekSzama > i; ++i)
            {
                for (int j = 0; ElemekSzama > j; j++)
                {
                    if (i == j) continue;
                    if ((i < j && this[i].CompareTo(this[j]) > 0) 
                        || (i > j && this[j].CompareTo(this[j]) < 0))
                    {
                        (this[i], this[j] ) = (this[j], this[i]);
                    }
                }
            }
        }
    }
}
