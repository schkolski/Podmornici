using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Podmornici
{
    public class Brod
    {
        public enum Nasoka
        {
            Vertikalno = 0,
            Horizontalno = 1,
        } 
        public int Golemina { get; set; }
        // Pozicija: true za horizontalno, false za vertikalno
        public Nasoka nasoka { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Pogodoci { get; set; }
        public Brod(int golemina, Nasoka naso, int x, int y)
        {
            Golemina = golemina;
            nasoka = naso;
            X = x;
            Y = y;
            Pogodoci = 0;

        }
        public void Pomesti(int novX, int novY)
        {
            X = novX;
            Y = novY;
        }

        public bool tukaSum(int x, int y)
        {
            if (Nasoka.Horizontalno == nasoka)
            {
                if (x == X && y < Y + Golemina && y >= Y)
                {
                    return true;
                }
            }
            else
            {
                if (y == Y && x < X + Golemina && x >= X)
                {
                    return true;
                }
            }
            return false;
        }
        public void pogodi(int x, int y)
        {
            if (tukaSum(x,y))
            {
                Pogodoci++;
            }
        }

        public bool potopen()
        {
            return Pogodoci == Golemina;
        }

        public bool pogoden()
        {
            return Pogodoci>0;
        }

        public void crtaj (Graphics g, bool igrach)
        {
            if (igrach && potopen())
            {
                Brush cetka = new SolidBrush(Color.Black);
                if (nasoka == Brod.Nasoka.Horizontalno)
                {
                    g.FillEllipse(cetka, Y * 30 + 25 + 5, X * 30 + 50 + 2, 30 * Golemina - 10, 26);
                }
                else
                {
                    g.FillEllipse(cetka, Y * 30 + 25 + 2, X * 30 + 50 + 5, 26, 30 * Golemina - 10);
                }
            }
            else if (igrach)
            {
                Brush cetka = new SolidBrush(Color.Gray);
                if (nasoka == Brod.Nasoka.Horizontalno)
                {
                    g.FillEllipse(cetka, Y * 30 + 25 + 5, X * 30 + 50 + 2, 30 * Golemina - 10, 26);
                }
                else
                {
                    g.FillEllipse(cetka, Y * 30 + 25 + 2, X * 30 + 50 + 5, 26, 30 * Golemina - 10);
                }

            }
            else if (!igrach && potopen())
            {
                Brush cetka = new SolidBrush(Color.Black);
                if (nasoka == Brod.Nasoka.Horizontalno)
                {
                    g.FillEllipse(cetka, Y * 30 + 375 + 5, X * 30 + 50 + 2, 30 * Golemina - 10, 26);
                }
                else
                {
                    g.FillEllipse(cetka, Y * 30 + 375 + 2, X * 30 + 50 + 5, 26, 30 * Golemina - 10);
                }
            }
        }

        public override string ToString()
        {
            return string.Format("({0},{1}) size:{2} poz:{3}", X, Y, Golemina, nasoka);
        }
    }
}
