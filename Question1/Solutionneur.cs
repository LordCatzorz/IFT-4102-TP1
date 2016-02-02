using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace Question1
{
    class Solutionneur
    {
        public Solutionneur()
        {

        }

        static public Questionnaire Run()
        {
            Questionnaire questionnaire = new Questionnaire();
            OrderedBag<Grille> OPEN = new OrderedBag<Grille>();
            OrderedBag<Grille> CLOSE = new OrderedBag<Grille>();
            Grille S = new Grille();
            OPEN.Add(S);
            while (OPEN.Count != 0)
            {
                Grille n = OPEN.RemoveFirst();
                CLOSE.Add(n);
                questionnaire.solutionsExplorer.Add(n.getStringEtat());
                if (n.getDistanceSolution() == 0)
                {
                    questionnaire.solutionMot = n.getSolutionMot();
                    questionnaire.solutionVisuelle = n.getSolutionVisuelle();
                    for (int i = 0; i < questionnaire.solutionVisuelle.Count; i++)
                    {

                        Console.Write("\n---Étape" + i + "----\n" +  questionnaire.solutionVisuelle[i] + "----------");
                    }
                    return questionnaire;
                }
                foreach (Grille nPrime in n.getListSuccessor())
                {
                    if (Contient(OPEN, nPrime) != -1)
                    {
                        int position = Contient(OPEN, nPrime);
                        if (nPrime.getTotalDistance() < OPEN[position].getTotalDistance())
                        {
                            OPEN.Remove(OPEN[position]);
                            OPEN.Add(nPrime);
                        }
                    }
                    else if (Contient(CLOSE, nPrime) != -1)
                    {
                        int position = Contient(CLOSE, nPrime);
                        if (nPrime.getTotalDistance() < CLOSE[position].getTotalDistance())
                        {
                            CLOSE.Remove(CLOSE[position]);
                            OPEN.Add(nPrime);
                        }
                    }
                    else // Ni dans Close , ni dans OPEN
                    {
                        OPEN.Add(nPrime);
                    }
                }
            }
            questionnaire.solutionMot = "Aucun chemin possible";
            return questionnaire;
        }
        

        static private int Contient(OrderedBag<Grille> set, Grille g)
        {

            for (int i = 0; i < set.Count; i++)
            {
                if (set[i].getStringEtat() == g.getStringEtat())
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
