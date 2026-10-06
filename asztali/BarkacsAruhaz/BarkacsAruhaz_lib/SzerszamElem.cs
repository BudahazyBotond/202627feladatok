using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace BarkacsAruhaz_lib
{
    public class SzerszamElem : ISzerszam
    {
        public virtual string Nev => throw new NotImplementedException();

        public virtual int Ar => throw new NotImplementedException();
        public override string ToString()
        {
            return $"{Nev} - {Ar:C0}";
        }
    }
}
