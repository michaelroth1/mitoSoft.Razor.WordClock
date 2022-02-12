using mitoSoft.Razor.WordClock.Models;

namespace mitoSoft.Razor.WordClock.Contracts
{
    public interface ICultureMatrix
    {
        IList<string> Layout { get; }
    }
}