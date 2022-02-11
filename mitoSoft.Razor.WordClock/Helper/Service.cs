namespace mitoSoft.Razor.WordClock.Helper
{
    internal class Service
    {
        private readonly Random _rnd = new(DateTime.Now.Millisecond);
        private List<string> _textCells = new();
        private int _hour;
        private int _minute;
        private int _min;

        public bool GetPositions(out List<string> cells)
        {
            if (DateTime.Now.Minute != _min)
            {
                var minuteCells = SetMinutes(DateTime.Now.Minute - RoundMinutes(DateTime.Now.Minute));
                this._min = DateTime.Now.Minute;

                var hour = GetHour(DateTime.Now.Hour);
                var minute = RoundMinutes(DateTime.Now.Minute);

                if (hour != _hour || minute != _minute)
                {
                    string text = this.GetText(hour, minute);

                    this._textCells = SetText(text);

                    _hour = hour;
                    _minute = minute;

                }

                this._textCells.AddRange(minuteCells);
                cells = this._textCells;

                return true;
            }
            cells = new();

            return false;
        }

        private static List<string> SetMinutes(int minutes)
        {
            var result = new List<string>();

            switch (minutes)
            {
                case 1:
                    {
                        result.Add("-1;-1");
                        break;
                    }

                case 2:
                    {
                        result.Add("-1;-1");
                        result.Add("-2;-2");
                        break;
                    }
                case 3:
                    {
                        result.Add("-1;-1");
                        result.Add("-2;-2");
                        result.Add("-3;-3");
                        break;
                    }
                case 4:
                    {
                        result.Add("-1;-1");
                        result.Add("-2;-2");
                        result.Add("-3;-3");
                        result.Add("-4;-4");
                        break;
                    }
                default:
                    {
                        break;
                    }
            }

            return result;
        }


        private static List<string> SetText(string text)
        {
            var matrix = LetterMatrix.Cells;
            var result = new List<string>();

            string[] a = text.Replace(" ", "§").Split("§");
            string word = a[0];
            int i = 0;
            for (int row = 0; row <= matrix.Max(c => c.Row) + 1; row++)
            {
                for (int col = 0; col <= matrix.Max(c => c.Col) + 1; col++)
                {
                    var actualText = GetTextOfMatrix(row, col, word.Length);
                    if (actualText == word)
                    {
                        for (int pos = col; pos < col + word.Length; pos++)
                        {
                            result.Add($"{row};{pos}");
                        }

                        col = col + word.Length - 1;

                        i += 1;
                        if (a.GetUpperBound(0) >= i)
                            word = a[i];
                        else
                            return result;
                    }
                }
            }

            return result;
        }


        public static string GetTextOfMatrix(int row, int column, int length)
        {
            var maxCols = LetterMatrix.Cells.Max(c => c.Col) + 1;
            if (column + length > maxCols)
            {
                return "";
            }

            string text = "";
            for (int i = 0; i <= length - 1; i++)
            {
                var letter = LetterMatrix.Cells.First(c => c.Row == row && c.Col == column + i).Letter;

                text += letter;
            }
            return text;
        }

        public static int RoundMinutes(int minutes)
        {
            return minutes - (minutes % 5);
        }

        private string GetText(int hour, int minute)
        {
            string text;

            if (minute == 0)
            {
                text = "ES IST #mm# #hh#";
            }
            else if (_rnd.Next(0, 10) <= 5)
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
                            text = text.Replace("#mm#", "ZWANZIG NACH");
                        else
                        {
                            text = text.Replace("#mm#", "ZEHN VOR HALB");
                            hour = GetHour(hour + 1);
                        }

                        break;
                    }
                case 25:
                    {
                        text = text.Replace("#mm#", "FÜNF VOR HALB");
                        hour = GetHour(hour + 1);
                        break;
                    }
                case 30:
                    {
                        text = text.Replace("#mm#", "HALB");
                        hour = GetHour(hour + 1);
                        break;
                    }
                case 35:
                    {
                        text = text.Replace("#mm#", "FÜNF NACH HALB");
                        hour = GetHour(hour + 1);
                        break;
                    }
                case 40:
                    {
                        text = text.Replace("#mm#", "ZEHN NACH HALB");
                        hour = GetHour(hour + 1);
                        break;
                    }
                case 45:
                    {
                        if (this._rnd.Next(0, 2) == 0)
                            text = text.Replace("#mm#", "VIERTEL VOR");
                        else
                            text = text.Replace("#mm#", "DREIVIERTEL");
                        hour = GetHour(hour + 1);
                        break;
                    }
                case 50:
                    {
                        text = text.Replace("#mm#", "ZEHN VOR");
                        hour = GetHour(hour + 1);
                        break;
                    }
                case 55:
                    {
                        text = text.Replace("#mm#", "FÜNF VOR");
                        hour = GetHour(hour + 1);
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
                            text = text.Replace("#hh#", "EINS");
                        else
                            text = text.Replace("#hh#", "EIN");
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

        /// <summary>
        /// Es werden nur die Stunden 1-12 zurückgegeben
        /// </summary>
        private static int GetHour(int hour)
        {
            if (hour > 12)
            {
                return hour - 12;
            }
            else
            {
                return hour;
            }
        }
    }
}