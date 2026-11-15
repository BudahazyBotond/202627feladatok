using System;
using System.Collections.Generic;
using System.Text;

namespace XmasFair_lib
{
    public class Good
    {
        public string Name { get; init; }
        public string Type { get; init; }
        public int Value { get; init; }
        public Good(string name, string type, int value)
        {
            if (value < 0) value = 0;
            if(name == string.Empty || name == null || type == string.Empty || type == null)
            {
                throw new ArgumentException();
            }
            Name = name;
            Type = type;
            Value = value;
        }
    }
}
