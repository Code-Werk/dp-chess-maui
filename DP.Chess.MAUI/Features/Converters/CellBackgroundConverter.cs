using DP.Chess.MAUI.Features.Chess;
using System.Globalization;

namespace DP.Chess.MAUI.Features
{
    /// <summary>
    /// Class responsible to return a background color based on a cell and its position.
    /// </summary>
    public class CellBackgroundConverter : IValueConverter
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not ChessCellModel model)
            {
                return Colors.Black;
            }

            if ((model.Position.X + model.Position.Y) % 2 == 0)
            {
                return Colors.SaddleBrown;
            }
            return Colors.SandyBrown;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}