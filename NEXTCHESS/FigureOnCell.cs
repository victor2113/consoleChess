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