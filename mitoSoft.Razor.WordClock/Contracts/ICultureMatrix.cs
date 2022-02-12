using mitoSoft.Razor.WordClock.Models;

namespace mitoSoft.Razor.WordClock.Contracts
{
    public interface ICultureMatrix
    {
        IList<MatrixCell> GetCells();
    }
}