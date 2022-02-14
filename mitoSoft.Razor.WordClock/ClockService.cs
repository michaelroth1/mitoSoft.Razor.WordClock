using mitoSoft.Razor.WordClock.Contracts;
using mitoSoft.Razor.WordClock.Cultures;
using mitoSoft.Razor.WordClock.Extensions;
using mitoSoft.Razor.WordClock.Helpers;

namespace mitoSoft.Razor.WordClock
{
    public class ClockService
    {
        public ClockService()
        {
            var cultureInfo = Thread.CurrentThread.CurrentUICulture;

            if (cultureInfo.TwoLetterISOLanguageName.Equals("de"))
            {
                this.SetCulture(new ClockCultureDE());
            }
            else if (cultureInfo.TwoLetterISOLanguageName.Equals("fr"))
            {
                this.SetCulture(new ClockCultureFR());
            }
            else if (cultureInfo.TwoLetterISOLanguageName.Equals("es"))
            {
                this.SetCulture(new ClockCultureES());
            }
            else
            {
                this.SetCulture(new ClockCultureEN());
            }
        }

        public ClockService(IClockCulture culture)
        {
            this.SetCulture(culture);
        }

        private List<string> _textCells = new();
        private int _hour = -1;
        private int _minute = -1;
        private int _min = -1;

        public IClockCulture Culture { get; private set; } = default!;

        internal MatrixHelper MatrixHelper { get; private set; } = default!;

        private void SetCulture(IClockCulture culture)
        {
            this.Culture = culture;

            var matrix = this.Culture.Layout.ToList();

            this.MatrixHelper = new MatrixHelper(matrix);
        }

        public bool GetPositions(out List<string> cells)
        {
            var time = DateTime.Now;

            if (time.Minute != _min)
            {
                var minuteCells = GetEdgePositions(time.Minute - time.Minute.RoundMinutes());
                this._min = time.Minute;

                var hour = time.Hour.GetShortHour();
                var minute = time.Minute.RoundMinutes();

                if (hour != _hour || minute != _minute)
                {
                    string text = this.Culture.GetText(hour, minute);

                    this._textCells = GetLetterPositions(text);

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

        private List<string> GetEdgePositions(int minutes)
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
                        result.Add($"-1;{this.MatrixHelper.ColumnCount}");
                        break;
                    }
                case 3:
                    {
                        result.Add("-1;-1");
                        result.Add($"-1;{this.MatrixHelper.ColumnCount}");
                        result.Add($"{this.MatrixHelper.RowCount};{this.MatrixHelper.ColumnCount}");
                        break;
                    }
                case 4:
                    {
                        result.Add("-1;-1");
                        result.Add($"-1;{this.MatrixHelper.ColumnCount}");
                        result.Add($"{this.MatrixHelper.RowCount};{this.MatrixHelper.ColumnCount}");
                        result.Add($"{this.MatrixHelper.RowCount};-1");
                        break;
                    }
                default:
                    {
                        break;
                    }
            }

            return result;
        }

        private List<string> GetLetterPositions(string text)
        {
            var result = new List<string>();

            var words = text.Replace(" ", "§").Split("§").ToList();
            int i = 0;
            string word = words[i];
            for (int row = 0; row <= this.MatrixHelper.RowCount; row++)
            {
                for (int col = 0; col <= this.MatrixHelper.ColumnCount; col++)
                {
                    var actualText = this.GetTextByMatrixPosition(row, col, word.Length);
                    if (actualText == word)
                    {
                        for (int pos = col; pos < col + word.Length; pos++)
                        {
                            result.Add($"{row};{pos}");
                        }

                        col = col + word.Length - 1;

                        i += 1;
                        if (i < words.Count)
                        {
                            word = words[i];
                        }
                        else
                        {
                            return result;
                        }
                    }
                }
            }

            return result;
        }

        public string GetTextByMatrixPosition(int row, int column, int length)
        {
            string text = string.Empty;
            for (int pos = 0; pos <= length - 1; pos++)
            {
                if (pos > this.MatrixHelper.ColumnCount)
                {
                    break;
                }
                var letter = this.MatrixHelper.GetLetter(row, column + pos);
                text += letter;
            }
            return text;
        }
    }
}