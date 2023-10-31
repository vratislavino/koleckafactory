using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koleckarna2ITB
{
    public class CtverecekFactory : Factory
    {
        public override Tvar GetTvar(Point stred) {
            return new Ctverecek() {
                barva = this.barva,
                velikost = this.velikost,
                stred = stred,
                vyplnene = this.vyplnene
            };
        }
    }
}
