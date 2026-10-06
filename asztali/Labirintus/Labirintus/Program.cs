using Labirintus_lib;

Console.WriteLine("5. feladat");
LabSim lab = new LabSim("Lab1.txt");
Console.WriteLine("Labirintus betöltve.\n");

Console.WriteLine("6. feladat - Labirintus megjelenítése:");
lab.KiirLab();

Console.WriteLine("\n8. feladat - Útkeresés szimuláció:");
lab.Utkereses(szimulacio: true);

Console.WriteLine("\nÚtkeresés végeredménye:");
lab.KiirLab();

Console.WriteLine("\nProgram vége.");