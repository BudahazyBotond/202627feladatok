using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeremFoglalas_lib
{
   public sealed class AltalanosTerem : Terem
    {
        public AltalanosTerem(string teremAzonosito, int helyekSzama)
            : base(teremAzonosito, helyekSzama)
        {
        }

        public override void IdopontFoglalas(Foglalas foglalas)
            => TeremOrarend += foglalas;
        public override string ToString()
        {
            return $"{TeremAzonosito}\n" +
                $"{TeremOrarend.ToString()}";
        }
    }
}
