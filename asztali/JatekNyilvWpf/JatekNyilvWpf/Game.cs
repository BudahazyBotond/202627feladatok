using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JatekNyilvWpf
{
    internal class Game
    {
        public string Title { get; set; }
        public string Genre { get; set; }

        public Game(string title, string genre)
        {
            Title = title;
            Genre = genre;
        }

        public string DisplayText => $"{Title} - {Genre}";
    }
}
