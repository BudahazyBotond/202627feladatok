using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eletjatek
{
    internal class EletjatekSzimulator
    {
        private int SorokSzama;
        private int OszlopokSzama;
        private int[,] Matrix;
        private Random rnd = new Random();

        public EletjatekSzimulator(int sorok, int oszlopok)
        {
            SorokSzama = sorok;
            OszlopokSzama = oszlopok;

            Matrix = new int[SorokSzama + 2, OszlopokSzama + 2];

            MatrixFeltoltes();
            
        }

        private void MatrixFeltoltes()
        {
            for(int i = 0; i<SorokSzama+2; i++)
            {
                for (int j = 0; j < SorokSzama + 2; j++)
                {
                    if(i==0 || j == 0 || i == SorokSzama + 1 || j == OszlopokSzama + 1)
                    {
                        Matrix[i, j] = 0;
                    }
                    else
                    {
                        Matrix[i, j] = rnd.Next(2);
                    }
                }
            }
        }
        private void Megjelenit()
        {
            Console.Clear();

            for (int i = 0; i < SorokSzama + 2; i++)
            {
                for (int j = 0; j < OszlopokSzama + 2; j++)
                {
                    if (i == 0 || j == 0 || i == SorokSzama + 1 || j == OszlopokSzama + 1)
                    {
                        Console.Write("X");
                    }
                    else
                    {
                        Console.Write(Matrix[i, j] == 1 ? "S" : " ");
                    }
                }
                Console.WriteLine();
            }
        }

        private void KovetkezoKor()
        {
            int[,] uj = new int[SorokSzama + 2, OszlopokSzama + 2];

            for (int i = 1; i <= SorokSzama; i++)
            {
                for (int j = 1; j <= OszlopokSzama; j++)
                {
                    int szomszedok = 0;

                    for (int x = i-1; x <= i+1; x++)
                    {
                        for (int y = j-1; y <= j+1; y++)
                        {
                            if (Matrix[x,y]==1)
                            {
                                szomszedok += 1;
                            }
                        }
                    }

                    if (Matrix[i, j] == 1)
                    {
                        if (szomszedok == 2 || szomszedok == 3)
                            uj[i, j] = 1;
                        else
                            uj[i, j] = 0;
                    }
                    else
                    {
                        if (szomszedok == 3)
                            uj[i, j] = 1;
                        else
                            uj[i, j] = 0;
                    }
                }
            }

            for (int i = 1; i <= SorokSzama; i++)
            {
                for (int j = 1; j <= OszlopokSzama; j++)
                {
                    Matrix[i, j] = uj[i, j];
                }
            }
        }

        public void Run()
        {
            Megjelenit();
            KovetkezoKor();
            Thread.Sleep(500);
        }
    }
}
