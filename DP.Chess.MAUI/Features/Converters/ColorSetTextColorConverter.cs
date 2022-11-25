using DP.Chess.MAUI.Features.Chess;
using System.Globalization;

namespace DP.Chess.MAUI.Features
{
    /// <summary>
    /// Class responsible to return the text color for a piece on the board.
    /// </summary>
    public class ColorSetTextColorConverter : IValueConverter
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not ColorSet colorSet)
            {
                return null;
            }

            return colorSet switch
            {
                ColorSet.Black => Colors.White,
                ColorSet.White => Colors.Black,
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