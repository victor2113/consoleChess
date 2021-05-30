using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;


namespace NEXTCHESS
{
    public class Chess
    {
         public string fen { get; private set; }
         public Chess(string fen = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1")
        {
            this.fen = fen;
        }

       public Chess Move(string move){//Qe2e6
            Chess nextChess = new Chess(fen);
            return nextChess;
       }

        public char GetFigureAt(int x , int y){
            return '.';
        }



    }
}