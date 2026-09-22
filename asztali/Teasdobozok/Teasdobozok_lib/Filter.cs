namespace Teasdobozok_lib
{
    public class Filter
    {
        //ID; Tipus; Ar
        internal string Azonosito { get; init; }
        internal string Tipus { get; init; }
        internal int Ar { get; init; }
        public Filter(string azonosito, string tipus, int ar)
        {
            Azonosito = azonosito;
            Tipus = tipus;
            Ar = ar;
        }

        internal bool Gyogytea => Azonosito.StartsWith("z");

        public override string ToString()
        {
            return $"{Tipus} tea ({Ar} Ft)";
        }
    }
}
