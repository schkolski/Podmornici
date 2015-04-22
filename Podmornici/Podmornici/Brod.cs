using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Podmornici
{
    public class Brod
    {
        public int Golemina { get; set; }
        // Pozicija: true za horizontalno, false za vertikalno
        public bool Pozicija { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Pogodoci { get; set; }
        public Brod(int golemina, bool pozicija, int x, int y)
        {
            Golemina = golemina;
            Pozicija = pozicija;
            X = x;
            Y = y;
            Pogodoci = 0;
        }
        public void Pomesti(int novX, int novY)
        {
            X = novX;
            Y = novY;
        }
        public void pogodi(int x, int y)
        {
            if (Pozicija)
            {
                if (x == X && y < Y + Golemina && y >= Y)
                {
                    Pogodoci++;
                }
            }
            else
            {
                if (y == Y && x < X + Golemina && x >= X)
                {
                    Pogodoci++;
                }
            }
        }
        public override string ToString()
        {
            return string.Format("({0},{1}) size:{2} poz:{3}", X, Y, Golemina, Pozicija);
        }
    }
}
