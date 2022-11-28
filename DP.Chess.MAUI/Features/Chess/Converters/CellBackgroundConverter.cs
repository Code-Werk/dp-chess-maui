using DP.Chess.MAUI.Features.Chess.Cells;
using System.Globalization;

namespace DP.Chess.MAUI.Features.Chess.Converters
{
    /// <summary>
    /// Class responsible to return a background color based on a cell and its position.
    /// </summary>
    public class CellBackgroundConverter : IValueConverter
    {
        /// <summary>
        /// <inheritdoc />
        /// </summary>
        /// <param name="value"><inheritdoc /></param>
        /// <param name="targetType"><inheritdoc /></param>
        /// <param name="parameter"><inheritdoc /></param>
        /// <param name="culture"><inheritdoc /></param>
        /// <returns><inheritdoc /></returns>
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
        /// <inheritdoc />
        /// </summary>
        /// <param name="value"><inheritdoc /></param>
        /// <param name="targetType"><inheritdoc /></param>
        /// <param name="parameter"><inheritdoc /></param>
        /// <param name="culture"><inheritdoc /></param>
        /// <returns><inheritdoc /></returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}