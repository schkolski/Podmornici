using Podmornici.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Podmornici
{
    public partial class Form1 : Form
    {
        Game igra { get; set; }

        Image pozadina { get; set; }
        public Form1(String ime , MapaIgrach mapa_igrach)
        {
            InitializeComponent();
            
            igra = new Game(Game.Nivo.lesno, ime, mapa_igrach);
            foreach(Brod b in igra.mapaIgrach.Brodovi)
            {
                Console.WriteLine(b.ToString());
            }
            this.Width += 40;
            this.Height += 40;
            pozadina = Resources.ocean;
            timer.Start();
            DoubleBuffered = true;
            Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);
            e.Graphics.DrawImage(pozadina, new Rectangle(0, 0, 740, 440));
            igra.crtaj(e.Graphics);
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            Console.WriteLine(e.X + " " + e.Y);
            Console.WriteLine("X = " + (((e.Y - 50) / 30) + 1) + " Y=" + (((e.X - 375) / 30) + 1));
            int x = e.X;
            int y = e.Y;
            if (igra.IgracNaRed)
            {
                if (x >= 375 && x <= 675 && y >= 50 && y <= 350)
                {
                    x = (e.Y - 50) / 30;
                    y = (e.X - 375) / 30;
                    lblRed.Text = "Бот на ред";
                    igra.GagajIgrac(x, y);

                    Invalidate();
                }
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            //Console.WriteLine(igra.IgracNaRed);
            if (!igra.IgracNaRed)
            {
                lblRed.Text = "Играч на ред";
                igra.GagajBot();
                Invalidate();
            }
        }
    }
}
