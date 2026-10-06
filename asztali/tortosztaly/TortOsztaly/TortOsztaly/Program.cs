using TortOsztaly;

Console.WriteLine("Tört osztály tesztelése\n");

Console.WriteLine("1. Alap konstruktorok:");
Tort t1 = new Tort();
Tort t2 = new Tort(3, 4);
Tort t3 = new Tort(6, 8);
Tort t4 = new Tort(2, -3);

Console.WriteLine($"t1 (alap): {t1}");
Console.WriteLine($"t2 (3/4): {t2}");
Console.WriteLine($"t3 (6/8): {t3} (egyszerűsítve: 3/4)");
Console.WriteLine($"t4 (2/-3): {t4} (negatív nevező kezelése: -2/3)");

Console.WriteLine("\n2. Műveletek:");
Tort osszeg = t2 + t3;
Tort kulonbseg = t2 - t3;
Tort szorzat = t2 * t3;
Tort hanyados = t2 / t3;

Console.WriteLine($"{t2} + {t3} = {osszeg}");
Console.WriteLine($"{t2} - {t3} = {kulonbseg}");
Console.WriteLine($"{t2} * {t3} = {szorzat}");
Console.WriteLine($"{t2} / {t3} = {hanyados}");

Console.WriteLine("\n3. Egész számmal való műveletek:");
Tort tortPlusEgesz = t2 + 2;
Tort tortMinusEgesz = t2 - 1;
Tort tortSzorozEgesz = t2 * 3;
Tort tortOsztEgesz = new Tort(8, 4) / 2;

Console.WriteLine($"{t2} + 2 = {tortPlusEgesz}");
Console.WriteLine($"{t2} - 1 = {tortMinusEgesz}");
Console.WriteLine($"{t2} * 3 = {tortSzorozEgesz}");
Console.WriteLine($"8/4 / 2 = {tortOsztEgesz}");

Console.WriteLine("\n4. Összehasonlítások:");
Console.WriteLine($"{t2} == {t3}: {t2 == t3}");
Console.WriteLine($"{t2} != {t4}: {t2 != t4}");
Console.WriteLine($"{t2} < {new Tort(4, 5)}: {t2 < new Tort(4, 5)}");
Console.WriteLine($"{t2} > {new Tort(1, 2)}: {t2 > new Tort(1, 2)}");

Console.WriteLine("\n5. Konverziók:");

Tort t5 = 5;
Console.WriteLine($"int -> Tort: 5 = {t5}");

Tort t6 = 0.75;
Console.WriteLine($"double -> Tort: 0.75 ≈ {t6}");

double ertek = t2;
Console.WriteLine($"Tort -> double: {t2} = {ertek}");

int egesz = (int)new Tort(7, 2);
Console.WriteLine($"Tort -> int (explicit): 7/2 ≈ {egesz}");

Console.WriteLine("\n6. Érték tulajdonság:");
Console.WriteLine($"{t2}.Ertek = {t2.Ertek}");
Console.WriteLine($"{t4}.Ertek = {t4.Ertek}");

Console.WriteLine("\n7. Kivételek tesztelése:");

try
{
    Tort hibas = new Tort(1, 0);
}
catch (DivideByZeroException ex)
{
    Console.WriteLine($"Új tört 0 nevezővel: {ex.Message}");
}

try
{
    Tort osztasNullaval = t2 / new Tort(0, 1);
}
catch (DivideByZeroException ex)
{
    Console.WriteLine($"Osztás 0-val: {ex.Message}");
}

Console.WriteLine("\n8. Equals és GetHashCode:");
Console.WriteLine($"t2.Equals(t3): {t2.Equals(t3)}");
Console.WriteLine($"t2.GetHashCode() == t3.GetHashCode(): {t2.GetHashCode() == t3.GetHashCode()}");

Console.WriteLine("\nTesztelés befejezve!");