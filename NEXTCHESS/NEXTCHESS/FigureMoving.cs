using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.Collections;
namespace NEXTCHESS
{
    public class FigureMoving
    {
        public Figure figure { get; private set; }
        public Cell from { get; private set; }
        public Cell to { get; private set; }
        public Figure pawnPromotion { get; private set; }

        public FigureMoving(FigureOnCell fc, Cell to, Figure pawnPromotion = Figure.none)
        {
            this.figure = fc.figure;
            this.from = fc.cell;
            this.to = to;
            this.pawnPromotion = pawnPromotion;
        }


        public FigureMoving(string move)//ke1e2
                                        // 01234
        {
            this.figure = (Figure)move[0];

            this.from = new Cell(move.Substring(1, 2));

            this.to = new Cell(move.Substring(3, 2));

            this.pawnPromotion = (move.Length == 6) ? (Figure)move[5] : Figure.none;
        }
        public int Dx { get { return to.x - from.x; } }
        public int Dy { get { return to.y - from.y; } }

        public int AbsDx { get { return Math.Abs(Dx); } }
        public int AbsDy { get { return Math.Abs(Dy); } }

        public int SignDx { get { return Math.Sign(Dx); } }
        public int SignDy { get { return Math.Sign(Dy); } }


        public override string ToString()
        {
            string text =  (char)figure + from.name + to.name; 
            if (pawnPromotion != Figure.none){
                text+=(char)pawnPromotion;
            }
            return text;
        }   

    }
}