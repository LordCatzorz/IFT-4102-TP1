using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;

namespace IFT4102.TP1.Question2
{
    class Program
    {
        int order = 3;
        static void Main(string[] args)
        {
            Stopwatch start = Stopwatch.StartNew();
            FileStream fs;
            UnicodeEncoding uni = new UnicodeEncoding();
            //string stime = "";
            fs = new FileStream("./solution3.log", FileMode.Create);

            // for (int j = 1; j <= 50; j++)
            // {
            //int totalReset = 0;
            for (int i = 0; i < 50; i++)
            {
                start.Restart();
                Solver s = new Solver(3, @"C:\ULAVAL\IFT-4102\TP1\Question2\sudoku\49151.txt", 810, 0.5, 0.8);
                string solution = s.Solve();
                //totalReset += reset;
                start.Stop();
                string stime = "Temps : " + start.ElapsedMilliseconds + "ms" + Environment.NewLine + solution + Environment.NewLine;
                Console.Write(stime);// + solution );
                                     // fs.Write(uni.GetBytes(stime), 0, uni.GetByteCount(stime));
                                     // }
                                     // long total = start.ElapsedMilliseconds;
                                     // string timeTotal = total + "ms";
                                     // string timeMoyen = (total / 20.0) + "ms";
                                     // //stime = "With comparaison : " + (1 - 0.02 * j) + " took a total of " + timeTotal + " Moyen : " + timeMoyen + " and moyenReset " + totalReset / 20 + Environment.NewLine;
                                     // Console.Write(stime);
                                     //fs.Write(uni.GetBytes(stime), 0, uni.GetByteCount(stime));
            }

        }
    }
}

