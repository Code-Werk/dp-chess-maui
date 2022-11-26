using DP.Chess.MAUI.Features.Chess;
using System.Globalization;

namespace DP.Chess.MAUI.Features.Chess.Converters
{
    /// <summary>
    /// Class responsible to return a background color based on a figure.
    /// </summary>
    public class ColorSetBackgroundColorConverter : IValueConverter
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not PlayerColor colorSet)
            {
                return null;
            }

            return colorSet switch
            {
                PlayerColor.Black => Colors.Black,
                PlayerColor.White => Colors.White,
                _ => throw new ArgumentOutOfRangeException($"color {colorSet} does not exist"),
            };
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