namespace Urhajok_lib
{
    public class Skill
    {
        private string _name;
        private int _level;

        public string Name
        {
            get => _name;
            init
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException();
                }
                _name = value;
            }
        }

        public int Level
        {
            get => _level;
            init
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                _level = value;
            }
        }

        public Skill(string name, int level)
        {
            Name = name;
            Level = level;
        }
    }
}