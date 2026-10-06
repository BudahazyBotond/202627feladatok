using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sikolcsonzo_lib
{
    public class Berles : IBerles
    {
        public string BerloNev {  get; init; }
        public string SporteszkozID { get; }

        public DateOnly BerlesKezdet { get; }
        public DateOnly BerlesVeg {
            get {
                //DateOnly newDate = new DateOnly(BerlesKezdet.Year, BerlesKezdet.Month, BerlesKezdet.Day);
                //int overflow = 0;
                //for (int i = 0; i < NapokSzama; i++)
                //{
                //    try
                //    {
                //        newDate = new DateOnly(BerlesKezdet.Year, BerlesKezdet.Month, BerlesKezdet.Day+NapokSzama-i);
                //    }
                //    catch (Exception e)
                //    {
                //        overflow = i+1;
                //    }
                //}
                //if (overflow != 0)
                //{
                //    if (BerlesKezdet.Month + 1 == 13)
                //    {
                //        return new DateOnly(BerlesKezdet.Year + 1, 1, overflow);
                //    }
                //    return new DateOnly(BerlesKezdet.Year, BerlesKezdet.Month + 1, overflow);
                //}
                //return new DateOnly(BerlesKezdet.Year, BerlesKezdet.Month, BerlesKezdet.Day + NapokSzama);
                return BerlesKezdet.AddDays(NapokSzama);
            }
            
        }


        public int NapokSzama { get; }

        public Berles(string sporteszkozID, DateOnly berlesKezdet, int napokSzama, string berloNev)
        {
            DateOnly idoszakKezdete = new DateOnly(2024,12,2);
            DateOnly idoszakVege = new DateOnly(2025,4,21);
            SporteszkozID = sporteszkozID;
            BerlesKezdet = berlesKezdet;
            NapokSzama = napokSzama;
            BerloNev = berloNev;
            if (idoszakKezdete > berlesKezdet || berlesKezdet > idoszakVege || BerlesVeg > idoszakVege)
            {
                throw new HibasDatumException();
            }
        }

        public override string ToString()
        {
            
            return $"{BerlesKezdet} - {BerlesVeg} {BerloNev}";
        }
    }
}
