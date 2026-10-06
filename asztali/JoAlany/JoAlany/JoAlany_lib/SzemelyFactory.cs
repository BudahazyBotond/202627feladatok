using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoAlany_lib
{
    internal class SzemelyFactory
    {
        public Szemely Factory(string row)
        {
            string[] datas = row.Split(';');
            switch (datas[0])
            {
                case "t":
                    return new Tanar(
                        datas[1],
                        DateOnly.Parse(datas[2]),
                        double.Parse(datas[3])
                    );
                case "d":
                    return new Diak(
                        datas[1],
                        DateOnly.Parse(datas[2]),
                        int.Parse(datas[3])
                    );
                default: throw new Exception();
            }

        }
    }
}
