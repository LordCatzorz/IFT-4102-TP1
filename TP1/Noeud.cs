using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1
{
    class Noeud
    {
        public string nom;
        public Case caseDestination;

        public Noeud(string _nom, Case _caseDestination)
        {
            nom = _nom;
            caseDestination = _caseDestination;
        }
    }
}
