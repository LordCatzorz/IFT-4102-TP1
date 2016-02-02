using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace IFT4102.TP1.Question2
{
    class Grid
    {
        int puzzleOrder;
        int squareOrder;
        List<Cell<int>> fixedValue;
        List<Cell<int>> playGrid;

        public List<Cell<int>> PlayGrid
        {
            get
            {
                return playGrid;
            }

            set
            {
                playGrid = value;
            }
        }

        public List<Cell<int>> FixedValue
        {
            get
            {
                return fixedValue;
            }

            set
            {
                fixedValue = value;
            }
        }

        public int PuzzleOrder
        {
            get
            {
                return puzzleOrder;
            }

            set
            {
                puzzleOrder = value;
            }
        }

        public int SquareOrder
        {
            get
            {
                return squareOrder;
            }

            set
            {
                squareOrder = value;
            }
        }

        public Grid(int _puzzleOrder, string _file)
        {
            fixedValue = new List<Cell<int>>();
            PuzzleOrder = _puzzleOrder;
            SquareOrder = PuzzleOrder * PuzzleOrder;
            PlayGrid = new List<Cell<int>>();
            string[] rows = File.ReadAllLines(_file);
            for (int row = 0; row < SquareOrder; row++)
            {
                for (int column = 0; column < SquareOrder; column++)
                {
                    int separationPosition = rows[row].IndexOf('|');
                    string substring = "";
                    if (separationPosition != -1)
                    {
                        substring = rows[row].Substring(0, separationPosition).Trim();
                    }
                    else
                    {
                        substring = rows[row].Trim();
                    }
                    if (String.IsNullOrWhiteSpace(substring))
                    {
                        substring = int.MinValue.ToString();
                    }
                    int value = Int32.Parse(substring);
                    if (value != Int32.MinValue)
                    {
                        fixedValue.Add(new Cell<int>(column, row, value));
                    }
                    Cell<int> cell = new Cell<int>(column, row, value);
                    PlayGrid.Add(cell);
                    rows[row] = rows[row].Remove(0, separationPosition + 1);
                }
            }
        }

        public Grid(Grid _g)
        {
            this.PuzzleOrder = _g.PuzzleOrder;
            this.SquareOrder = _g.SquareOrder;
            playGrid = new List<Cell<int>>();
            fixedValue = new List<Cell<int>>();
            foreach (Cell<int> cell in _g.FixedValue)
            {
                this.fixedValue.Add(new Cell<int>(cell));
            }

            foreach (Cell<int> cell in _g.playGrid)
            {
                PlayGrid.Add(new Cell<int>(cell));
            }
        }
        override public string ToString()
        {
            string s = "";
            int numberOfDigit = (int)Math.Floor(Math.Log10(SquareOrder) + 1);
            for (int row = 0; row < SquareOrder; row++)
            {
                for (int column = 0; column < SquareOrder; column++)
                {
                    int number = PlayGrid.Find(cell => cell.X == column && cell.Y == row).Value;
                    if (number != Int32.MinValue)
                    {
                        s = s + padCentre(number.ToString(), numberOfDigit);
                    }
                    else
                    {
                        s = s + padCentre("", numberOfDigit);
                    }
                    s = s + "|";
                }
                s = s.Remove(s.Length - 1);
                s = s + " -> " + getCostRow(row);
                s = s + System.Environment.NewLine;
            }
            for (int column = 0; column < SquareOrder; column++)
            {
                s = s + padCentre("v", numberOfDigit) + " ";
            }
            s = s + System.Environment.NewLine;
            for (int column = 0; column < SquareOrder; column++)
            {
                s = s + padCentre(getCostColumn(column).ToString(), numberOfDigit) + "|";
            }
            s = s.Remove(s.Length - 1);
            s = s + " -> " + getCost() + System.Environment.NewLine;
            return s;
        }

        private string padCentre(string _string, int _lenght)
        {
            return String.Format("{0,-" + _lenght.ToString() + "}", String.Format("{0," + ((_lenght + _string.Length) / 2).ToString() + "}", _string));
        }

        public int getCost()
        {
            int cost = 0;
            for (int i = 0; i < SquareOrder; i++)
            {
                cost += getCostColumn(i) + getCostRow(i);
            }
            return cost;
        }

        public int getCostRow(int _row)
        {
            IEnumerable<Cell<int>> rowI = playGrid.FindAll(cell => cell.Y == _row);
            return rowI.GroupBy(cell => cell.Value).Where(g => g.Count() > 1).Count();
        }

        public int getCostColumn(int _column)
        {
            IEnumerable<Cell<int>> columnI = playGrid.FindAll(cell => cell.X == _column);
            return columnI.GroupBy(cell => cell.Value).Where(g => g.Count() > 1).Count();
        }

        public List<int> getPlacedValueInSquare(int _x, int _y)
        {
            int minX = Square.getMinX(_x, PuzzleOrder);
            int maxX = Square.getMaxX(_x, PuzzleOrder);
            int minY = Square.getMinX(_y, PuzzleOrder);
            int maxY = Square.getMaxX(_y, PuzzleOrder);
            var cellsOfSquare = PlayGrid.FindAll(cell => cell.X >= minX &&
                                                               cell.X <= maxX &&
                                                               cell.Y >= minY &&
                                                               cell.Y <= maxY &&
                                                               cell.Value != Int32.MinValue);
            return cellsOfSquare.Select(cell => cell.Value).ToList();
        }

        public List<Cell<int>> getEmptyCellInSquare(int _x, int _y)
        {
            int minX = Square.getMinX(_x, PuzzleOrder);
            int maxX = Square.getMaxX(_x, PuzzleOrder);
            int minY = Square.getMinX(_y, PuzzleOrder);
            int maxY = Square.getMaxX(_y, PuzzleOrder);
            return PlayGrid.FindAll(cell => cell.X >= minX &&
                                                  cell.X <= maxX &&
                                                  cell.Y >= minY &&
                                                  cell.Y <= maxY &&
                                                  cell.Value == Int32.MinValue);
        }
    }

}
