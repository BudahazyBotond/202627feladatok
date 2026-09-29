namespace TreasureChest
{
    public class Treasure
    {
        private int _volume;
        public string Name { get; init; }
        public int Volume
        {
            get => _volume;
            init
            {
                _volume = value;
                if(_volume <= 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }
        public Treasure(string name, int volume)
        {
            Volume = volume;
            Name = name;
        }
    }
}
