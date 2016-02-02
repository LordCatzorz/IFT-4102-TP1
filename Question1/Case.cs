using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question1
{
    class Case
    {
        public int x;
        public int y;
        public bool estMur;
        public Noeud noeud;
        public Case(int _x, int _y, bool _estMur = false)
        {
            x = _x;
            y = _y;
            estMur = _estMur;
        }
        
        public int getDistance()
        {
            return Math.Abs(this.noeud.caseDestination.x - this.x) + Math.Abs(this.noeud.caseDestination.y - this.y);
        }

        
    }
}
