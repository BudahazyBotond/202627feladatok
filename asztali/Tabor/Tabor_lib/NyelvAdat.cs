namespace Tabor_lib
{
    public class NyelvAdat
    {
        public string Szint { get; init; }
        public string Nyelv { get; init; }
        public NyelvAdat(string szint, string nyelv)
        {
            Szint = szint;
            Nyelv = nyelv;
        }
    }
}
