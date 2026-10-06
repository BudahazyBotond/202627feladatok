using Generic_lib;
using System.Collections;

SajatLista<int> szamLista = new SajatLista<int>();
szamLista.Hozzaad(42);
SajatLista <string> szovegLista = new SajatLista<string>();
szovegLista.Hozzaad("tigrincs");
ArrayList vegyesLista = new ArrayList();
vegyesLista.Add(123);
vegyesLista.Add("valami szöveg");
SajatLista<object> objektumLista = new SajatLista<object>();
objektumLista.Hozzaad(456);
objektumLista.Hozzaad("tigró");

RendezhetoLista<int> rendezhetoSzamLista = new RendezhetoLista<int>();
rendezhetoSzamLista.Hozzaad(42);
rendezhetoSzamLista.Hozzaad(21);
rendezhetoSzamLista.Hozzaad(84);
rendezhetoSzamLista.Hozzaad(7);
rendezhetoSzamLista.Rendez();
Console.WriteLine(string.Join(", ", rendezhetoSzamLista.elemek));