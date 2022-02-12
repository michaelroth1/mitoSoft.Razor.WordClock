using mitoSoft.Razor.WordClock.Models;

namespace mitoSoft.Razor.WordClock.Helpers
{
    public class MatrixHelper
    {
        public MatrixHelper(List<string> matrix)
        {
            Check(matrix);
            this.Matrix = GetCells(matrix);
            this.AppendEdges();
        }

        public List<MatrixCell> Matrix { get; private set; }

        public string GetLetter(int row, int col)
        {
            var cell = this.Matrix.First(c => c.Row == row && c.Col == col);
            return cell.Letter;
        }

        private void AppendEdges()
        {
            this.Matrix.Add(new MatrixCell(-1, -1, "•"));
            this.Matrix.Add(new MatrixCell(-2, -2, "•"));
            this.Matrix.Add(new MatrixCell(-3, -3, "•"));
            this.Matrix.Add(new MatrixCell(-4, -4, "•"));
        }

        private static List<MatrixCell> GetCells(List<string> rows)
        {
            var cells = new List<MatrixCell>();

            for (int row = 0; row < 11; row++)
            {
                for (int col = 0; col < 11; col++)
                {
                    var letter = rows[row].Substring(col, 1);

                    var matrixCell = new MatrixCell(row, col, letter);

                    cells.Add(matrixCell);
                }
            }

            return cells;
        }

        private static void Check(List<string> rows)
        {
            if (rows.Count != 11)
            {
                throw new IndexOutOfRangeException($"Invalid row number in letter matrix: {rows.Count}");
            }
            foreach (var row in rows)
            {
                if (row.Length != 11)
                {
                    throw new IndexOutOfRangeException($"Invalid column length in letter matrix: {row.Length}");
                }
            }
        }
    }
}