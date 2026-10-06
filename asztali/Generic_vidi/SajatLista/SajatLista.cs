using System.Runtime.InteropServices;

namespace SajatLista
{
    internal class SajatLista<ElemekTipusa>
    {
       
        readonly ElemekTipusa[] elemek;
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
        public ElemekTipusa this[int index]{
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
}
