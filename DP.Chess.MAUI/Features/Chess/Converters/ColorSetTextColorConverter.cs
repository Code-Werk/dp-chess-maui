using System.Globalization;

namespace DP.Chess.MAUI.Features.Chess.Converters
{
    /// <summary>
    /// Class responsible to return the text color for a piece on the board.
    /// </summary>
    public class ColorSetTextColorConverter : IValueConverter
    {
        /// <summary>
        /// <inheritdoc />
        /// </summary>
        /// <param name="value"><inheritdoc /></param>
        /// <param name="targetType"><inheritdoc /></param>
        /// <param name="parameter"><inheritdoc /></param>
        /// <param name="culture"><inheritdoc /></param>
        /// <returns><inheritdoc /></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public object? Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not PlayerColor colorSet)
            {
                return null;
            }

            return colorSet switch
            {
                PlayerColor.Black => Colors.White,
                PlayerColor.White => Colors.Black,
                _ => throw new ArgumentOutOfRangeException($"color {colorSet} does not exist"),
            };
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