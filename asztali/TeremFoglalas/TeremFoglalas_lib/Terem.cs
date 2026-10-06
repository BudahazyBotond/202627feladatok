using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeremFoglalas_lib
{
    public abstract class Terem
    {
        protected Terem(string teremAzonosito, int helyekSzama)
        {
            TeremAzonosito = teremAzonosito;
            HelyekSzama = helyekSzama;
            TeremOrarend = new Orarend();
        }
        public string TeremAzonosito {  get; init; }
        public int HelyekSzama { get; init; }
        public Orarend TeremOrarend { get; protected set; }
        public abstract void IdopontFoglalas(Foglalas foglalas);
    }
}
