using DP.Chess.MAUI.Features.ChessBoard;
using System.Globalization;

namespace DP.Chess.MAUI.Features
{
    public class CellBackgroundConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not CellModel model)
            {
                return Colors.Black;
            }

            if ((model.Position.X + model.Position.Y) % 2 == 0)
            {
                return Colors.SaddleBrown;
            }
            return Colors.SandyBrown;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}