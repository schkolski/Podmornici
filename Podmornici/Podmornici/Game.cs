using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using Podmornici.Properties;
using System.Reflection;
using System.IO;
using System.Drawing.Drawing2D;

namespace Podmornici
{
    public class Game
    {
        public enum Nivo
        {
            lesno, 
            tesko
        }
        public MapaIgrach mapaIgrach { get; set; }
        public MapaBot mapaBot { get; set; }
        public bool IgracNaRed { get; set; }
        public Nivo nivo { get; set; }
        public List<Point> slobodni { get; set; }
        Pen moliv;
        Image slikaPodmornici;
        Image slikaDzid;
        Image slikaMore;
        Image brod2Potopen;
        Image brod4Potopen;
        Image brod2ok;
        Image brod4ok;
        private Point predhodenPogodok { get; set; }
        public SoundPlayer pogodok { get; set; }
        public SoundPlayer promasheno { get; set; }
        public Game(Nivo n, String ime, MapaIgrach mapa_igrach)
        {
            mapaIgrach = mapa_igrach;
            mapaBot = new MapaBot();
            // mapaIgrach.napolniSlucajno();
            mapaBot.napolniSlucajno();
            IgracNaRed = true;
            nivo = n;
            slobodni = new List<Point>();
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    slobodni.Add(new Point(i, j));
                }
            }
            moliv = new Pen(Color.Chocolate);
            
            Stream str = Properties.Resources.promasuvanje1;
            promasheno = new SoundPlayer(str);
            Stream str1 = Resources.pogodok;
            pogodok = new SoundPlayer(str1);
            slikaPodmornici = Resources.Podmornici;
            slikaDzid = Resources.dzid;
            slikaMore = Resources.okean;
            predhodenPogodok = Point.Empty;
            pocetenPogodok = Point.Empty;
            nasokaPogodok = Kompas.None;
            brod2Potopen = Resources._4mc;
            brod4Potopen = Resources._5mc;
            brod2ok = Resources._4m;
            brod4ok = Resources._5m;

        }
        enum Kompas
        {
            Istok,
            Zapad,
            Sever,
            Jug,
            None
        }
        Point pocetenPogodok;
        Kompas nasokaPogodok { get; set; }
        public void GagajBot()
        {
            Console.WriteLine(nivo);
            Random rand = new Random();
            if (nivo == Nivo.lesno)
            {
                int idx = rand.Next(0, slobodni.Count);
                Point p = slobodni[idx];
                //mapaIgrach.pukaj(p.X, p.Y);
                if (mapaIgrach.pukaj(p.X,p.Y)==0)
                {
                    promasheno.Play();
                    IgracNaRed = !IgracNaRed;
                }
                else
                {
                    pogodok.Play();
                }
                slobodni.Remove(p);
            }
            else if (nivo == Nivo.tesko)
            {
                if (predhodenPogodok == Point.Empty)
                {
                    int idx = rand.Next(0, slobodni.Count);
                    Point p = slobodni[idx];
                    if (mapaIgrach.pukaj(p.X, p.Y) == 0)
                    {
                        promasheno.Play();
                        IgracNaRed = !IgracNaRed;
                    }
                    else
                    {
                        pogodok.Play();
                        predhodenPogodok = p;
                        pocetenPogodok = p;
                    }
                    slobodni.Remove(p);
                }
                else
                {
                    if (nasokaPogodok == Kompas.None)
                    {
                        List<Point> sosedi = zemiSlobodniSosedi(predhodenPogodok);
                        int idx = rand.Next(0, sosedi.Count);
                        Point p = sosedi[idx];
                        if (mapaIgrach.pukaj(p.X, p.Y) == 1)
                        {
                            if (predhodenPogodok.X == p.X)
                            {
                                if (predhodenPogodok.Y - p.Y > 0)
                                {
                                    nasokaPogodok = Kompas.Sever;
                                }
                                else
                                {
                                    nasokaPogodok = Kompas.Jug;
                                }
                            }
                            else
                            {
                                if (predhodenPogodok.X - p.X > 0)
                                {
                                    nasokaPogodok = Kompas.Zapad;
                                }
                                else
                                {
                                    nasokaPogodok = Kompas.Istok;
                                }
                            }
                        }
                        else
                        {
                            IgracNaRed = !IgracNaRed;
                        }
                        slobodni.Remove(p);
                        if(brodotPotona(p)){
                            nasokaPogodok = Kompas.None;
                            predhodenPogodok = Point.Empty;
                            pocetenPogodok = Point.Empty;
                        }
                    }
                    else
                    {
                        Point p = predhodenPogodok;
                        if(nasokaPogodok == Kompas.Sever)
                            p.X --;
                        else if(nasokaPogodok == Kompas.Jug)
                            p.X ++;
                        else if(nasokaPogodok == Kompas.Istok)
                            p.Y++;
                        else if(nasokaPogodok == Kompas.Zapad)
                            p.Y--;

                        if(mapaIgrach.pukaj(p.X, p.Y) == 1)
                            predhodenPogodok = p;
                        else if(!brodotPotona(predhodenPogodok))
                        {
                            if (nasokaPogodok == Kompas.Sever)
                            {
                                nasokaPogodok = Kompas.Jug;
                            }
                            else if (nasokaPogodok == Kompas.Jug)
                            {
                                nasokaPogodok = Kompas.Sever;
                            }
                            else if (nasokaPogodok == Kompas.Zapad)
                            {
                                nasokaPogodok = Kompas.Istok;
                            }
                            else if (nasokaPogodok == Kompas.Istok)
                            {
                                nasokaPogodok = Kompas.Zapad;
                            }
                            predhodenPogodok = pocetenPogodok;
                            IgracNaRed = !IgracNaRed;
                        }
                        else
                        {
                            predhodenPogodok = Point.Empty;
                            pocetenPogodok = Point.Empty;
                        }

                        slobodni.Remove(p);
                        if(brodotPotona(p)){
                            nasokaPogodok = Kompas.None;
                            predhodenPogodok = Point.Empty;
                            pocetenPogodok = Point.Empty;
                        }
                    }
                }
            }
            
           // IgracNaRed = !IgracNaRed;
        }
        private bool brodotPotona(Point q)
        {
            foreach (Brod b in mapaIgrach.Brodovi)
            {
                if (b.tukaSum(q.X, q.Y))
                {
                    return b.potopen();
                }
            }
            return false;
        }
        private List<Point> zemiSlobodniSosedi(Point p)
        {
            List<Point> sosedi = new List<Point>();
            foreach (Point q in slobodni)
            {
                if (q.X == p.X && Math.Abs(q.Y - p.Y) == 1)
                {
                    sosedi.Add(q);
                }
                else if (q.Y == p.Y && Math.Abs(q.X - p.X) == 1)
                {
                    sosedi.Add(q);
                }
            }
            return sosedi;
        }
        public void GagajIgrac(int x, int y)
        {
            if (mapaBot.pukaj(x, y) == 0) {
                
                IgracNaRed = !IgracNaRed;
                promasheno.Play();
            }
            else
            {
                pogodok.Play();
            }
        }

        public void crtaj(Graphics g)
        {


            g.Clear(Color.White);

            g.DrawImage(slikaPodmornici, 0, 0, 800, 70);
            g.DrawImageUnscaled(slikaDzid, 0, 70);
            g.DrawImage(slikaMore, 50, 100, 300, 300);
            g.DrawImage(slikaMore, 410, 100, 300, 300);

            int x = 50;
            int y = 100;
            Pen moliv = new Pen(Color.White);
            for (int i = 0; i < 11; i++)
            {
                g.DrawLine(moliv, x + i * 30, y, x + i * 30, y + 300);
                g.DrawLine(moliv, x, y + i * 30, x + 300, y + i * 30);

                g.DrawLine(moliv, 360 + x + i * 30, y, 360 + x + i * 30, y + 300);
                g.DrawLine(moliv, x + 360, y + i * 30, x + 660, y + i * 30);


            }
            moliv.Dispose();
            String tekst = "Подморници";
            Font drawFont = new Font("Microrosf Sans Serif", 35, FontStyle.Bold);
            LinearGradientBrush linGrBrush = new LinearGradientBrush(
                new Point(0, 200),
                new Point(0, 100),
                Color.FromArgb(255, 255, 0, 0),
                Color.FromArgb(255, 255, 255, 0));
            float xx = 40.0F;
            float yy = 13.0F;
            StringFormat drawFormat = new StringFormat();
            g.DrawString(tekst, drawFont, linGrBrush, xx, yy, drawFormat);
            drawFormat.Dispose();
            linGrBrush.Dispose();
            Pen moliv1 = new Pen(Color.Red, 3);
            if (!IgracNaRed)
            {
                g.DrawLine(moliv1, 50, 100, 350, 100);
                g.DrawLine(moliv1, 50, 100, 50, 400);
                g.DrawLine(moliv1, 350, 100, 350, 400);
                g.DrawLine(moliv1, 50, 400, 350, 400);
            }
            else
            {
                g.DrawLine(moliv1, 410, 100, 710, 100);
                g.DrawLine(moliv1, 410, 100, 410, 400);
                g.DrawLine(moliv1, 410, 400, 710, 400);
                g.DrawLine(moliv1, 710, 100, 710, 400);
            }
            moliv1.Dispose();
            mapaIgrach.crtaj(g);
            mapaBot.crtaj(g);

            g.DrawImage(slikaMore, 30, 410, 710, 40);

            foreach(Brod b in mapaBot.Brodovi){
                if (b.Golemina == 2)
                {
                    if (b.potopen())
                    {
                        g.DrawImage(brod2Potopen, 50, 415, 60, 30);

                    }
                    else
                    {
                        g.DrawImage(brod2ok, 50, 415, 60, 30);
                    }
                }

                if (b.Golemina == 3)
                {
                    if (b.potopen())
                    {
                        g.DrawImage(brod2Potopen, 190, 415, 90, 30);
                    }
                    else
                    {
                        g.DrawImage(brod2ok, 190, 415, 90, 30);
                    }
                }

                if (b.Golemina == 4)
                {
                    if (b.potopen())
                    {
                        g.DrawImage(brod4Potopen, 350, 415, 120, 30);
                    }
                    else
                    {
                        g.DrawImage(brod4ok, 350, 415, 120, 30);
                    }
                }

                if (b.Golemina == 5)
                {
                    if (b.potopen())
                    {
                        g.DrawImage(brod4Potopen, 550, 415, 150, 30);
                    }
                    else
                    {
                        g.DrawImage(brod4ok, 550, 415, 150, 30);
                    }
                }
            }
       }

        public int zavrsena()
        {
            bool krajIgrach = true;
            foreach (Brod b in mapaIgrach.Brodovi)
            {
                if (!b.potopen())
                {
                    krajIgrach = false;
                    break;
                }
            }

            bool krajbot = true;
            foreach (Brod b in mapaBot.Brodovi)
            {
                if (!b.potopen())
                {
                    krajbot = false;
                    break;
                }
            }
            if (!krajIgrach && !krajbot)
            {
                return 0;
            }
            if (krajIgrach)
            {
                return -1;
            }
            return 1;

        }
    }
}
