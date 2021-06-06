using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.Collections;



namespace NEXTCHESS
{
    public class Board
    {
        public string fen { get; private set; }

        Figure[,] figures;
        public Color curentColor { get; private set; }
        public int moveNumber { get; private set; }

        public Board(string fen)
        {
            this.fen = fen;
            figures = new Figure[8, 8];
            Build();
        }


        void Build()
        {
            //rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1
            //0                                           1 2    3 4 5
            string[] fenParts = fen.Split();
            if (fenParts.Length != 6) return;
            BuildFigures(fenParts[0]);
            curentColor = (fenParts[1] == "b") ? Color.black : Color.white;
            moveNumber = int.Parse(fenParts[5]);
        }

        void BuildFigures(string str)//rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1
        {                             //  0                                         1 2    3 4 5 
            for (int i = 8; i >= 2; i--)
                str = str.Replace(i.ToString(), (i - 1).ToString() + "1");
            str = str.Replace("1", ".");
            string[] lines = str.Split('/');
            for (int y = 7; y >= 0; y--)
            {
                for (int x = 0; x < 8; x++)
                {
                    figures[x, y] = lines[7 - y][x] == '.' ? Figure.none : (Figure)lines[7 - y][x];
                }
            }

        }

        public Figure GetCoords(Cell cell)
        {
            if (cell.checkCell()) return figures[cell.x, cell.y];
            return Figure.none;
        }
        void setFigureAt(Cell cell, Figure figure)
        {
            if (cell.checkCell()) figures[cell.x, cell.y] = figure;
        }
        void nextFen()
        {

            fen = FenFegure() + " " + (curentColor == Color.white ? "w" : "b") + " - - 0 " + moveNumber.ToString();
        }
        string FenFegure()
        {
            StringBuilder sb = new StringBuilder();
            for (int y = 7; y >= 0; y--)
            {
                for (int x = 0; x < 8; x++)
                {
                    sb.Append(figures[x, y] == Figure.none ? '1' : (char)figures[x, y]);
                }
                if (y > 0) sb.Append('/');
            }
            string eight = "11111111";
            for (int i = 8; i >=2; i--)
            {
                sb.Replace(eight.Substring(0,i),i.ToString());
            }
            return sb.ToString(); 
        }


        public Board Move(FigureMoving fm)
        {
            Board next = new Board(fen);
            next.setFigureAt(fm.from, Figure.none);
            next.setFigureAt(fm.to, fm.pawnPromotion == Figure.none ? fm.figure : fm.pawnPromotion);
            if (curentColor == Color.black)
            {
                next.moveNumber++;
            }
            next.curentColor = curentColor.FlipColor();
            next.nextFen();
            return next;

        }



        public IEnumerable<FigureOnCell> YieldFigures()
        {
            foreach (Cell cell in Cell.YieldCells())
            {
                if(GetCoords(cell).GetColor() == curentColor)
                    yield return new FigureOnCell(GetCoords(cell),cell);
            }
        }
    }
}