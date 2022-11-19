using DP.Chess.MAUI.Features.ChessBoard.Pieces;
using System.Globalization;

namespace DP.Chess.MAUI.Features
{
    public class ColorSetTextColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not ColorSet colorSet)
            {
                return null;
            }

            switch (colorSet)
            {
                case ColorSet.Black: return Colors.White;
                case ColorSet.White: return Colors.Black;
                default: throw new NotImplementedException();
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new InvalidOperationException();
        }
    }
}