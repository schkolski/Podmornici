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
         
        public bool daliEValidna(){

           
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    int c = 0;
                    foreach(Brod b in Brodovi){
                        if(b.tukaSum(i,j)){
                            c++;
                        }

                    }

                    if(c >= 2){
                        return false;
                    }
                }
            }
            return true;
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
                   // Console.WriteLine(mapa[i][j].ToString());
                    if (mapa[i][j] == Sostojba.Promasheno)
                    {
                        if (mapa[i][j] == Sostojba.Promasheno)
                        {
                            g.FillRectangle(new SolidBrush(Color.FromArgb(80, 0, 0, 0)), j * 30 + 50 + 1, i * 30 + 100 + 1, 29, 29);
                        }
                    }
                    else if (mapa[i][j] == Sostojba.PogodenBrod)
                    {
                        
                        foreach (Brod b in Brodovi)
                        {
                            if (b.tukaSum(i, j) && !b.potopen())
                            {
                                g.FillEllipse(new SolidBrush(Color.FromArgb(180, 144, 0, 0)), j * 30 + 50 + 2, i * 30 + 100 + 2, 26, 26);
                                g.FillEllipse(new SolidBrush(Color.FromArgb(90, 204, 66, 0)), j * 30 + 50 + 2 + 4, i * 30 + 100 + 2 + 4, 18, 18);
                                g.FillEllipse(new SolidBrush(Color.FromArgb(60, 255, 204, 33)), j * 30 + 50 + 2 + 8, i * 30 + 100 + 2 + 8, 10, 10);
                               
                                break;
                            }
                        }
                    }
                }
            }
        }
    }
}
