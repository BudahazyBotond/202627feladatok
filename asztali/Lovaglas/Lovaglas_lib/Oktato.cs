using System;
using System.Collections.Generic;
using System.Text;

namespace Lovaglas_lib
{
    public class Oktato
    {
        public int OktatoId { get; init; }
        public string Nev { get; init; }
        public string Email { get; init; }
        public string Telefon { get; init; }
        public int Oradij { get; init; }
        public Oktato(int oktatoId, string nev, string email, string telefon, int oradij)
        {
            OktatoId = oktatoId;
            Nev = nev;
            Email = email;
            Telefon = telefon;
            Oradij = oradij;
        }
        public override string ToString()
        {
            return Nev;
        }
    }
}
