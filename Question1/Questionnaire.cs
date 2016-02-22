using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question1
{
    class Questionnaire
    {
        public List<string> solutionsExplorer;
        public string solutionMot;
        public List<string> solutionVisuelle;
        public List<string> etatExplorer;
        public Questionnaire()
        {
            solutionsExplorer = new List<string>();
            solutionMot = "";
            solutionVisuelle = new List<string>();
            etatExplorer = new List<string>();
        }

        public string getSortie()
        {
            return String.Format(@"Question 1 :
----------
Q.Combien d'étapes avez-vous utilisé pour atteindre l'état final?
R.{0}
----------
Q.Combien d'états avez-vous exploré pour atteindre l'état final?
R. 
Si l'on considère la question comme 'Combien de noeuds avez-vous développés':
{1}
Si l'on considère la question comme 'Combien de noeuds, incluant ceux qui n'ont pas été développés':
{4}
----------
Q.Donner le 6e état depuis le début de l'exploration du A*.
R. Si l'on veut dire '6e noeud développé':
{2}
Si l'on veut dire '6e noeud, incluant ceux qui n'ont pas été développés':
{5}
----------
Q.Donner le 6e qui reste à A* avant d'atteindre le but.
R. Si l'on veut dire '6e noeud développé avant la fin':
{3}
Si l'on veut dire '6e noeud, incluant ceux qui n'ont pas été développés, de la fin'
{6}
----------", solutionVisuelle.Count, solutionsExplorer.Count, solutionsExplorer[5], solutionsExplorer[solutionsExplorer.Count - 6], etatExplorer.Count, etatExplorer[5], etatExplorer[etatExplorer.Count -6]);
        }

    }
}
