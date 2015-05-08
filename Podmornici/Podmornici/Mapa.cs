using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;

namespace Podmornici
{
    public abstract class Mapa
    {
        public enum Sostojba
        {
            Slobodno,
            Promasheno,
            PogodenBrod,
            Brod,
        }
        public Sostojba[][] mapa { get; set; }
        public List<Brod> Brodovi { get; set; }
        public Mapa()
        {
            mapa = new Sostojba[10][];
            for (int i = 0; i < 10; i++)
                mapa[i] = new Sostojba[10];
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    mapa[i][j] = Sostojba.Slobodno;
                }
            }
            Brodovi = new List<Brod>();
        }

        public bool pukaj(int x, int y)
        {
            if (x >= 0 && x < 10 && y >= 0 && y < 10)
            {
                if (mapa[x][y] == Sostojba.Brod)
                {
                    mapa[x][y] = Sostojba.PogodenBrod;

                    foreach (Brod b in Brodovi)
                    {
                        b.pogodi(x, y);
                    }
                    return true;
                }
                else if(mapa[x][y] == Sostojba.Slobodno)
                {
                    mapa[x][y] = Sostojba.Promasheno;
                    return true;
                }
                return false;
            }
            return false;
        }

        public void dodajBrodNaMapa(Brod b)
        {
            if (proveri(b))
            {
                if (b.nasoka == Brod.Nasoka.Horizontalno) // horizontalno
                {
                    for (int i = b.Y; i < b.Y + b.Golemina; i++)
                    {
                        mapa[b.X][i] = Sostojba.Brod;
                    }
                }
                else
                {
                    for (int i = b.X; i < b.X + b.Golemina; i++)
                    {
                        mapa[i][b.Y] = Sostojba.Brod;
                    }
                }
                Brodovi.Add(b);
            }
        }
        public bool proveri(Brod b)
        {
            if (b.nasoka == Brod.Nasoka.Horizontalno) // horizontalno
            {
                if (b.X < 0 || b.X >= 10 || b.Y < 0 || b.Y + b.Golemina >= 10)
                {
                    return false;
                }
                for (int i = b.Y; i < b.Y + b.Golemina; i++)
                {
                    if (mapa[b.X][i] == Sostojba.Brod)
                    {
                        return false;
                    }
                }
                return true;
            }
            else 
            {
                if (b.Y < 0 || b.Y >= 10 || b.X < 0 || b.X + b.Golemina >= 10)
                {
                    return false;
                }
                for (int i = b.X; i < b.X + b.Golemina; i++)
                {
                    if (mapa[i][b.Y] == Sostojba.Brod)
                    {
                        return false;
                    }
                }
                return true;
            }
        }
        public void napolniSlucajno()
        {
            Console.WriteLine("OVDE!RANDOM!!!!");
            int i = 2;
            Random rand = new Random();
            Thread.Sleep(rand.Next(0,100)); 
            while (i < 6)
            {
                Brod b ;
                if(rand.Next(0, 2) == 1){
                    b = new Brod(i,Brod.Nasoka.Horizontalno, rand.Next(0, 10), rand.Next(0, 10));
                }
                else
                {
                    b = new Brod(i, Brod.Nasoka.Vertikalno, rand.Next(0, 10), rand.Next(0, 10));
                }

                if (proveri(b))
                {
                    i++;
                    dodajBrodNaMapa(b);
                }
            }
        }

        public abstract void crtaj(Graphics g);
        /*{

            foreach (Brod b in Brodovi)
            {
                b.crtaj(g, igrach);
            }
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if(mapa[i][j] == Sostojba.Promasheno){
                        if(igrach){

                        }
                    }
                }
            }
        }*/
    }
}
