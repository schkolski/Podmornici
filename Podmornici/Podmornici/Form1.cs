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
        public Form1()
        {
            InitializeComponent();
            Mapa m = new Mapa();

            m.napolniSlucajno();

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Console.Write(string.Format("{0}\t", m.mapa[i][j]));
                }
                Console.WriteLine();
            }

            foreach (Brod b in m.Brodovi)
            {
                Console.WriteLine(b);
            }
        }
    }
}
