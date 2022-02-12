using mitoSoft.Razor.WordClock.Contracts;
using mitoSoft.Razor.WordClock.Extensions;

namespace mitoSoft.Razor.WordClock.Helpers
{
    public class ClockService
    {
        public ClockService(ICulture culture)
        {
            this.Culture = culture;

            var matrix = this.Culture.Layout.ToList();

            this.MatrixHelper = new MatrixHelper(matrix);
        }

        private List<string> _textCells = new();
        private int _hour = -1;
        private int _minute = -1;
        private int _min = -1;

        public MatrixHelper MatrixHelper { get; }

        public ICulture Culture { get; }


        public bool GetPositions(out List<string> cells)
        {
            if (DateTime.Now.Minute != _min)
            {
                var minuteCells = SetEdges(DateTime.Now.Minute - RoundMinutes(DateTime.Now.Minute));
                this._min = DateTime.Now.Minute;

                var time = DateTime.Now; //(1982, 3, 7, 12, 15, 45); //for testing

                var hour = time.Hour.GetShortHour();
                var minute = RoundMinutes(time.Minute);

                if (hour != _hour || minute != _minute)
                {
                    string text = this.Culture.GetText(hour, minute);

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
            var result = new List<string>();

            string[] a = text.Replace(" ", "§").Split("§");
            string word = a[0];
            int i = 0;
            for (int row = 0; row <= this.MatrixHelper.Matrix.Max(c => c.Row); row++)
            {
                for (int col = 0; col <= this.MatrixHelper.Matrix.Max(c => c.Col); col++)
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
            var maxCols = this.MatrixHelper.Matrix.Max(c => c.Col) + 1;
            if (column + length > maxCols)
            {
                return "";
            }

            string text = "";
            for (int i = 0; i <= length - 1; i++)
            {
                var letter = this.MatrixHelper.Matrix.First(c => c.Row == row && c.Col == column + i).Letter;

                text += letter;
            }
            return text;
        }

        public static int RoundMinutes(int minutes)
        {
            return minutes - (minutes % 5);
        }
    }
}