using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFT4102.TP1.Question2
{
    public class Cell<T1>
    {
        public int X { get; set; }
        public int Y { get; set; }
        public T1 Value { get; set; }
        public Cell(int _x, int _y, T1 _value)
        {
            X = _x;
            Y = _y;
            Value = _value;
        }
        public Cell(Cell<T1> _cell)
        {
            X = _cell.X;
            Y = _cell.Y;
            Value = _cell.Value;
        }

        public override string ToString()
        {
            return String.Format("<{0},{1}>->{2}", X, Y, Value);
        }
    }
}
