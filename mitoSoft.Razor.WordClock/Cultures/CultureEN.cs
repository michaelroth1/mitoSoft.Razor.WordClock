using mitoSoft.Razor.WordClock.Contracts;
using mitoSoft.Razor.WordClock.Extensions;

namespace mitoSoft.Razor.WordClock.Cultures
{
    internal class CultureEN : ICulture
    {
        private readonly Random _rnd = new(DateTime.Now.Millisecond);

        public IList<string> Layout { get; } = new List<string>()
        {
            "ITLISASAMPM",
            "ACQUARTERDC",
            "TWENTYFIVEX",
            "HALFSTENFTO",
            "OAFTEROHALF",
            "PASTERUNINE",
            "ONESIXTHREE",
            "FOURFIVETWO",
            "EIGHTELEVEN",
            "SEVENTWELVE",
            "TENSEOCLOCK",
        };

        public string GetText(int hour, int minute)
        {
            string text;
            if (minute == 0)
            {
                text = "IT IS #mm# #hh#";
            }
            else if (_rnd.Next(0, 10) <= 7)
            {
                text = "IT IS #mm# #hh#";
            }
            else
            {
                text = "#mm# #hh#";
            }

            switch (minute)
            {
                case 5:
                    {
                        text = text.Replace("#mm#", "FIVE PAST");
                        break;
                    }
                case 10:
                    {
                        text = text.Replace("#mm#", "TEN PAST");
                        break;
                    }
                case 15:
                    {
                        text = text.Replace("#mm#", "QUARTER PAST");
                        break;
                    }
                case 20:
                    {
                        text = text.Replace("#mm#", "TWENTY PAST");
                        break;
                    }
                case 25:
                    {
                        if (this._rnd.Next(0, 2) == 0)
                        {
                            text = text.Replace("#mm#", "FIVE TO HALF PAST");
                        }
                        else
                        {
                            text = text.Replace("#mm#", "TWENTYFIVE PAST");
                        }
                        break;
                    }
                case 30:
                    {
                        text = text.Replace("#mm#", "HALF PAST");
                        break;
                    }
                case 35:
                    {
                        if (this._rnd.Next(0, 2) == 0)
                        {
                            text = text.Replace("#mm#", "FIVE AFTER HALF PAST");
                        }
                        else
                        {
                            text = text.Replace("#mm#", "TWENTYFIVE TO");
                            hour = (hour + 1).GetShortHour();
                        }
                        break;
                    }
                case 40:
                    {
                        if (this._rnd.Next(0, 2) == 0)
                        {
                            text = text.Replace("#mm#", "TEN AFTER HALF PAST");
                        }
                        else
                        {
                            text = text.Replace("#mm#", "TWENTY TO");
                            hour = (hour + 1).GetShortHour();
                        }
                        break;
                    }
                case 45:
                    {
                        text = text.Replace("#mm#", "QUARTER TO");
                        hour = (hour + 1).GetShortHour();
                        break;
                    }
                case 50:
                    {
                        text = text.Replace("#mm#", "TEN TO");
                        hour = (hour + 1).GetShortHour();
                        break;
                    }
                case 55:
                    {
                        text = text.Replace("#mm#", "FIVE TO");
                        hour = (hour + 1).GetShortHour();
                        break;
                    }
                case 0:
                    {
                        text = text.Replace("#mm# ", "");
                        text = text.Replace("#hh#", "#hh#" + " OCLOCK");
                        break;
                    }
            }

            switch (hour)
            {
                case 1:
                    {
                        text = text.Replace("#hh#", "ONE");
                        break;
                    }
                case 2:
                    {
                        text = text.Replace("#hh#", "TWO");
                        break;
                    }
                case 3:
                    {
                        text = text.Replace("#hh#", "THREE");
                        break;
                    }
                case 4:
                    {
                        text = text.Replace("#hh#", "FOUR");
                        break;
                    }
                case 5:
                    {
                        text = text.Replace("#hh#", "FIVE");
                        break;
                    }
                case 6:
                    {
                        text = text.Replace("#hh#", "SIX");
                        break;
                    }
                case 7:
                    {
                        text = text.Replace("#hh#", "SEVEN");
                        break;
                    }
                case 8:
                    {
                        text = text.Replace("#hh#", "EIGHT");
                        break;
                    }
                case 9:
                    {
                        text = text.Replace("#hh#", "NINE");
                        break;
                    }
                case 10:
                    {
                        text = text.Replace("#hh#", "TEN");
                        break;
                    }
                case 11:
                    {
                        text = text.Replace("#hh#", "ELEVEN");
                        break;
                    }
                case 12:
                case 0:
                    {
                        text = text.Replace("#hh#", "TWELVE");
                        break;
                    }
            }

            return text;
        }
    }
}
