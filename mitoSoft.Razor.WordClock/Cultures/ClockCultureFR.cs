using mitoSoft.Razor.WordClock.Contracts;
using mitoSoft.Razor.WordClock.Extensions;

namespace mitoSoft.Razor.WordClock.Cultures
{
    public class ClockCultureFR : IClockCulture
    {
        private readonly Random _rnd = new(DateTime.Now.Millisecond);

        public IList<string> Layout { get; } = new List<string>()
        {
            "ILNESTODEUX",
            "QUATRETROIS",
            "NEUFUNEGHTZ",
            "SEPTDAGERTZ",
            "HUITSIXCINQ",
            "MIDIXMINUIT",
            "ONZERHEURES",
            "MOINSOLEDIX",
            "ETRQUARTPMD",
            "VINGT-CINQU",
            "ETSDEMIEPAM",
        };

        public string GetText(int hour, int minute)
        {
            string text;
            if (minute == 0)
            {
                text = "IL EST #hh# #mm#";
            }
            else if (_rnd.Next(0, 10) <= 7)
            {
                text = "IL EST #hh# #mm#";
            }
            else
            {
                text = "#hh# #mm#";
            }

            switch (minute)
            {
                case 5:
                    {
                        text = text.Replace("#mm#", "CINQ");
                        break;
                    }
                case 10:
                    {
                        text = text.Replace("#mm#", "DIX");
                        break;
                    }
                case 15:
                    {
                        text = text.Replace("#mm#", "ET QUART");
                        break;
                    }
                case 20:
                    {
                        text = text.Replace("#mm#", "VINGT");
                        break;
                    }
                case 25:
                    {
                        text = text.Replace("#mm#", "VINGT-CINQ");
                        break;
                    }
                case 30:
                    {
                        text = text.Replace("#mm#", "ET DEMIE");
                        break;
                    }
                case 35:
                    {
                        text = text.Replace("#mm#", "MOINS VINGT-CINQ");
                        hour = (hour + 1).GetShortHour();
                        break;
                    }
                case 40:
                    {
                        text = text.Replace("#mm#", " MOINS VINGT");
                        hour = (hour + 1).GetShortHour();
                        break;
                    }
                case 45:
                    {
                        text = text.Replace("#mm#", "MOINS LE QUART");
                        break;
                    }
                case 50:
                    {
                        text = text.Replace("#mm#", "MOINS DIX");
                        hour = (hour + 1).GetShortHour();
                        break;
                    }
                case 55:
                    {
                        text = text.Replace("#mm#", "MOINS CINQ");
                        hour = (hour + 1).GetShortHour();
                        break;
                    }
                case 0:
                    {
                        text = text.Replace("#mm# ", "");
                        break;
                    }
            }

            switch (hour)
            {
                case 1:
                    {
                        text = text.Replace("#hh#", "UNE HEURE");
                        break;
                    }
                case 2:
                    {
                        text = text.Replace("#hh#", "DEUX HEURES");
                        break;
                    }
                case 3:
                    {
                        text = text.Replace("#hh#", "TROIS HEURES");
                        break;
                    }
                case 4:
                    {
                        text = text.Replace("#hh#", "QUATRE HEURES");
                        break;
                    }
                case 5:
                    {
                        text = text.Replace("#hh#", "CINQ HEURES");
                        break;
                    }
                case 6:
                    {
                        text = text.Replace("#hh#", "SIX HEURES");
                        break;
                    }
                case 7:
                    {
                        text = text.Replace("#hh#", "SEPT HEURES");
                        break;
                    }
                case 8:
                    {
                        text = text.Replace("#hh#", "HUIT HEURES");
                        break;
                    }
                case 9:
                    {
                        text = text.Replace("#hh#", "NEUF HEURES");
                        break;
                    }
                case 10:
                    {
                        text = text.Replace("#hh#", "DIX HEURES");
                        break;
                    }
                case 11:
                    {
                        text = text.Replace("#hh#", "ONZE HEURES");
                        break;
                    }
                case 12:
                    {
                        text = text.Replace("#hh#", "MIDI");
                        break;
                    }
                case 0:
                    {
                        text = text.Replace("#hh#", "MINUIT");
                        break;
                    }
            }

            return text;
        }
    }
}
