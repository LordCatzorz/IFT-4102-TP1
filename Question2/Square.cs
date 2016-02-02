using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFT4102.TP1.Question2
{
    static public class Square
    {

        static public int getMinX(int _posX, int _order)
        {
            return _posX * _order;
        }

        static public int getMaxX(int _posX, int _order)
        {
            return getMinX(_posX, _order) + _order -1;
        }

        static public int getMinY(int _posY, int _order)
        {
            return _posY * _order;
        }

        static public int getMaxY(int _posY, int _order)
        {
            return getMinY(_posY, _order) + _order - 1;
        }

        static public int getSquareX(int _cellPosX, int _order)
        {
            return (_cellPosX) / 3;
        }

        static public int getSquareY(int _cellPosY, int _order)
        {
            return (_cellPosY) / 3;
        }

    }
}
