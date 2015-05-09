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
            PostaviBrodovi f = new PostaviBrodovi(tbIme.Text, rbLesno.Checked);
            f.Show();
            this.Hide();
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

    }
}
