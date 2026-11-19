namespace Lovaglas_lib
{
    public class Kepzes
    {
        public int KepzesId { get; init; }
        public string KepzesTipus { get; init; }
        public int AjanlottSzint { get; init; }
        public Kepzes(int kepzesId, string kepzesTipus, int ajanlottSzint)
        {
            KepzesId = kepzesId;
            KepzesTipus = kepzesTipus;
            AjanlottSzint = ajanlottSzint;
        }
        public override string ToString()
        {
            return KepzesTipus;
        }
    }
}
