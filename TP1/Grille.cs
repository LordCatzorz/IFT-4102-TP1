using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1
{
    class Grille : IComparable<Grille>
    {
        int troteuseX;
        int troteuseY;
        Case[,] grille = new Case[5, 5];
        private Grille precedent = null;

        internal Case Troteuse
        {
            get { return grille[TroteuseX, TroteuseY]; }
        }
        internal Grille Precedent
        {
            get
            {
                return precedent;
            }

            private set
            {
                precedent = value;
            }
        }

        public int TroteuseX
        {
            get
            {
                return troteuseX;
            }

            set
            {
                troteuseX = value;
            }
        }

        public int TroteuseY
        {
            get
            {
                return troteuseY;
            }

            set
            {
                troteuseY = value;
            }
        }

        public Grille()
        {
            this.Precedent = null;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    grille[i, j] = new Case(i, j);
                }
            }
            
            grille[0, 0].noeud = new Noeud("2", grille[1, 0]);
            grille[1, 0].noeud = new Noeud("3", grille[2, 0]);
            grille[2, 0].noeud = new Noeud("7", grille[2, 1]);
            grille[3, 0].noeud = new Noeud("4", grille[3, 0]);
            grille[4, 0].noeud = new Noeud("5", grille[4, 0]);
            grille[0, 1].noeud = new Noeud("1", grille[0, 0]);
            grille[1, 1].estMur = true;
            grille[2, 1].noeud = new Noeud("11", grille[3, 2]);
            grille[3, 1].estMur = true;
            grille[4, 1].noeud = new Noeud("8", grille[4, 1]);
            grille[0, 2].noeud = new Noeud("6", grille[0, 1]);
            grille[1, 2].noeud = new Noeud("10", grille[1, 2]);
            grille[2, 2].noeud = new Noeud("", grille[2, 2]); ;
            grille[3, 2].noeud = new Noeud("12", grille[4, 2]);
            grille[4, 2].noeud = new Noeud("15", grille[4, 3]);
            grille[0, 3].noeud = new Noeud("9", grille[0, 2]);
            grille[1, 3].estMur = true;    
            grille[2, 3].noeud = new Noeud("14", grille[2, 3]);
            grille[3, 3].estMur = true;    
            grille[4, 3].noeud = new Noeud("20", grille[4, 4]);
            grille[0, 4].noeud = new Noeud("13", grille[0, 3]);
            grille[1, 4].noeud = new Noeud("16", grille[0, 4]);
            grille[2, 4].noeud = new Noeud("17", grille[1, 4]);
            grille[3, 4].noeud = new Noeud("18", grille[2, 4]);
            grille[4, 4].noeud = new Noeud("19", grille[3, 4]);

            TroteuseX = 2;
            TroteuseY = 2;
        }

        private Grille(Grille g)
        {
            this.Precedent = g;
            this.TroteuseX = g.TroteuseX;
            this.TroteuseY = g.TroteuseY;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    grille[i, j] = new Case(i, j);
                }
            }

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (!g.grille[i, j].estMur)
                    {
                        int xDestination = g.grille[i, j].noeud.caseDestination.x;
                        int yDestination = g.grille[i, j].noeud.caseDestination.y;
                        grille[i, j].noeud = new Noeud(g.grille[i, j].noeud.nom, grille[xDestination, yDestination]);
                    }
                    else
                    {
                        grille[i, j].estMur = true;
                    }
                }
            }
        }
        public int getTotalDistance()
        {
            return this.getNombrePrecedent() + this.getDistanceSolution();
        }

        public int getDistanceSolution()
        {
            int distance = 0;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (!grille[i, j].estMur && !(TroteuseX == i && TroteuseY == j))
                    {
                        distance += grille[i, j].getDistance();
                    }
                }
            }
            return distance;
        }

        public int getNombrePrecedent()
        {
            int nombrePrecedent = 0;
            if (this.Precedent == null)
            {
                return nombrePrecedent;
            }
            else
            {
                return this.Precedent.getNombrePrecedent() + 1;
            }
        }

        public string getSolution()
        {
            string solution = "";
            if (this.getNombrePrecedent() > 0)
            {
                solution += precedent.getSolution();
                if (precedent.TroteuseX < TroteuseX)
                {
                    solution += "Go Droite\n";
                }
                if (precedent.TroteuseX > TroteuseX)
                {
                    solution += "Go Gauche\n";
                }
                if (precedent.TroteuseY < TroteuseY)
                {
                    solution += "Go Bas\n";
                }
                if (precedent.TroteuseY > TroteuseY)
                {
                    solution += "Go Haut\n";
                }
            }
            return solution;
        }

        public int CompareTo(Grille other)
        {
            return this.getTotalDistance() - other.getTotalDistance();
        }

        public string getStringEtat()
        {
            string s = "";
            for (int y = 0; y < 5; y++)
            {
                for (int x = 0; x < 5; x++)
                {
                    if (!grille[x, y].estMur)
                    {
                        s += String.Format(" {0,2} ", grille[x,y].noeud.nom);
                    }
                    else
                    {
                        s += " ██ ";
                    }
                }
                s += "\n";
            }
            return s;
        }

        private Case getCaseHaut(Case _case)
        {
            if (_case.y != 0)
            {
                return grille[_case.x, _case.y - 1];
            }
            return null;
        }

        private Case getCaseBas(Case _case)
        {
            if (_case.y != 4)
            {
                return grille[_case.x, _case.y + 1];
            }
            return null;
        }
        private Case getCaseGauche(Case _case)
        {
            if (_case.x != 0)
            {
                return grille[_case.x - 1, _case.y];
            }
            return null;
        }

        private Case getCaseDroite(Case _case)
        {
            if (_case.x != 4)
            {
                return grille[_case.x + 1, _case.y];
            }
            return null;
        }

        public List<Grille> getListSuccessor()
        {
            List<Grille> listSuccessor = new List<Grille>();
            if (getCaseHaut(Troteuse) != null && !getCaseHaut(Troteuse).estMur)
            {
                Grille grilleHautSwap = new Grille(this);
                grilleHautSwap.SwapHaut();
                listSuccessor.Add(grilleHautSwap);
            }
            if (getCaseBas(Troteuse) != null && !getCaseBas(Troteuse).estMur)
            {
                Grille grilleBasSwap = new Grille(this);
                grilleBasSwap.SwapBas();
                listSuccessor.Add(grilleBasSwap);
            }
            if (getCaseGauche(Troteuse) != null && !getCaseGauche(Troteuse).estMur)
            {
                Grille grilleGaucheSwap = new Grille(this);
                grilleGaucheSwap.SwapGauche();
                listSuccessor.Add(grilleGaucheSwap);
            }
            if (getCaseDroite(Troteuse) != null && !getCaseDroite(Troteuse).estMur)
            {
                Grille grilleDroiteSwap = new Grille(this);
                grilleDroiteSwap.SwapDroite();
                listSuccessor.Add(grilleDroiteSwap);
            }
            return listSuccessor;
        }

        void SwapCase(Case other)
        {
            Noeud tempNoeud = this.Troteuse.noeud;
            this.grille[TroteuseX, TroteuseY].noeud = other.noeud;
            other.noeud = tempNoeud;
            this.TroteuseX = other.x;
            this.TroteuseY = other.y;
        }
        public void SwapHaut()
        {
            if (getCaseHaut(Troteuse) != null)
            {
                this.SwapCase(getCaseHaut(Troteuse));
            }
        }
        public void SwapBas()
        {
            if (getCaseBas(Troteuse) != null)
            {
                this.SwapCase(getCaseBas(Troteuse));
            }
        }
        public void SwapGauche()
        {
            if (getCaseGauche(Troteuse) != null)
            {
                this.SwapCase(getCaseGauche(Troteuse));
            }
        }
        public void SwapDroite()
        {
            if (getCaseDroite(Troteuse) != null)
            {
                this.SwapCase(getCaseDroite(Troteuse));
            }
        }

    }
}