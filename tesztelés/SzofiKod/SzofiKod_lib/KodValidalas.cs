using System.Reflection.Metadata.Ecma335;
using System.Text.RegularExpressions;

namespace SzofiKod_lib
{
    public class KodValidalas
    {
        bool faslity = false;
        bool verity = true;
        public string Kod { get; init; }
        public KodValidalas(string kod)
        {
            Kod = kod;
        }
        public bool Validate()
        {
            if(!Empty()) return faslity;
            if(!Format()) return faslity;
            if (!Letters()) return faslity;
            if (!EnglishLetters()) return faslity;

            return verity;
        }
        public bool Empty()
        {
            if(!(Kod == null || Kod == "")) return verity; 
            Console.WriteLine("Empty falsity");
            return faslity;
        }
        public bool Format()
        {
            if((Kod.ToLower().Count(x=>x == '-')==2 && Kod[4] == '-' && Kod[9] == '-' && Kod.Count() == 14) || (Kod.Count(x => x == '-') == 0 && Kod.Count() == 12)) return verity; 
            Console.WriteLine("Format falsity");
            return faslity;
        }
        public bool Letters()
        {
            if (Kod.ToLower().Count(x => x == 'j') == 1 && Kod.ToLower().Count(x => x == 'g') >= 1 && Kod.ToLower().Count(x => x == 'c') >= 1 && Kod.Count(x => Char.IsDigit(x)) >= 1) return verity; 
            Console.WriteLine("Letters falsity");
            return faslity;
        }
        public bool EnglishLetters()
        {
            if (Regex.IsMatch(Kod, @"^[A-Za-z0-9-]+$")) return verity;
            Console.WriteLine("English letters falsity");
            return faslity;
        }
    }
}
