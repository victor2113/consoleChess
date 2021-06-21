using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.Collections;


namespace NEXTCHESS
{
    public class Chess
    {
        public string fen { get; private set; }
        Board board;
        Moves moves;


        List<FigureMoving> all;

        public Chess(string fen = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1")
        {
            this.fen = fen;
            board = new Board(fen);
            moves = new Moves(board);

        }
        Chess(Board board)
        {
            this.board = board;
            this.fen = board.fen;
            moves = new Moves(board);
        }

        public Chess Move(string move)
        {//Qe2e6

            FigureMoving fm = new FigureMoving(move);
            if (!moves.CanMove(fm)) return this;
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



        public void FindAll()
        {
            all = new List<FigureMoving>();
            foreach (FigureOnCell fc in board.YieldFigures())
                foreach (Cell to in Cell.YieldCells())
                {
                    FigureMoving fm = new FigureMoving(fc, to);
                    if (moves.CanMove(fm))
                        if (!board.CheckAfter(fm))
                            all.Add(fm);
                }
        }


        public List<string> GetAll()
        {
            FindAll();
            List<string> list = new List<string>();
            foreach (FigureMoving fm in all)
            {
                list.Add(fm.ToString());
            }
            return list;
        }

    }
}