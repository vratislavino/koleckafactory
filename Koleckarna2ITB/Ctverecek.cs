using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Koleckarna2ITB
{
    internal class Ctverecek : Tvar
    {
        public Point stred;
        public int velikost;

        public override bool IsMouseOver(Point mouse, out float distance) {

            distance = GetDistance(mouse, stred);

            return mouse.X > stred.X - velikost / 2 && mouse.X < stred.X + velikost / 2
                && mouse.Y > stred.Y - velikost / 2 && mouse.Y < stred.Y + velikost / 2;


        }

        public override void Vykresli(Graphics g, bool stredy) {
            if (vyplnene) {
                g.FillRectangle(new SolidBrush(barva),
                stred.X - velikost/2, stred.Y - velikost/2, velikost, velikost);
            } else {
                g.DrawRectangle(new Pen(barva, 8),
                stred.X - velikost / 2, stred.Y - velikost / 2, velikost, velikost);
            }

            if (active) {
                g.DrawRectangle(activeOutline,
                stred.X - velikost / 2, stred.Y - velikost / 2, velikost, velikost);
            }

            if (stredy) {
                g.DrawLine(stredPen, stred.X - 15, stred.Y, stred.X + 15, stred.Y);
                g.DrawLine(stredPen, stred.X, stred.Y - 15, stred.X, stred.Y + 15);
            }
        }
    }
}
