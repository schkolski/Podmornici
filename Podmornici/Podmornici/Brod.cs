using Podmornici.Properties;
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
        public Nasoka nasoka { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int pikselX { get; set; }
        public int pikselY { get; set; }
        public int Pogodoci { get; set; }
        public Image brodImg { get; set; }
        public Point voIndeks(int pX, int pY)
        {
            int tmpY = (int)Math.Floor((pX - 25) / 30.0);
            int tmpX = (int)Math.Floor((pY - 50) / 30.0);
            return new Point(tmpX, tmpY);
        }
        public Point voPiksel(int iX, int iY)
        {
            int tmpX = iY * 30 + 25;
            int tmpY = iX * 30 + 50;
            return new Point(tmpX, tmpY);
        }
        
        public Brod(int golemina, Nasoka naso, int x, int y)
        {
            Golemina = golemina;
            nasoka = naso;
            X = x;
            Y = y;
            Pogodoci = 0;
            Point p = voPiksel(x, y);
            pikselX = p.X;
            pikselY = p.Y;
            postaviSlika();
        }
        public void postaviSlika()
        {
            
                brodImg = Resources._5;
            
        }

        public void Pomesti(int dX, int dY)
        {
            pikselX += dX;
            pikselY += dY;

            Point p = voIndeks(pikselX, pikselY);

            X = p.X;
            Y = p.Y;
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

        public bool selektiranSum(int x, int y) // x, y se pikseli
        {
            Console.WriteLine(x + " " + y);
            Console.WriteLine(pikselX + " " + pikselY);
            if (Nasoka.Horizontalno == nasoka)
            {
                if (y >= pikselY && y <= pikselY + 30 && x >= pikselX && x<= pikselX + (Golemina*30))
                {
                    return true;
                }
            }
            else
            {
                if (x >= pikselX && x <= pikselX + 30 && y >= pikselY && y<= pikselY + (Golemina*30))
                {
                    return true;
                }
            }
            return false;
        }

        public void crtaj (Graphics g, bool igrach)
        {
            if (potopen() && igrach)
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
                cetka.Dispose();
            }
            else if (potopen() && !igrach)
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
                cetka.Dispose();
            }
            else if (igrach)
            {
                Point p = voPiksel(X, Y);
                
                // Brush cetka = new SolidBrush(Color.Gray);
                if (nasoka == Brod.Nasoka.Horizontalno)
                {
 //                  g.FillEllipse(cetka, Y * 30 + 25 + 5, X * 30 + 50 + 2, 30 * Golemina - 10, 26);
                    g.DrawImage(brodImg, p.X, p.Y, 30 * Golemina, 30);
                }
                else
                {
//                    g.FillEllipse(cetka, Y * 30 + 25 + 2, X * 30 + 50 + 5, 26, 30 * Golemina - 10);
                    g.DrawImage(brodImg, p.X, p.Y, 30, Golemina * 30);
                }

            }
        }

        public override string ToString()
        {
            return string.Format("({0},{1}) size:{2} poz:{3}", X, Y, Golemina, nasoka);
        }

        public void smeniNasoka()
        {
            if (nasoka == Nasoka.Horizontalno)
            {
                nasoka = Nasoka.Vertikalno;
                brodImg.RotateFlip(RotateFlipType.Rotate90FlipX);
            }
            else
            {
                nasoka = Nasoka.Horizontalno;
                brodImg.RotateFlip(RotateFlipType.Rotate270FlipX);
            }
        }
    }
}
