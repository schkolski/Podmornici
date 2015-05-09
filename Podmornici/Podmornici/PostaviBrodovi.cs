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
    public partial class PostaviBrodovi : Form
    {
        private bool pritisnatMaus;
        private int prevX;
        private int prevY;
        Brod selektiran;
        bool Nivo;
        String Ime;
        MapaIgrach mapaIgrach { get; set; }
        public PostaviBrodovi(String ime, bool nivo)
        {

            InitializeComponent();
            Ime = ime;
            Nivo = nivo;
            pritisnatMaus = false;
  
            DoubleBuffered = true;
            namestiOsnovno();
            Invalidate();
        }

        private void namestiOsnovno()
        {
            mapaIgrach = new MapaIgrach();
           
            mapaIgrach.Brodovi.Add(new Brod(3, Brod.Nasoka.Horizontalno, 2, 12));
            mapaIgrach.Brodovi.Add(new Brod(4, Brod.Nasoka.Horizontalno, 4, 12));
            mapaIgrach.Brodovi.Add(new Brod(5, Brod.Nasoka.Horizontalno, 6, 12));
            mapaIgrach.Brodovi.Add(new Brod(2, Brod.Nasoka.Horizontalno, 0, 12));
        }
        private void PostaviBrodovi_MouseDown(object sender, MouseEventArgs e)
        {
            pritisnatMaus = true;
            
            foreach (Brod b in mapaIgrach.Brodovi)
            {

                Console.WriteLine(b.ToString());

                if (b.selektiranSum(e.X, e.Y))
                {
                    selektiran = b;
                    break;
                }
            }
            prevX = e.X;
            prevY = e.Y;
        }

        private void PostaviBrodovi_MouseUp(object sender, MouseEventArgs e)
        {
            if (selektiran != null) {
                mapaIgrach.dodajBrodNaMapa(selektiran);
                pritisnatMaus = false;
                Point p = selektiran.voPiksel(selektiran.X, selektiran.Y);
                selektiran.pikselX = p.X;
                selektiran.pikselY = p.Y;
                selektiran = null;
            }
            
        }

        private void PostaviBrodovi_MouseMove(object sender, MouseEventArgs e)
        {
            if (pritisnatMaus)
            {
                if (selektiran != null)
                {
                    int dx = e.X - prevX;
                    int dy = e.Y - prevY;
                    selektiran.Pomesti(dx, dy);
                    Invalidate();
                }
                prevX = e.X;
                prevY = e.Y;
            }      
        }

        private void PostaviBrodovi_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Color.White);
            foreach (Brod b in mapaIgrach.Brodovi)
            {
                b.crtaj(g, true);
            }

            int x = 25;
            int y = 50;
            Pen moliv = new Pen(Color.Chocolate);
            for (int i = 0; i < 11; i++)
            {
                g.DrawLine(moliv, x + i * 30, y, x + i * 30, 350);
                g.DrawLine(moliv, 25, y + i * 30, 325, y + i * 30);

                //g.DrawLine(moliv, 360 + x + i * 30, y, 360 + x + i * 30, 350);
                //g.DrawLine(moliv, 385, y + i * 30, 685, y + i * 30);

             
            }
            moliv.Dispose();
            mapaIgrach.crtaj(g);
        }

        private void PostaviBrodovi_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                foreach (Brod b in mapaIgrach.Brodovi)
                {
                    if (b.selektiranSum(e.X, e.Y))
                    {
                        b.smeniNasoka();
                        Invalidate();
                        break;
                    }
                }
            }
        }

        private void btnResetiraj_Click(object sender, EventArgs e)
        {
            namestiOsnovno();
            Invalidate();
        }

        private void btnRandom_Click(object sender, EventArgs e)
        {

            mapaIgrach.napolniSlucajno();
            Invalidate();
        }

        private void btnPocni_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < 9; i++)
            {
                for(int j = 0; j < 9 ; j++)
                {
                    Console.Write(mapaIgrach.mapa[i][j].ToString());
                }
                Console.WriteLine();
            }
            Form1 n = new Form1(Ime,mapaIgrach);
            n.Show();
        }
    }
}
