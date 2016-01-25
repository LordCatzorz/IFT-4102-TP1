using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1
{
    class Questionnaire
    {
        public List<string> solutionsExplorer;
        public string solutionMot;
        public List<string> solutionVisuelle;
        public Questionnaire()
        {
            solutionsExplorer = new List<string>();
            solutionMot = "";
            solutionVisuelle = new List<string>();
        }

        public string getSortie()
        {
            return String.Format(@"Question 1 :
----------
Q.Combien d'étapes avez-vous utilisé pour atteindre l'état final?
R.{0}
----------
Q.Combien d'états avez-vous exploré pour atteindre l'état final?
R.{1}
----------
Q.Donner le 6e état depuis le début de l'exploration du A*.
R.
{2}
----------
Q.Donner le 6e qui reste à A* avant d'atteindre le but.
R.
{3}
----------", solutionVisuelle.Count, solutionsExplorer.Count, solutionsExplorer[5], solutionsExplorer[solutionsExplorer.Count - 6]);
        }

    }
}
