using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;



namespace NEXTCHESS
{
    public class Board
    {
        public string fen { get; private set; }

        Figure[,] figures;
        public Color curentColor { get; private set; }
        public int moveNumber { get; private set; }

        public Board(string fen){
            this.fen = fen;
            figures = new Figure[8,8];
            Build();
        }


         void Build()
        {
            setFigureAt(new Cell("a1"),Figure.whiteKing);
            setFigureAt(new Cell("h8"),Figure.blackKing);
            curentColor = Color.white;
        }

        public Figure GetCoords(Cell cell)
        {
            if (cell.checkCell()) return figures[cell.x, cell.y];
            return Figure.none;
        }
        void setFigureAt(Cell cell,Figure figure){
            if (cell.checkCell()) figures[cell.x, cell.y] = figure;
        }


        public Board Move (FigureMoving fm){
            Board next  = new Board(fen);
            next.setFigureAt(fm.from,Figure.none);
            next.setFigureAt(fm.to, fm.pawnPromotion == Figure.none ? fm.figure : fm.pawnPromotion);
            if (curentColor == Color.black)
            {
                next.moveNumber++;
            }
            next.curentColor = curentColor.FlipColor();
            return next;
            
        }
    }
}