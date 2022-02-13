namespace mitoSoft.Razor.WordClock.Contracts
{
    public interface IClockCulture
    {
        string GetText(int hour, int minute);

        IList<string> Layout { get; }
    }
}