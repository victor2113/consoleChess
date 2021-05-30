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
        Board board;
        public Chess(string fen = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1")
        {
            this.fen = fen;
            board = new Board(fen);
        }
        Chess(Board board){
            this.board = board;
        }

        public Chess Move(string move)
        {//Qe2e6
            FigureMoving fm = new FigureMoving(move);
            Board nextBoard = board.Move(fm);
            Chess nextChess = new Chess(nextBoard);
            return nextChess;
        }

        public char GetFigureAt(int x, int y)
        {
            Cell cell = new Cell(x, y);
            Figure f = board.GetCoords(cell);
            return f == Figure.none ? '.' : (char)f;
        }
        


    }
}