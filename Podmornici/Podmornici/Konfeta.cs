using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Podmornici
{
    public class Konfeta
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int r { get; set; }

        public Konfeta(int x, int y, int r)
        {
            this.X = x;
            this.Y = y;
            this.r = r;
        }
        public override string ToString()
        {
            return X + " " + Y + " " + r;
        }
    }
}
