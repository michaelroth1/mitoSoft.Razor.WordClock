namespace mitoSoft.Razor.WordClock.Contracts
{
    public interface ITextBuilder
    {
        string GetText(int hour, int minute);
    }
}