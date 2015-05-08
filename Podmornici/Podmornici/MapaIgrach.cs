using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Podmornici
{
    public class MapaIgrach : Mapa
    {
        public MapaIgrach() : base()
        {
        }
        public override void crtaj(Graphics g)
        {
            foreach (Brod b in Brodovi)
            {
                b.crtaj(g, true);
            }
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (mapa[i][j] == Sostojba.Promasheno)
                    {
                        g.FillEllipse(new SolidBrush(Color.DeepSkyBlue), j * 30 + 25 + 2, i * 30 + 50 + 2, 26, 26);
                    }
                    else if (mapa[i][j] == Sostojba.PogodenBrod)
                    {
                        foreach (Brod b in Brodovi)
                        {
                            if (b.tukaSum(i, j) && !b.potopen())
                            {
                                g.FillEllipse(new SolidBrush(Color.Red), j * 30 + 25 + 2, i * 30 + 50 + 2, 26, 26);
                                break;
                            }
                        }
                    }
                }
            }
        }
    }
}
