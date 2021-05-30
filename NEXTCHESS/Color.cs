using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
namespace NEXTCHESS
{
     public enum Color
    {
        none,
        white,
        black
    }

    static class ColorMethods{
        public static Color FlipColor(this Color color){
            if(color == Color.white) return Color.black;
            if(color == Color.black) return Color.white;
            return Color.none;
        }
    }

}