using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szepseg_lib
{
    public class Kezelesek
    {
        public List<Kezeles> _list = new();
        public Kezelesek(IEnumerable<Kezeles> kezelesek)
        {
            _list = kezelesek.ToList();
        }
        public Kezeles this[int kezelesId]
        {
            get
            {
                return _list.Where(x => x.KezelesId == kezelesId).First();
            }
        }
        public List<Kezeles> AlkalmazottSzerint(int alkalmazottId)
        {
            return _list.Where(x=>x.AlkalmazottId == alkalmazottId).ToList();   
        }

        public int DelelottiKezelesek()
        {
            return _list.Count(x => x.Idopont < TimeOnly.Parse("12:00:00"));
        }
        public int Bevetel(int alkId)
        {
            int bevetel = 0;
            foreach (Kezeles kezeles in AlkalmazottSzerint(alkId))
            {
                bevetel += kezeles.Ar;
            }
            return bevetel;
        }
        public int[] Top3Id()
        {
            List<int> bevetelek = new();
            List<int> ids = new();
            foreach (int alkId in _list.DistinctBy(x=>x.AlkalmazottId).Select(x=>x.AlkalmazottId))
            {
                if(bevetelek.Count() < 3)
                {
                    bevetelek.Add(Bevetel(alkId));
                    bevetelek.OrderByDescending(x => x);
                }
                else if (bevetelek[2] < Bevetel(alkId))
                {
                    bevetelek.Remove(bevetelek[2]);
                    bevetelek.Add(Bevetel(alkId));
                    bevetelek.OrderByDescending(x => x);
                }
            }
            foreach (int alkId in _list.DistinctBy(x => x.AlkalmazottId).Select(x => x.AlkalmazottId))
            {
                foreach(int bevetel in bevetelek)
                {
                    if(bevetel == Bevetel(alkId))
                    {
                        ids.Add(alkId);
                        break;
                    }
                }
                if(ids.Count == 3)
                {
                    break;
                }
            }
            return ids.ToArray();
        }
    }
}
