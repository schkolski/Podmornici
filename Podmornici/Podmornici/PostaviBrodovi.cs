using Podmornici.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
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
        Game.Nivo Nivo;
        String Ime;
        NewGame forma;
        int rez_igrach;
        int rez_bot;
        MapaIgrach mapaIgrach { get; set; }
        Image slikaPodmornici;
        Image slikaDzid;
        Image slikaMore;
        Timer timer;

        public PostaviBrodovi(String ime, Game.Nivo nivo, NewGame forma, int rez_igrach, int rez_bot)
        {

            InitializeComponent();
            Ime = ime;
            Nivo = nivo;
            pritisnatMaus = false;
            this.forma = forma;
            this.rez_igrach = rez_igrach;
            this.rez_bot = rez_bot;
            DoubleBuffered = true;
            namestiOsnovno();
            slikaPodmornici = Resources.Podmornici;
            slikaDzid = Resources.dzid;
            slikaMore = Resources.okean;
            lblRezultat.Text = ime + " " + rez_igrach + " : "+ rez_bot  +  " Бот" ;
            timer = new Timer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = 50;
            timer.Enabled = true;
            timer.Start();
            Invalidate();
            
        }

        private void namestiOsnovno()
        {
            mapaIgrach = new MapaIgrach();
            mapaIgrach.Brodovi.Add(new Brod(2, Brod.Nasoka.Horizontalno, 0, 12));
            mapaIgrach.Brodovi.Add(new Brod(3, Brod.Nasoka.Horizontalno, 2, 12));
            mapaIgrach.Brodovi.Add(new Brod(4, Brod.Nasoka.Horizontalno, 4, 12));
            mapaIgrach.Brodovi.Add(new Brod(5, Brod.Nasoka.Horizontalno, 6, 12));
            mapaIgrach.obnoviMapa(null);
            
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
            if (selektiran != null)
            {
                mapaIgrach.obnoviMapa(selektiran);
            }
            
        }

        private void PostaviBrodovi_MouseUp(object sender, MouseEventArgs e)
        {
            if (selektiran != null) {
                mapaIgrach.dodajBrodNaMapa(selektiran);
                pritisnatMaus = false;
                Point p = selektiran.voPiksel(selektiran.X, selektiran.Y);
                selektiran.pikselX = p.X;
                selektiran.pikselY = p.Y;
                mapaIgrach.obnoviMapa(selektiran);
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
                    mapaIgrach.obnoviMapa(selektiran);
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

            g.DrawImage(slikaPodmornici, 0, 0, 760, 70);
            g.DrawImageUnscaled(slikaDzid, 0, 70);
            g.DrawImage(slikaMore, 50, 100, 300, 300);
            //g.DrawImage(slikaMore, 410, 100, 300, 300);

            String tekst = "Подморници";
            Font drawFont = new Font("Microrosf Sans Serif", 35, FontStyle.Bold);
            SolidBrush drawBrush = new SolidBrush(System.Drawing.Color.Firebrick);
            LinearGradientBrush linGrBrush = new LinearGradientBrush(
                new Point(0,200),
                new Point(0,100),
                Color.FromArgb(255, 255, 0, 0),   
                Color.FromArgb(255, 255, 255, 0)); 
            float xx = 40.0F;
            float yy = 13.0F;
            StringFormat drawFormat = new StringFormat();
            e.Graphics.DrawString(tekst, drawFont, linGrBrush, xx, yy, drawFormat);
            linGrBrush.Dispose();

            foreach (Brod b in mapaIgrach.Brodovi)
            {
                b.crtaj(g, true);
            }

            int x = 50;
            int y = 100;
            Pen moliv = new Pen(Color.White);
            for (int i = 0; i < 11; i++)
            {
                g.DrawLine(moliv, x + i * 30, y, x + i * 30, y+300);
                g.DrawLine(moliv, x, y + i * 30, x + 300, y + i * 30);

                //g.DrawLine(moliv, 360 + x + i * 30, y, 360 + x + i * 30, y + 350);
                //g.DrawLine(moliv, x + 360, y + i * 30, x + 660, y + i * 30);

             
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
                        mapaIgrach.obnoviMapa(b);
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
            this.Hide();
            Form1 n = new Form1(Ime,mapaIgrach, forma, Nivo, rez_igrach, rez_bot);
            n.Show();
            
        }

        void timer_Tick(object sender, EventArgs e)
        {
            if (mapaIgrach.mapaVoRed())
            {
                btnPocni.Visible = true;
            }
            else
            {
                btnPocni.Visible = false;
            }
        }

        private void PostaviBrodovi_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnRandom_MouseHover(object sender, EventArgs e)
        {
            btnRandom.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        private void btnRandom_MouseLeave(object sender, EventArgs e)
        {
            btnRandom.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        private void btnResetiraj_MouseHover(object sender, EventArgs e)
        {
            btnResetiraj.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        private void btnResetiraj_MouseLeave(object sender, EventArgs e)
        {
            btnResetiraj.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        private void btnPocni_MouseHover(object sender, EventArgs e)
        {
            btnPocni.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        private void btnPocni_MouseLeave(object sender, EventArgs e)
        {
            btnPocni.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        private void PostaviBrodovi_Load(object sender, EventArgs e)
        {

        }
    }
}
