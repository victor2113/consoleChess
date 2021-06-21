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
            Chess chess = new Chess("rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1");
            while (true)
            {
                Console.WriteLine(chess.fen);
                Console.WriteLine(ToAski(chess));

                foreach(string moves in chess.GetAll()){
                    Console.WriteLine(moves + "\t");
                }
                Console.WriteLine("");
                Console.WriteLine("> ");
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
