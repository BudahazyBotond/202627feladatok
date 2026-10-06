using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csokigyar_lib
{
    internal class Csoki : IEtel
    {
        public Csoki(string csokifajta, IEnumerable<string> alapanyagok, int kakaoTartalom)
        {
            Csokifajta = csokifajta;
            Alapanyagok = alapanyagok.ToArray();
            KakaoTartalom = kakaoTartalom;
        }

        public virtual bool MegfeleloMinoseg => KakaoTartalom switch
        {
            > 50 => true,
            >= 0 => false,
            _ => throw new SilanyMinosegException()
        };

        public IEnumerable<string> MibolKeszul()
        {
            return Alapanyagok;
        }

        public override string ToString()
        {
            return $"{Csokifajta} kakaótartalom: {KakaoTartalom}% " +
                   $"alapanyagai: {String.Join(", ", Alapanyagok)}";
        }

        private string Csokifajta { get; init; }
        private string[] Alapanyagok { get; init; }
        protected int KakaoTartalom { get; init; }
    }
}
