namespace XmasFair_lib
{
    public class Fair
    {
        //new Fair("Mikulás napi vásár", 20, 20000, "2025.12.05", "2025.12.07").Name
        public string Name { get; init; }
        public int StandPlaces { get; init; }
        public int StandCount { get; set; }
        public int StandPrice { get; init; }
        public List<Stand> Stands { get; init; }
        public DateOnly FairStart { get; init; }
        public DateOnly FairEnd { get; init; }
        public Fair(string name, int standPlaces, int standPrice, string fairStart, string fairEnd)
        {
            Name = name;
            StandPlaces = standPlaces;
            StandPrice = standPrice;
            StandCount = 0;
            Stands = new();
            FairStart = DateOnly.Parse(fairStart);
            FairEnd = DateOnly.Parse(fairEnd);
            if(name == null ||  name.Length == 0 || standPlaces < 0 || standPrice < 0 || FairStart > FairEnd)
            {
                throw new ArgumentException();
            }
        }
        public int FreePlace => StandPlaces - StandCount;
        public bool AddStand(Stand stand)
        {
            if (FreePlace == 0) return false;
            if(Stands.Select(x=>x.Name).Contains(stand.Name)) return false;
            Stands.Add(stand);
            StandCount++;
            return true;
        }
        public bool RemoveStand(string name)
        {
            if (StandCount == 0) return false;
            if (!Stands.Select(x => x.Name).Contains(name)) return false;
            Stands.Remove(Stands.Find(x => x.Name == name)!);
            StandCount--;
            return true;
        }
        public int Income => StandPrice * StandCount;
    }
}
