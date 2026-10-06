using Lift_lib;

List<Lift> elevators = new List<Lift>();
string[] datas = File.ReadAllLines("input.txt");
int elevatorNumber = int.Parse(datas[0]);
for (int i = 1; i < elevatorNumber + 1; i++)
{
    int maxFloor = ParseCheck(datas[i]);
    elevators.Add(new Lift(maxFloor));
}
for (int i = elevatorNumber + 1; i < datas.Count(); i++)
{
    string[] toDoList = datas[i].Split(";");
    int elevatorIndex = int.Parse(toDoList[0]) - 1;
    if (elevatorIndex >= elevators.Count())
    {
        throw new Exception("Hibás sor!");
    }
    if (toDoList[1].ToLower() == "fel")
    {
        elevators[elevatorIndex].Felfele();
    }
    else if (toDoList[1].ToLower() == "le")
    {
        elevators[elevatorIndex].Lefele();
    }
    else
    {
        throw new Exception("Nem létező irány!");
    }
    Console.WriteLine($"{elevatorIndex + 1}. lift: {elevators[elevatorIndex].ToString()}");
}
Liftek list = new Liftek(elevators);

int ParseCheck(string number)
{
    try
    {
        int numberInted = int.Parse(number);
        if (numberInted < 2)
        {
            return 10;
        }
        return int.Parse(number);
    }
    catch
    {
        return 10;
    }
}