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
    public partial class NewGame : Form
    {
        Image slika;
        public NewGame()
        {
            InitializeComponent();
            slika = Resources.naslovna_slika;
            this.Width = 740;
            this.Height = 440;
            
       }

        private void NewGame_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(slika, 0,0, 740, 440);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnNovaIgra_Click(object sender, EventArgs e)
        {
            if (tbIme.Text.Trim().Length > 0)
            {
                Game.Nivo nivo = Game.Nivo.tesko;
                if (rbLesno.Checked)
                {
                    nivo = Game.Nivo.lesno;
                }
                PostaviBrodovi f = new PostaviBrodovi(tbIme.Text, nivo, this, 0, 0);
                f.Show();
                this.Hide();
            }
            else
            {
                errorProvider1.SetError(tbIme, "Внесете име");
            }
        }

        private void tbIme_Validating(object sender, CancelEventArgs e)
        {
            if (tbIme.Text.Trim().Length == 0)
            {
                errorProvider1.SetError(tbIme, "Внесете име");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(tbIme, null);
                e.Cancel = false;
            }
        }

        private void btnNovaIgra_MouseHover(object sender, EventArgs e)
        {
            btnNovaIgra.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

        }

        private void btnNovaIgra_MouseLeave(object sender, EventArgs e)
        {
            btnNovaIgra.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        private void btnInstrukcii_MouseHover(object sender, EventArgs e)
        {
            btnInstrukcii.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        private void btnInstrukcii_MouseLeave(object sender, EventArgs e)
        {
            btnInstrukcii.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        private void btnInstrukcii_Click(object sender, EventArgs e)
        {

        }

    }
}
