using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Podmornici
{
    public class Mapa
    {
        public int[][] mapa { get; set; }
        public List<Brod> Brodovi { get; set; }
        public Mapa()
        {
            mapa = new int[10][];
            for (int i = 0; i < 10; i++)
                mapa[i] = new int[10];
            Brodovi = new List<Brod>();
        }

        public bool pukaj(int x, int y)
        {
            if (x >= 0 && x < 10 && y >= 0 && y < 10)
            {
                if (mapa[x][y] == 1)
                {
                    mapa[x][y] = -1;
                    foreach (Brod b in Brodovi)
                    {
                        b.pogodi(x, y);
                    }
                    return true;
                }
                else if(mapa[x][y] == 0)
                {
                    mapa[x][y] = -2;
                    return false;
                }
            }
            return false;
            
        }

        public void dodajBrodNaMapa(Brod b)
        {
            if (proveri(b))
            {
                if (b.Pozicija) // horizontalno
                {
                    for (int i = b.Y; i < b.Y + b.Golemina; i++)
                    {
                        mapa[b.X][i] = 1;
                    }
                }
                else
                {
                    for (int i = b.X; i < b.X + b.Golemina; i++)
                    {
                        mapa[i][b.Y] = 1;
                    }
                }
                Brodovi.Add(b);
            }
        }
        public bool proveri(Brod b)
        {
            if (b.Pozicija) // horizontalno
            {
                if (b.X < 0 || b.X >= 10 || b.Y < 0 || b.Y + b.Golemina >= 10)
                {
                    return false;
                }
                for (int i = b.Y; i < b.Y + b.Golemina; i++)
                {
                    if (mapa[b.X][i] == 1)
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
                    if (mapa[i][b.Y] == 1)
                    {
                        return false;
                    }
                }
                return true;
            }
        }
        public void napolniSlucajno()
        {
            int i = 2;
            Random rand = new Random();
            while (i < 6)
            {
                Brod b = new Brod(i, rand.Next(0, 2) == 1, rand.Next(0, 10), rand.Next(0, 10));
                if (proveri(b))
                {
                    i++;
                    dodajBrodNaMapa(b);
                }
            }
        }
    }
}
