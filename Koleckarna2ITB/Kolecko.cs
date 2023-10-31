using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koleckarna2ITB
{
    internal class Kolecko : Tvar
    {
        public int r;
        public Point stred;
        
        public override void Vykresli(Graphics g, bool stredy) {

            if(vyplnene) {
                g.FillEllipse(new SolidBrush(barva),
                stred.X - r, stred.Y - r, 2 * r, 2 * r);
            } else {
                g.DrawEllipse(new Pen(barva, 8),
                stred.X - r, stred.Y - r, 2 * r, 2 * r);
            }

            if(active) {
                g.DrawEllipse(activeOutline,
                stred.X - r, stred.Y - r, 2 * r, 2 * r);
            }

            if(stredy) {
                g.DrawLine(stredPen, stred.X - 15, stred.Y, stred.X + 15, stred.Y);
                g.DrawLine(stredPen, stred.X, stred.Y - 15, stred.X, stred.Y + 15);
            }
        }

        public override bool IsMouseOver(Point clickLocation, out float currDist) {
            currDist = GetDistance(clickLocation, stred);
            return currDist <= r;
               
        }

    }
}
