using System;

namespace MesterEmberLib
{
    public class TulSokFoglaltsagException : Exception
    {
        public TulSokFoglaltsagException() : base("A mester túl sok munkát vállalt!")
        {
        }
    }
}
