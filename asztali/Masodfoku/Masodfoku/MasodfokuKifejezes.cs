using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Masodfoku
{
    public class MasodfokuKifejezes
    {
        public double A { get; init; }
        public double B { get; init; }
        public double C { get; init; }

        public MasodfokuKifejezes(double a, double b, double c)
        {
            A = a;
            B = b;
            C = c;
        }

        public double Diszkriminans
        {
            get
            {
                return B * B - 4 * A * C;
            }
        }

        public override string ToString()
        {
            if(B < 0)
                if(C < 0)
                    return $"{A}x^2{B}x{C}";
                else
                    return $"{A}x^2+{B}x+{C}";
            else
                if(C < 0)
                    return $"{A}x^2+{B}x{C}";
                else
                    return $"{A}x^2+{B}x+{C}";
        }

        public static MasodfokuKifejezes operator +(MasodfokuKifejezes k1, MasodfokuKifejezes k2)
        {
            return new MasodfokuKifejezes(
                k1.A + k2.A,
                k1.B + k2.B,
                k1.C + k2.C
            );
        }

        public static MasodfokuKifejezes operator -(MasodfokuKifejezes k1, MasodfokuKifejezes k2)
        {
            return new MasodfokuKifejezes(
                k1.A - k2.A,
                k1.B - k2.B,
                k1.C - k2.C
            );
        }

        public static bool operator ==(MasodfokuKifejezes k1, MasodfokuKifejezes k2)
        {
            double aranyA = k1.A / k2.A;
            double aranyB = k1.B / k2.B;
            double aranyC = k1.C / k2.C;

            if (aranyA == aranyB && aranyA == aranyC)
                return true;
            else
                return false;
        }

        public static bool operator !=(MasodfokuKifejezes k1, MasodfokuKifejezes k2)
        {
            return !(k1 == k2);
        }
    }
}
