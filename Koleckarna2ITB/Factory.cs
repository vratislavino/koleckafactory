using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koleckarna2ITB
{
    public abstract class Factory
    {
        public int velikost;    
        public Color barva;
        public bool vyplnene;

        public abstract Tvar GetTvar(Point stred);
    }
}
