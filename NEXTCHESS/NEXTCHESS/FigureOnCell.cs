using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.Collections;

namespace NEXTCHESS
{
    public class FigureOnCell
    {
        public Figure figure { get; private set; }
        public Cell cell { get; private set; }
        public FigureOnCell(Figure figure, Cell cell)
        {
            this.figure = figure;
            this.cell = cell;
        }
    }
}