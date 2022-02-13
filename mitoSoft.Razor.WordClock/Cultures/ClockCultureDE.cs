using mitoSoft.Razor.WordClock.Contracts;
using mitoSoft.Razor.WordClock.Extensions;

namespace mitoSoft.Razor.WordClock.Cultures
{
    public class ClockCultureDE : IClockCulture
    {
        private readonly Random _rnd = new(DateTime.Now.Millisecond);

        public IList<string> Layout { get; } = new List<string>()
        {
            "ESKISTAFÜNF",
            "ZEHNZWANZIG",
            "DREIVIERTEL",
            "VORFUNKNACH",
            "HALBAELFÜNF",
            "EINSXAMZWEI",
            "DREIPMJVIER",
            "FÜNFTDSECHS",
            "SIEBENLACHT",
            "NEUNZEHNELF",
            "ZWÖLFUNKUHR",
        };

        public string GetText(int hour, int minute)
        {
            string text;
            if (minute == 0)
            {
                text = "ES IST #mm# #hh#";
            }
            else if (_rnd.Next(0, 10) <= 7)
            {
                text = "ES IST #mm# #hh#";
            }
            else
            {
                text = "#mm# #hh#";
            }

            switch (minute)
            {
                case 5:
                    {
                        text = text.Replace("#mm#", "FÜNF NACH");
                        break;
                    }
                case 10:
                    {
                        text = text.Replace("#mm#", "ZEHN NACH");
                        break;
                    }
                case 15:
                    {
                        text = text.Replace("#mm#", "VIERTEL NACH");
                        break;
                    }
                case 20:
                    {
                        if (this._rnd.Next(0, 2) == 0)
                        {
                            text = text.Replace("#mm#", "ZWANZIG NACH");
                        }
                        else
                        {
                            text = text.Replace("#mm#", "ZEHN VOR HALB");
                            hour = (hour + 1).GetShortHour();
                        }
                        break;
                    }
                case 25:
                    {
                        text = text.Replace("#mm#", "FÜNF VOR HALB");
                        hour = (hour + 1).GetShortHour();
                        break;
                    }
                case 30:
                    {
                        text = text.Replace("#mm#", "HALB");
                        hour = (hour + 1).GetShortHour();
                        break;
                    }
                case 35:
                    {
                        text = text.Replace("#mm#", "FÜNF NACH HALB");
                        hour = (hour + 1).GetShortHour();
                        break;
                    }
                case 40:
                    {
                        text = text.Replace("#mm#", "ZEHN NACH HALB");
                        hour = (hour + 1).GetShortHour();
                        break;
                    }
                case 45:
                    {
                        if (this._rnd.Next(0, 2) == 0)
                        {
                            text = text.Replace("#mm#", "VIERTEL VOR");
                        }
                        else
                        {
                            text = text.Replace("#mm#", "DREIVIERTEL");
                        }
                        hour = (hour + 1).GetShortHour();
                        break;
                    }
                case 50:
                    {
                        text = text.Replace("#mm#", "ZEHN VOR");
                        hour = (hour + 1).GetShortHour();
                        break;
                    }
                case 55:
                    {
                        text = text.Replace("#mm#", "FÜNF VOR");
                        hour = (hour + 1).GetShortHour();
                        break;
                    }
                case 0:
                    {
                        text = text.Replace("#mm# ", "");
                        text = text.Replace("#hh#", "#hh#" + " UHR");
                        break;
                    }
            }

            switch (hour)
            {
                case 1:
                    {
                        if (minute != 0)
                        {
                            text = text.Replace("#hh#", "EINS");
                        }
                        else
                        {
                            text = text.Replace("#hh#", "EIN");
                        }
                        break;
                    }
                case 2:
                    {
                        text = text.Replace("#hh#", "ZWEI");
                        break;
                    }
                case 3:
                    {
                        text = text.Replace("#hh#", "DREI");
                        break;
                    }
                case 4:
                    {
                        text = text.Replace("#hh#", "VIER");
                        break;
                    }
                case 5:
                    {
                        text = text.Replace("#hh#", "FÜNF");
                        break;
                    }
                case 6:
                    {
                        text = text.Replace("#hh#", "SECHS");
                        break;
                    }
                case 7:
                    {
                        text = text.Replace("#hh#", "SIEBEN");
                        break;
                    }
                case 8:
                    {
                        text = text.Replace("#hh#", "ACHT");
                        break;
                    }
                case 9:
                    {
                        text = text.Replace("#hh#", "NEUN");
                        break;
                    }
                case 10:
                    {
                        text = text.Replace("#hh#", "ZEHN");
                        break;
                    }
                case 11:
                    {
                        text = text.Replace("#hh#", "ELF");
                        break;
                    }
                case 12:
                case 0:
                    {
                        text = text.Replace("#hh#", "ZWÖLF");
                        break;
                    }
            }

            return text;
        }
    }
}