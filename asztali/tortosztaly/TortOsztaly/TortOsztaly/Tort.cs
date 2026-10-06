using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TortOsztaly
{
    internal class Tort
    {
        public int Szamlalo { get; init; }
        public int Nevezo { get; init; }

        public Tort()
        {
            Szamlalo = 0;
            Nevezo = 1;
        }

        public Tort(int szamlalo, int nevezo)
        {
            if (nevezo == 0)
                throw new DivideByZeroException("Nem lehet 0 a nevező!");

            if (nevezo < 0)
            {
                szamlalo *= -1;
                nevezo *= -1;
            }

            int lnko = Euklidesz(Math.Abs(szamlalo), Math.Abs(nevezo));

            Szamlalo = szamlalo / lnko;
            Nevezo = nevezo / lnko;
        }
        private int Euklidesz(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        public override string ToString()
        {
            if (Nevezo == 1) return Szamlalo.ToString();
            return $"{Szamlalo} / {Nevezo}";
        }
        public double Ertek => (double)Szamlalo / Nevezo;

        public static Tort operator +(Tort a, Tort b) => new Tort(a.Szamlalo * b.Nevezo + b.Szamlalo * a.Nevezo, a.Nevezo * b.Nevezo);
        public static Tort operator -(Tort a, Tort b) => new Tort(a.Szamlalo * b.Nevezo - b.Szamlalo * a.Nevezo, a.Nevezo * b.Nevezo);
        public static Tort operator *(Tort a, Tort b) => new Tort(a.Szamlalo * b.Szamlalo, a.Nevezo * b.Nevezo);

        public static Tort operator /(Tort a, Tort b)
        {
            if (b.Szamlalo == 0)
                throw new DivideByZeroException("0-val nem lehet osztani!");
            return new Tort(a.Szamlalo * b.Nevezo, a.Nevezo * b.Szamlalo);
        }

        public static Tort operator +(Tort a, int b) => a + new Tort(b, 1);
        public static Tort operator -(Tort a, int b) => a - new Tort(b, 1);
        public static Tort operator *(Tort a, int b) => a * new Tort(b, 1);

        public static Tort operator /(Tort a, int b)
        {
            if (b == 0)
                throw new DivideByZeroException("0-val nem lehet osztani!");
            return a / new Tort(b, 1);
        }

        public static bool operator ==(Tort a, Tort b) => a.Szamlalo == b.Szamlalo && a.Nevezo == b.Nevezo;
        public static bool operator !=(Tort a, Tort b) => !(a == b);
        public static bool operator <(Tort a, Tort b) => a.Ertek < b.Ertek;
        public static bool operator >(Tort a, Tort b) => a.Ertek > b.Ertek;
        public static bool operator <=(Tort a, Tort b) => a.Ertek <= b.Ertek;
        public static bool operator >=(Tort a, Tort b) => a.Ertek >= b.Ertek;

        public override bool Equals(object? obj)
        {
            if (obj is not Tort t) return false;
            return this == t;
        }

        public override int GetHashCode() => HashCode.Combine(Szamlalo, Nevezo);

        public static implicit operator Tort(int x) => new Tort(x, 1);

        public static implicit operator Tort(double x)
        {
            int sz = (int)(x * 1000000);
            int nz = 1000000;
            return new Tort(sz, nz);
        }

        public static implicit operator double(Tort t) => t.Ertek;
        public static explicit operator int(Tort t) => (int)Math.Round(t.Ertek);
    }
}
