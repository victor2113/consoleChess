using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.Collections;

namespace NEXTCHESS
{
    public enum Figure
    {
        none,


        whiteKing = 'K',
        whiteQueen = 'Q',
        whiteRook = 'R',
        whiteBishop = 'B',
        whiteKnight = 'N',
        whitePawn = 'P',


        blackKing = 'k',
        blackQueen = 'q',
        blackRook = 'r',
        blackBishop = 'b',
        blackKnight = 'n',
        blackPawn = 'p'

    }

    static class MethodsForF
    {
        public static Color GetColor(this Figure figure)
        {
            if (figure == Figure.none) return Color.none;
            return 
            (figure == Figure.whiteBishop
            || figure == Figure.whiteKing
            || figure == Figure.whitePawn
            || figure == Figure.whiteQueen
            || figure == Figure.whiteRook
            || figure == Figure.whiteKnight) ? Color.white : Color.black;
        }
    }
}