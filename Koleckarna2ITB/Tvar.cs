using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koleckarna2ITB
{
    public abstract class Tvar
    {
        public Color barva;
        public bool vyplnene;

        protected bool active = false;
        protected static Pen activeOutline = new Pen(Color.Yellow, 8);
        protected static Pen stredPen = new Pen(Color.Black, 4);

        public abstract void Vykresli(Graphics g, bool stredy);

        public abstract bool IsMouseOver(Point mouse, out float distance);

        internal void Activate() {
            active = true;
        }

        internal void Deactivate() {
            active = false;
        }

        protected float GetDistance(Point a, Point b) {
            return (float) Math.Sqrt(Math.Pow(a.X - b.X, 2) + Math.Pow(a.Y - b.Y, 2));
        }
    }
}
