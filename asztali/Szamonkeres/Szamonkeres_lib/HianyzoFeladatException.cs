using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szamonkeres_lib
{
    public class HianyzoFeladatException : Exception
    {
        public HianyzoFeladatException() : base("A feladat hiányzik.")
        {

        }
    }
}
