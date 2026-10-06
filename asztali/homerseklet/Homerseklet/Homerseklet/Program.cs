StreamReader myFile = new StreamReader("homerseklet.txt");
string[] firstLine = myFile.ReadLine()!.Split(" ");
int row = int.Parse(firstLine[0]);
int column = int.Parse(firstLine[1]);
int[,] temperatures = new int[row, column];
double sum = 0;
Console.Write($"1. feladat: \n"+"".PadLeft(15));
for (int i = 0; i < column; i++)
{
    Console.Write($"{i+1}. mérés".PadRight(15));
}
Console.WriteLine();
for (int i = 0; i < row; i++)
{
    Console.Write($"{i+1}. nap:".PadRight(15));
    string[] line = myFile.ReadLine()!.Split(" ");
    
    for (int j = 0; j < column; j++)
    {
        temperatures[i, j] = int.Parse(line[j]);
        sum += int.Parse(line[j]);
        Console.Write(line[j].PadRight(15));
    }
    Console.WriteLine();
}
myFile.Close();
Console.WriteLine($"\n2. feladat: Az átlaghőmérséklet: {Math.Round(sum/(row*column),2)} fok");
Console.WriteLine("\n3. feladat: Az átlaghőmérséklet naponként:");
int belowTen = 0;
for (int i = 0; i < row; i++)
{
    double lineSum = 0;
    for (int j = 0; j < column; j++)
    {
        lineSum += temperatures[i,j];
        if(temperatures[i,j] < 10)
        {
            belowTen++;
        }
    }
    Console.WriteLine($"\t{i+1}. nap: {Math.Round(lineSum/column, 2).ToString("0.00")} fok");
}
Console.WriteLine($"\n4. feladat: {belowTen} alkalommal volt 10 fok alatt a hőmérséklet");
int dailyBelowTen = 0;
for (int i = 0; i < row; i++)
{
    for (int j = 0; j < column; j++)
    {
        if (temperatures[i, j] < 10)
        {
            dailyBelowTen++;
            break;
        }
    }
}
Console.WriteLine($"\n5. feladat: {dailyBelowTen} nap volt 10 fok alatt a hőmérséklet");
int maxTemp = temperatures[0,0];
int maxDay = 0;
int maxMeasurement = 0;
for (int i = 0; i < row; i++)
{
    for (int j = 0; j < column; j++)
    {
        if (temperatures[i, j] > maxTemp)
        {
            maxTemp = temperatures[i, j];
            maxDay = i + 1;
            maxMeasurement = j + 1;
        }
    }
}
Console.WriteLine($"\n6. feladat: {maxDay}. nap {maxMeasurement}. mérésekor volt a legmagasabb a hőmérséklet: {maxTemp}");
Console.Write("\n7. feladat: Keresett hőmérséklet érték: ");
int tempSearch = int.Parse(Console.ReadLine()!);
bool isFound = false;
for (int i = 0; i < row; i++)
{
    if(isFound) break;
    for (int j = 0; j < column; j++)
    {
        if (temperatures[i, j] == tempSearch)
        {
            Console.WriteLine($"\tVolt ilyen mérés: {i+1}. nap {j+1}. mérése");
            isFound = true; break;
        }
    }
}
if(!isFound)
{
    Console.WriteLine("\tNem volt ilyen mérés.");
}