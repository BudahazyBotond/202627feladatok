using Iskolak;
var iskola = new Iskola();

var matek = new Tantargy("Matematika", "MAT101");
var tori = new Tantargy("Történelem", "TOR202");
iskola.TantargyHozzaad(matek);
iskola.TantargyHozzaad(tori);

var diak1 = new Diak("Kis Pista", 123);
var diak2 = new Diak("Nagy Éva", 456);
iskola.DiakHozzaad(diak1);
iskola.DiakHozzaad(diak2);

diak1.JegyHozzaad(matek, 5);
diak1.JegyHozzaad(tori, 4);

Diak megtalaltDiak = iskola[123];
Console.WriteLine($"Diák: {megtalaltDiak.Nev}, azonosító: {megtalaltDiak.Azonosito}");

Tantargy megtalaltTantargy = iskola["Történelem"];
Console.WriteLine($"Tantárgy: {megtalaltTantargy.Nev}, kód: {megtalaltTantargy.Kod}");
Console.WriteLine($"{megtalaltDiak.Nev} jegye {megtalaltTantargy.Nev} tárgyból: {megtalaltDiak.Jegyek[megtalaltTantargy]}");
try
{
    Diak nemLetezo = iskola[999];
}
catch (KeyNotFoundException e)
{
    Console.WriteLine($"Hiba: {e.Message}");
}

try
{
    Tantargy nemLetezo = iskola["Fizika"];
}
catch (KeyNotFoundException e)
{
    Console.WriteLine($"Hiba: {e.Message}");
}