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
                    return false;

                case Figure.whiteRook:
                case Figure.blackRook:
                    return false;

                case Figure.whiteBishop:
                case Figure.blackBishop:
                    return false;

                case Figure.whiteKnight:
                case Figure.blackKnight:
                    return CanKnightMove();

                case Figure.whitePawn:
                case Figure.blackPawn:
                    return false;



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

    }
}