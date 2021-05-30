using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;

namespace NEXTCHESS
{
 class Program
    {
        static void Main(string[] args)
        {
            Chess chess = new Chess();
            while (true)
            {
                Console.WriteLine(ToAski(chess));
                string move = Console.ReadLine();
                if (move == "") break;
                chess = chess.Move(move);
            }
        }


        static string ToAski(Chess chess)
        {
            string paint = "  +----------------+\n";
            for (int y = 7; y >= 0; y--)
            {
                paint += y + 1;
                paint += " | ";
                for (int x = 0; x < 8; x++)
                {
                    paint += chess.GetFigureAt(x,y) + " ";
                    
                }
                paint += "|\n";

            }
            paint += "  +----------------+\n";
            paint += "    a b c d e f g h \n";
            return paint;
        }



    }
}
