using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFT4102.TP1.Question2
{
    class Program
    {
        int order = 3;
        static void Main(string[] args)
        {
            Solver s = new Solver(3, @"C:\ULAVAL\IFT-4102\TP1\Question2\sudoku\49151.txt", 200, 0.999);
            Console.WriteLine(s.Solve());

        }
    }
}
