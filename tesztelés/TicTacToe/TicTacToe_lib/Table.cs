namespace TicTacToe_lib
{
    public class Table
    {
        private List<char> table { get; set; }
        public Table()
        {
            table = new List<char>();
            for (int i = 0; i < 9; i++)
            {
                table.Add('_');
            }
        }

        public string PrintTable()
        {
            return $"[{table[0]}][{table[1]}][{table[2]}]\n" +
                $"[{table[3]}][{table[4]}][{table[5]}]\n" +
                $"[{table[6]}][{table[7]}][{table[8]}]";
        }

        public bool PutTable(int index, char value)
        {
            if(index < 0 || index > 8)
            {
                return false;
                throw new ArgumentOutOfRangeException("Index must be between 0 and 8.");
            }
            if (table[index] != '_')
            {
                return false;
                throw new InvalidOperationException("Position is already occupied.");
            }
            table[index] = value;
            return true;
        }

        public char this[int index]
        {
            get { return table[index]; }
        }
        public bool IsFull()
        {
            return !table.Contains('_');
        }
    }
}
