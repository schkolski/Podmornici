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
using System.Resources;
using System.Drawing.Drawing2D;
namespace Podmornici
{
    public partial class Form1 : Form
    {
        Game igra { get; set; }

        Image pozadina { get; set; }
        NewGame forma;
        Game.Nivo nivo;
        int rez_igrach;
        int rez_bot;
        String ime;
        public Form1(String ime , MapaIgrach mapa_igrach, NewGame forma, Game.Nivo level, int rez_igrach, int rez_bot)
        {
            InitializeComponent();
            // smeni algoritam soodvetno
            
            igra = new Game(level, ime, mapa_igrach);
            foreach(Brod b in igra.mapaIgrach.Brodovi)
            {
                Console.WriteLine(b.ToString());
            }
            this.ime = ime;
            this.forma = forma;
            this.nivo = level;
            this.rez_igrach = rez_igrach;
            this.rez_bot = rez_bot;

            timer.Start();
            DoubleBuffered = true;
            Invalidate();
            lblRezultat.Text = ime + " " + rez_igrach + " : " + rez_bot + " Бот";
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);
            igra.crtaj(e.Graphics);
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            int x = e.X;
            int y = e.Y;
            if (igra.IgracNaRed)
            {
                if (x >= 410 && x <= 710 && y >= 100 && y <= 400)
                {
                    x = (e.Y - 100) / 30;
                    y = (e.X - 410) / 30;
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
                igra.GagajBot();

                
                Invalidate();
            }

            if (igra.zavrsena() == 1)
            {
                this.Hide();
                timer.Enabled = false;
                Form2 f = new Form2(true, forma, nivo, rez_igrach, rez_bot, ime);
                f.Show();
                
            }

            if (igra.zavrsena() ==- 1)
            {
                this.Hide();
                timer.Enabled = false;
                Form2 f = new Form2(false, forma, nivo, rez_igrach, rez_bot, ime);
                f.Show();

            }
            
        }

        private void lblRed_Click(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
