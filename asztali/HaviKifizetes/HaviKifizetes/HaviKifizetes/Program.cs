using Fizetesek_lib;
string bemenetiFajl = "lista.csv";
string kimenetiFajl = "listaki.csv";
Kifizetes kifizetProgram = new Kifizetes(bemenetiFajl);
Console.WriteLine($"3. feladat:\n\t{string.Join("\n\t",kifizetProgram.HarmadikFeladat())}");
Console.WriteLine($"5. feladat:\nA dolgozók kifizetéséhez a következő címletekre van szükség:\n\t{string.Join("\n\t", kifizetProgram.OtodikFeladat())}");
kifizetProgram.HatodikFeladat(kimenetiFajl);