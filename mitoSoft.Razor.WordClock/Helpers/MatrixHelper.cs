using mitoSoft.Razor.WordClock.Contracts;
using mitoSoft.Razor.WordClock.Models;

namespace mitoSoft.Razor.WordClock.Helpers
{
    public class MatrixHelper
    {

        private readonly IList<MatrixCell> _matrix;

        public MatrixHelper(ICultureMatrix matrix)
        {
            _matrix = matrix.GetCells();
            var l = this._matrix.ToList();
            l.AddRange(Edges);
            this._matrix = l;
        }

        public IList<MatrixCell> GetMatrix()
        {
            return _matrix;
        }

        public string GetLetter(int row, int col)
        {
            var cell = this.GetMatrix().First(c => c.Row == row && c.Col == col);
            return cell.Letter;
        }

        private static readonly List<MatrixCell> Edges = new()
        {
            new MatrixCell(-1, -1, "•"),
            new MatrixCell(-2, -2, "•"),
            new MatrixCell(-3, -3, "•"),
            new MatrixCell(-4, -4, "•"),
        };
    }
}