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
    public partial class Form2 : Form
    {
        Timer timer1;
        List<Konfeta> konfeti;
        int c;
        Image slika;
        float dolzina = 150;
        List<Point> tocki;
        List<Point> siteTocki;
        List<List<Point>> siteListi;
        List<List<Point>> noviTocki;
        bool pobeda;
        NewGame forma;
        Game.Nivo nivo;
        int rez_igrach;
        int rez_bot;
        String ime;

        public Form2(bool pobeda, NewGame form, Game.Nivo nivo, int rez_igrach, int rez_bot, String ime)
        {
            InitializeComponent();
            this.forma = form;
            this.nivo = nivo;
            this.rez_igrach = rez_igrach;
            this.rez_bot = rez_bot;
            this.ime = ime;

            timer1 = new Timer();
            if (pobeda)
            {
                timer1.Tick += new EventHandler(timer1_Tick_Pobeda);
            }
            else
            {
                timer1.Tick += new EventHandler(timer1_Tick_Gubitnik);
            }
            this.pobeda = pobeda;
            timer1.Interval = 50;
            timer1.Enabled = true;
            timer1.Start();
            konfeti = new List<Konfeta>();
            c = 0;
            DoubleBuffered = true;
            slika = Resources.naslovna_slika;
            tocki = new List<Point>();
            noviTocki = new List<List<Point>>();
            siteTocki = new List<Point>();
            siteListi = new List<List<Point>>();
            Random r = new Random();
            for (int i = 0; i < 5; i+=10)
            {
                tocki.Add(new Point(350 + r.Next(-i, i), 250 + r.Next(-i, i)));
            }
            tocki.Add(new Point(351, 249));    
            tocki.Add(new Point(355, 245));
            tocki.Add(new Point(349, 249));
            tocki.Add(new Point(349, 251));
            tocki.Add(new Point(351, 251));
            
        }

        void timer1_Tick_Pobeda(object sender, EventArgs e)
        {

            List<Konfeta> zaBrisenje = new List<Konfeta>();
            foreach (Konfeta k in konfeti)
            {
                k.Y+=7;
                if (k.Y - k.r >= 500)
                {
                    zaBrisenje.Add(k);
                }
            }
            foreach(Konfeta k in zaBrisenje){
                konfeti.Remove(k);
            }

            Random r = new Random();
            if (c % 3 == 0)
            {
                for (int i = 0; i < 10; i++)
                {
                    konfeti.Add(new Konfeta(r.Next(770), 0, r.Next(5,15)));
                }
            }
            c++;
           Invalidate();
        }

        void timer1_Tick_Gubitnik(object sender, EventArgs e)
        {
            if (c >= 10)
            {
                Invalidate();
                return;
            }
            
            Random r = new Random();
            List<Point> tockitmp = new List<Point>();
            foreach(Point p in tocki){
                siteTocki.Add(p);
                List<Point> tmp = new List<Point>();

                int n = r.Next(0, 3);

                for (int i = 0; i < n; i++)
                {
                    
                    int tmpx;
                    int tmpy;
                    if (p.X < 400 && p.Y < 300)
                    {
                        tmpx = r.Next((int)(dolzina * 0.1), (int)dolzina);
                        tmpy = r.Next((int)(dolzina * 0.1), (int)dolzina);
                        tmp.Add(new Point(p.X - tmpx, p.Y - tmpy));
                        
                    }
                    if (p.X < 400 && p.Y > 200)
                    {
                        tmpx = r.Next((int)(dolzina * 0.1), (int)dolzina);
                        tmpy = r.Next((int)(dolzina * 0.1), (int)dolzina);
                        tmp.Add(new Point(p.X - tmpx, p.Y + tmpy));  
                    }
                    if (p.X > 300 && p.Y < 300)
                    {
                        tmpx = r.Next((int)(dolzina * 0.1), (int)dolzina);
                        tmpy = r.Next((int)(dolzina * 0.1), (int)dolzina);
                        tmp.Add(new Point(p.X + tmpx, p.Y - tmpy));  
                    }
                    if (p.X > 300 && p.Y > 200)
                    {
                        tmpx = r.Next((int)(dolzina * 0.1), (int)dolzina);
                        tmpy = r.Next((int)(dolzina * 0.1), (int)dolzina);
                        tmp.Add(new Point(p.X + tmpx, p.Y + tmpy));  
                    }
                   
                                  
                }
                noviTocki.Add(tmp);
                siteListi.Add(tmp);
                
            }
            tocki = new List<Point>();
            for (int i = 0; i < noviTocki.Count; i++)
            {
                for (int j = 0; j < noviTocki[i].Count; j++ )
                {
                    if (noviTocki[i][j].X >= 0 && noviTocki[i][j].X < 770 && noviTocki[i][j].Y >= 0 && noviTocki[i][j].Y < 500)
                    {
                        tocki.Add(noviTocki[i][j]);

                    }
                }
            }
            noviTocki = new List<List<Point>>();
            c++;
            dolzina *= 0.95F;
            Invalidate();
        }
   
       

        private void Form2_Paint(object sender, PaintEventArgs e)
        {
            string tekst;
            if (pobeda)
            {
                tekst = "ПОБЕДА!!!";
            }
            else
            {
                tekst = "ИЗГУБИ!!!";
            }
            e.Graphics.DrawImage(slika, 0, 0, 770, 500);
            Font drawFont = new Font("Microrosf Sans Serif", 80, FontStyle.Bold);
            SolidBrush drawBrush = new SolidBrush(System.Drawing.Color.Firebrick);
            float xx = 50.0F;
            float yy = 165.0F;
            StringFormat drawFormat = new StringFormat();
            e.Graphics.DrawString(tekst, drawFont, drawBrush, xx, yy, drawFormat);
            drawFont.Dispose();
            drawBrush.Dispose();
            if (pobeda)
            {
                

                Random r = new Random();
                foreach (Konfeta k in konfeti)
                {

                    Brush b = new SolidBrush(Color.FromArgb(255, r.Next(255), r.Next(255), r.Next(255)));
                    e.Graphics.FillEllipse(b, k.X, k.Y, k.r, k.r);
                    b.Dispose();
                }
                
            }
            else 
            {


                for (int i = 0; i < siteTocki.Count; i++)
                {

                    if (i >= siteListi.Count) return;

                    List<Point> tmp = siteListi[i];
                    Pen moliv = new Pen(Color.Black);
                    for (int j = 0; j < tmp.Count; j++)
                    {
                        e.Graphics.DrawLine(moliv, siteTocki[i], tmp[j]);
                    }
                    moliv.Dispose();
                }
                
               
            }

            
            
        }

        private void btnIzlezi_MouseHover(object sender, EventArgs e)
        {
            btnIzlezi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        private void btnIzlezi_MouseLeave(object sender, EventArgs e)
        {
            btnIzlezi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        private void btnDoma_MouseHover(object sender, EventArgs e)
        {
            btnDoma.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        private void btnDoma_MouseLeave(object sender, EventArgs e)
        {
            btnDoma.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        private void btnNovaIgra_MouseHover(object sender, EventArgs e)
        {
            btnNovaIgra.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        private void btnNovaIgra_MouseLeave(object sender, EventArgs e)
        {
            btnNovaIgra.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }
        private void Form2_Load(object sender, EventArgs e)
        {

        }
        private void btnIzlezi_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnDoma_Click(object sender, EventArgs e)
        {
            this.Hide();
            forma.Show();
        }

        private void btnNovaIgra_Click(object sender, EventArgs e)
        {
            this.Hide();

            PostaviBrodovi n;
            if (pobeda)
            {
                n = new PostaviBrodovi(ime, nivo, forma, rez_igrach + 1, rez_bot);
            }
            else
            {
                n = new PostaviBrodovi(ime, nivo, forma, rez_igrach, rez_bot+1);
            }
            n.Show();
           
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
