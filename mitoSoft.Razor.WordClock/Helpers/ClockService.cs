using mitoSoft.Razor.WordClock.Contracts;

namespace mitoSoft.Razor.WordClock.Helpers
{
    public class ClockService
    {
        private List<string> _textCells = new();
        private int _hour = -1;
        private int _minute = -1;
        private int _min = -1;

        public ClockService(ITextBuilder textBuilder, ICultureMatrix matrix)
        {
            this.TextBuilder = textBuilder;
            this.MatrixHelper = new MatrixHelper(matrix);
        }

        public MatrixHelper MatrixHelper { get; }

        public ITextBuilder TextBuilder { get; }

        public bool GetPositions(out List<string> cells)
        {
            if (DateTime.Now.Minute != _min)
            {
                var minuteCells = SetEdges(DateTime.Now.Minute - RoundMinutes(DateTime.Now.Minute));
                this._min = DateTime.Now.Minute;

                var hour = GetHour(DateTime.Now.Hour);
                var minute = RoundMinutes(DateTime.Now.Minute);

                if (hour != _hour || minute != _minute)
                {
                    string text = this.TextBuilder.GetText(hour, minute);

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

        private static List<string> SetEdges(int minutes)
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

        private List<string> SetText(string text)
        {
            var matrix = this.MatrixHelper.GetMatrix();
            var result = new List<string>();

            string[] a = text.Replace(" ", "§").Split("§");
            string word = a[0];
            int i = 0;
            for (int row = 0; row <= matrix.Max(c => c.Row); row++)
            {
                for (int col = 0; col <= matrix.Max(c => c.Col); col++)
                {
                    var actualText = this.GetTextOfMatrix(row, col, word.Length);
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

        public string GetTextOfMatrix(int row, int column, int length)
        {
            var maxCols = this.MatrixHelper.GetMatrix().Max(c => c.Col) + 1;
            if (column + length > maxCols)
            {
                return "";
            }

            string text = "";
            for (int i = 0; i <= length - 1; i++)
            {
                var letter = this.MatrixHelper.GetMatrix().First(c => c.Row == row && c.Col == column + i).Letter;

                text += letter;
            }
            return text;
        }

        public static int RoundMinutes(int minutes)
        {
            return minutes - (minutes % 5);
        }

        /// <summary>
        /// Only hours between 1-12 are valid
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