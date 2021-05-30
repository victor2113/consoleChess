using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;

namespace NEXTCHESS
{
    public struct Cell
    {
        public static Cell none = new Cell(-8, -8);
        public int x { get; private set; }
        public int y { get; private set; }

        public Cell(int x, int y)
        {
            this.x = x;
            this.y = y;
        }


        public Cell(string coords)
        {
            if (coords.Length == 2 &&
                coords[0] >= 'a' &&
                coords[0] <= 'h' &&
                coords[1] >= '1' &&
                coords[1] <= '8')
            {
                x = coords[0] - 'a';
                y = coords[1] - '1';
            }
            else
            {
                this = none;
            }
        }

        public bool checkCell()//onBoard
        {
            return x >= 0 && x < 8 &&
                   y >= 0 && y < 8;
        }


        public static bool operator ==(Cell a, Cell b)
        {
            return a.x == b.x && a.y == b.y;
        }
        public static bool operator !=(Cell a, Cell b)
        {
            return a.x != b.x || a.y != b.y;
        }


        
       
    }
}