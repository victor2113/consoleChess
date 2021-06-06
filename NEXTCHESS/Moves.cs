using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.Collections;

namespace NEXTCHESS
{
    public class Moves
    {
        FigureMoving fm;
        Board board;

        public Moves(Board board)
        {
            this.board = board;
        }
        public bool CanMove(FigureMoving fm)
        {
            this.fm = fm;
            return
               CanMoveFrom() &&
               CanMoveTo() &&
               CanFigureMove();
        }
        bool CanMoveFrom()
        {
            return fm.from.checkCell() && fm.figure.GetColor() == board.curentColor;
        }
        bool CanMoveTo()
        {
            return fm.to.checkCell() &&
                   board.GetCoords(fm.to).GetColor() != board.curentColor && fm.from != fm.to;
        }


        public bool CanFigureMove()
        {
            switch (fm.figure)
            {
                case Figure.whiteKing:
                case Figure.blackKing:
                    return CanKingMove();

                case Figure.whiteQueen:
                case Figure.blackQueen:
                    return canStraightMove();

                case Figure.whiteRook:
                case Figure.blackRook:
                    return (fm.SignDx == 0 || fm.SignDy == 0) && canStraightMove();

                case Figure.whiteBishop:
                case Figure.blackBishop:
                    return (fm.SignDx != 0 && fm.SignDy != 0) && canStraightMove();

                case Figure.whiteKnight:
                case Figure.blackKnight:
                    return CanKnightMove();

                case Figure.whitePawn:
                case Figure.blackPawn:
                    return CanPawnMove();



                default: return false;
            }
        }
        private bool CanKnightMove()
        {
            if (fm.AbsDx == 1 && fm.AbsDy == 2) { return true; }
            if (fm.AbsDx == 2 && fm.AbsDy == 1) { return true; }
            return false;
        }
        private bool CanKingMove()
        {
            if (fm.AbsDx <= 1 && fm.AbsDy <= 1)
            {
                return true;
            }
            return false;
        }
        private bool canStraightMove()
        {
            Cell at = new Cell(fm.from.x, fm.from.y);
            do
            {
                at = new Cell(at.x + fm.SignDx, at.y + fm.SignDy);
                if (at == fm.to) return true;
            } while (at.checkCell() && board.GetCoords(at) == Figure.none);

            return false;

        }
        private bool CanPawnMove()
        {
            if (fm.from.y < 1 && fm.from.y > 6) { return false; }
            int stepY = fm.figure.GetColor() == Color.white ? 1 : -1;
            return CanPawnGo(stepY) ||
                    CanPawnJump(stepY) ||
                    CanPawnEat(stepY);
        }


        private bool CanPawnGo(int stepY)
        {
            if (board.GetCoords(fm.to) == Figure.none)
            {
                if (fm.Dx == 0)
                    if (fm.Dy == stepY)
                        return true;
            }
            return false;

        }
        private bool CanPawnJump(int stepY)
        {
            if (board.GetCoords(fm.to) == Figure.none)
            {
                if (fm.Dx == 0)
                    if (fm.Dy == 2 * stepY)
                        if (fm.from.y == 1 || fm.from.y == 6)
                            if ((board.GetCoords(new Cell(fm.from.x, fm.from.y + stepY))) == Figure.none)
                                return true;
            }
            return false;

        }
        private bool CanPawnEat(int stepY)
        {
          if (board.GetCoords(fm.to) != Figure.none)
            {
                if (fm.AbsDx == 1)
                    if (fm.Dy == stepY)     
                     return true;
            }
            return false;
        }

    }
}