namespace mitoSoft.Razor.WordClock.Contracts
{
    public interface ICulture
    {
        string GetText(int hour, int minute);

        IList<string> Layout { get; }
    }
}