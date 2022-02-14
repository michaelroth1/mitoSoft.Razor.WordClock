using mitoSoft.Razor.WordClock.Contracts;
using mitoSoft.Razor.WordClock.Extensions;

namespace mitoSoft.Razor.WordClock.Cultures
{
    public class ClockCultureES : IClockCulture
    {
        public IList<string> Layout { get; } = new List<string>()
        {
            "ESONELASUNA",
            "DOSITRESOAM",
            "CUATROCINCO",
            "SEISASIETEN",
            "OCHODHETZSE",
            "HJETNUEVEPM",
            "LADIEZSONCE",
            "DOCELYMENOS",
            "OVEINTEDIEZ",
            "VEINTICINCO",
            "MEDIACUARTO",
        };

        public string GetText(int hour, int minute)
        {
            string text;
            if (hour == 1)
            {
                text = "ES LA #hh# #mm#";
            }
            else
            {
                text = "SON LAS #hh# #mm#";
            }

            switch (minute)
            {
                case 5:
                    {
                        text = text.Replace("#mm#", "Y CINCO");
                        break;
                    }
                case 10:
                    {
                        text = text.Replace("#mm#", "Y DIEZ");
                        break;
                    }
                case 15:
                    {
                        text = text.Replace("#mm#", "Y CUARTO");
                        break;
                    }
                case 20:
                    {
                        text = text.Replace("#mm#", "Y VEINTE");
                        break;
                    }
                case 25:
                    {
                        text = text.Replace("#mm#", "Y VEINTICINCO");
                        hour = (hour + 1).GetShortHour();
                        break;
                    }
                case 30:
                    {
                        text = text.Replace("#mm#", "Y MEDIA");
                        break;
                    }
                case 35:
                    {
                        text = text.Replace("#mm#", "MENOS VEINTICINCO");
                        hour = (hour + 1).GetShortHour();
                        break;
                    }
                case 40:
                    {
                        text = text.Replace("#mm#", "MENOS VEINTE");
                        hour = (hour + 1).GetShortHour();
                        break;
                    }
                case 45:
                    {
                        text = text.Replace("#mm#", "MENOS CUARTO");
                        hour = (hour + 1).GetShortHour();
                        break;
                    }
                case 50:
                    {
                        text = text.Replace("#mm#", "MENOS DIEZ");
                        hour = (hour + 1).GetShortHour();
                        break;
                    }
                case 55:
                    {
                        text = text.Replace("#mm#", "MENOS CINCO");
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
                        text = text.Replace("#hh#", "UNA");
                        break;
                    }
                case 2:
                    {
                        text = text.Replace("#hh#", "DOS");
                        break;
                    }
                case 3:
                    {
                        text = text.Replace("#hh#", "TRES");
                        break;
                    }
                case 4:
                    {
                        text = text.Replace("#hh#", "CUATRO");
                        break;
                    }
                case 5:
                    {
                        text = text.Replace("#hh#", "CINCO");
                        break;
                    }
                case 6:
                    {
                        text = text.Replace("#hh#", "SEIS");
                        break;
                    }
                case 7:
                    {
                        text = text.Replace("#hh#", "SIETE");
                        break;
                    }
                case 8:
                    {
                        text = text.Replace("#hh#", "OCHO");
                        break;
                    }
                case 9:
                    {
                        text = text.Replace("#hh#", "NUEVE");
                        break;
                    }
                case 10:
                    {
                        text = text.Replace("#hh#", "DIEZ");
                        break;
                    }
                case 11:
                    {
                        text = text.Replace("#hh#", "ONCE");
                        break;
                    }
                case 12:
                case 0:
                    {
                        text = text.Replace("#hh#", "DOCE");
                        break;
                    }
            }

            return text;
        }
    }
}