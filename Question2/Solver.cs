using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace IFT4102.TP1.Question2
{
    class Solver
    {
        Random random;

        Grid G;
        double T;
        double Delta;
        int Order;
        double Comparaison;


        public Solver(int _order, string _path, double _t, double _delta, double _comparaison)
        {
            Order = _order;
            random = new Random((int)DateTime.Now.Ticks);
            T = _t;
            Delta = _delta;
            G = new Grid(_order, _path);
            Comparaison = _comparaison;
        }

        private void PlaceRandomNumberInGrid(ref Grid _grid)
        {
            for (int j = 0; j < _grid.PuzzleOrder; j++)
            {
                for (int i = 0; i < _grid.PuzzleOrder; i++)
                {
                    List<int> availableValue = new List<int>();
                    List<int> placedValue = _grid.getPlacedValueInSquare(i, j);
                    for (int k = 1; k <= _grid.SquareOrder; k++)
                    {
                        if (!placedValue.Contains(k))
                        {
                            availableValue.Add(k);
                        }
                    }

                    List<Cell<int>> emptySquareInCell = _grid.getEmptyCellInSquare(i, j);
                    foreach (Cell<int> cell in emptySquareInCell)
                    {
                        int value = availableValue.ElementAt(random.Next(availableValue.Count - 1));
                        cell.Value = value;
                        availableValue.Remove(value);
                    }
                }
            }
        }

        public string Solve()
        {
            // FileStream fs;
            //fs = new FileStream("./solution.csv", FileMode.Create);
            UnicodeEncoding uni = new UnicodeEncoding();
            int nbReset = -1;
            int nbInteration = 0;
            while (true)
            {
                //Console.WriteLine("Reset : " + nbReset++);
                int stuck = 0;
                double t = T;
                Grid X = new Grid(G);
                PlaceRandomNumberInGrid(ref X);
                int cost = X.getCost();

                nbReset++;
                while (cost > 0 && stuck <= 50)
                {
                    nbInteration++;
                    //TODO: Régler un bug potenciel si 8 des 9 cas d'un square sont fixés.
                    //Get Swap Position;
                    int i, j, k, l;
                    do
                    {
                        i = random.Next(0, X.SquareOrder);
                        j = random.Next(0, X.SquareOrder);
                    } while (X.FixedValue.Any(cell => cell.X == i && cell.Y == j) || (X.getCostColumn(i) + X.getCostRow(j) == 0));

                    int minX = Square.getMinX(Square.getSquareX(i, X.PuzzleOrder), X.PuzzleOrder);
                    int maxX = Square.getMaxX(Square.getSquareX(i, X.PuzzleOrder), X.PuzzleOrder);

                    int minY = Square.getMinY(Square.getSquareX(j, X.PuzzleOrder), X.PuzzleOrder);
                    int maxY = Square.getMaxY(Square.getSquareX(j, X.PuzzleOrder), X.PuzzleOrder);
                    do
                    {
                        k = random.Next(minX, maxX + 1);
                        l = random.Next(minY, maxY + 1);
                    } while ((k == i && j == l) || X.FixedValue.Any(cell => cell.X == k && cell.Y == l) || (X.getCostColumn(k) + X.getCostRow(l) == 0));

                    //Swap
                    Grid XPrime = new Grid(X);
                    Cell<int> cell1 = XPrime.PlayGrid.Find(cell => cell.X == i && cell.Y == j);
                    Cell<int> cell2 = XPrime.PlayGrid.Find(cell => cell.X == k && cell.Y == l);
                    int tempValue = cell1.Value;
                    cell1.Value = cell2.Value;
                    cell2.Value = tempValue;

                    //Console.WriteLine(X.ToString());
                    //Console.WriteLine(XPrime.ToString());
                    //Console.WriteLine(String.Format("Swap:<{0},{1}> and <{2},{3}>", i, j, k, l));
                    int costB = XPrime.getCost();
                    //string s = (++nbInteration).ToString() + ',' + costB.ToString() + System.Environment.NewLine;
                    //fs.Write(uni.GetBytes(s), 0, uni.GetByteCount(s));
                    double percentage = Math.Exp((-((double)(costB - cost))) / t);
                    //if (t < 0.01)
                    //{
                    //    percentage = 0;
                    //}
                    //if (costB > cost)
                    //{
                    //    Console.WriteLine(percentage);
                    //}
                    if (costB == 0)
                    {
                        return "Total iteration " + nbInteration.ToString() + Environment.NewLine + "Total reset " + nbReset + Environment.NewLine + XPrime.ToString(); // Solution;
                    }
                    else if (costB < cost || percentage > Comparaison)
                    {
                        t = t / (1 + (Math.Log(1 + Delta) / 811) * t);
                        cost = costB;
                        X = XPrime;
                        stuck = 0;
                    }
                    else
                    {
                        stuck++;
                    }
                    //Console.WriteLine(String.Format("CostB:{0} -- Cost:{4} -- Stuck:{2} -- Math.Exp:{1} -- T: {3} ", costB, percentage ,stuck, t, cost));
                    //Console.WriteLine(XPrime.ToString());
                }
            }
        }
    }
}
