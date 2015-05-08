using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Podmornici
{
    public class Game
    {
        public enum Nivo
        {
            lesno,
            sredno, 
            tesko
        }
        public MapaIgrach mapaIgrach { get; set; }
        public MapaBot mapaBot { get; set; }
        public bool IgracNaRed { get; set; }
        public Nivo nivo { get; set; }
        public List<Point> slobodni { get; set; }
        Pen moliv;
        public Game(Nivo n)
        {
            mapaIgrach = new MapaIgrach();
            mapaBot = new MapaBot();
            mapaIgrach.napolniSlucajno();
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
        }
        
        public void GagajBot()
        {
            Console.WriteLine(nivo);
            Random rand = new Random();
            if (nivo == Nivo.lesno)
            {
                int idx = rand.Next(0, slobodni.Count);
                Point p = slobodni[idx];
                mapaIgrach.pukaj(p.X, p.Y);
                Console.WriteLine("OVDEEEEEEEE:" + p.X, p.Y);
                slobodni.Remove(p);
            }
            else if (nivo == Nivo.sredno)
            {

            }
            else
            {

            }
            IgracNaRed = !IgracNaRed;
        }

        public void GagajIgrac(int x, int y)
        {
            if (mapaBot.pukaj(x, y)) { 
                IgracNaRed = !IgracNaRed;
            }
        }

        public void crtaj(Graphics g)
        {
            int x = 25;
            int y = 50;
            for(int i = 0; i < 11; i++){
                g.DrawLine(moliv, x + i * 30, y, x + i * 30, 350);
                g.DrawLine(moliv, 25, y + i*30, 325, y+i*30);

                g.DrawLine(moliv, 350 + x + i * 30, y, 350 + x + i * 30, 350);
                g.DrawLine(moliv, 375, y + i * 30, 675, y + i * 30);

            }

            mapaIgrach.crtaj(g);
            mapaBot.crtaj(g);
       }
    }
}
