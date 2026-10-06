using Eletjatek;

EletjatekSzimulator sz = new EletjatekSzimulator(10, 10);

Console.WriteLine("Életjáték szimulátor – nyomj meg egy billentyűt a következő körhöz!");

while (!Console.KeyAvailable)
{
    sz.Run();
}