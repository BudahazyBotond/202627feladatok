using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeremFoglalas_lib
{
    public class TeremNyilvantartas
    {
        private readonly List<Terem> termekLista;
        public TeremNyilvantartas(IEnumerable<Terem> termek)
        {
            termekLista = termek.ToList();
        }

        public IEnumerable<string> TeremAzonositok =>
            termekLista.Select(x => x.TeremAzonosito).ToList();
        public Terem? this[string teremAzonosito] =>
            termekLista.Find(x => x.TeremAzonosito == teremAzonosito);
        public List<Terem> Termek =>
            termekLista;
        public void TeremFoglalasok(IEnumerable<Foglalas> foglalasok)
        {
            foreach (Foglalas foglalas in foglalasok)
            {
                try
                {
                    termekLista.Find(x => x.TeremAzonosito == foglalas.TeremAzonosito).IdopontFoglalas(foglalas);
                }
                catch (FoglalasException ex)
                {
                    File.AppendAllText("hibalista.txt",
                        $"{foglalas} - {ex.Message}\n"
                        );
                }
            }
        }
        public Dictionary<string, List<Foglalas>> FoglalasokTanarAzonositoAlapjan(string megadottAzonosito) =>
            Termek
            .Where(terem => terem.TeremOrarend.Foglalasok
                .Any(foglalas => foglalas.TanarAzonosito == megadottAzonosito))
            .GroupBy(terem => terem.TeremAzonosito)
            .ToDictionary(
                g => g.Key,
                g => g
                    .SelectMany(terem => terem.TeremOrarend.Foglalasok
                        .Where(f => f.TanarAzonosito == megadottAzonosito))
                    .ToList()
        );

    }
}
