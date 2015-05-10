using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

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

        public int []  brodovi { get; set; }
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

        public bool mapaVoRed()
        {
            foreach (Brod b in Brodovi)
            {
                if (!b.voRed)
                {
                    return false;
                }
               
            }
            return true;
        }

        public int pukaj(int x, int y) 
        {
                if (x >= 0 && x < 10 && y >= 0 && y < 10)
                {
                    Console.WriteLine(mapa[x][y].ToString()+"****************");
                    if (mapa[x][y] == Sostojba.Brod)
                    {
                        mapa[x][y] = Sostojba.PogodenBrod;

                        foreach (Brod b in Brodovi)
                        {
                            b.pogodi(x, y);
                            
                        }
                        return 1;

                    }
                    else if (mapa[x][y] == Sostojba.Slobodno)
                    {
                        mapa[x][y] = Sostojba.Promasheno;
                        return 0;
                    }
                    return -1;
                }
            return -1;
        }
        public void obnoviMapa(Brod B)
        {
            if (B != null)
            {
                Brodovi.Remove(B);
                Brodovi.Add(B);
            }

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

            foreach (Brod b in Brodovi)
            {
                    if (proveri(b))
                    {
                        b.voRed = true;
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

                    }
                    else
                    {
                        b.voRed = false;
                    }

               
            }
        }


        public Boolean brodVoMapa(Brod b)
        {
            if (b.nasoka == Brod.Nasoka.Horizontalno) // horizontalno
            {
                if (b.X < 0 || b.X >= 10 || b.Y < 0 || b.Y + b.Golemina > 10)
                {
                    return false;
                }
            }
            else
            {
                if (b.Y < 0 || b.Y >= 10 || b.X < 0 || b.X + b.Golemina > 10)
                {
                    return false;
                }

            }
            return true;
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
                if (b.X < 0 || b.X >= 10 || b.Y < 0 || b.Y + b.Golemina >10)
                {
                    Console.WriteLine("Ovde1");
                    return false;
                   
                }
                for (int i = b.Y; i < b.Y + b.Golemina; i++)
                {
                    if (mapa[b.X][i] == Sostojba.Brod)
                    {
                        Console.WriteLine("Ovde2");
                        return false;
                    }
                }
                return true;
            }
            else 
            {
                if (b.Y < 0 || b.Y >= 10 || b.X < 0 || b.X + b.Golemina > 10)
                {
                    Console.WriteLine("Ovde3");
                    return false;
                }
                for (int i = b.X; i < b.X + b.Golemina; i++)
                {
                    Console.WriteLine("Ovde4");
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
            mapa = new Sostojba[10][];
            for (int a = 0; a < 10; a++)
                mapa[a] = new Sostojba[10];
            for (int a = 0; a < 10; a++)
            {
                for (int j = 0; j < 10; j++)
                {
                    mapa[a][j] = Sostojba.Slobodno;
                }
            }
            Brodovi = new List<Brod>();
            Console.WriteLine(Brodovi.Count);
            int i = 2;
            Random rand = new Random();
            while (i < 6)
            {
                Brod b = new Brod(i, Brod.Nasoka.Horizontalno, rand.Next(0, 10), rand.Next(0, 10));
                if(rand.Next(0, 2) == 1){
                    b.smeniNasoka();
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
