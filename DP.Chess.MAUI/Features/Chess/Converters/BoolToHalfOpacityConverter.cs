using System.Globalization;

namespace DP.Chess.MAUI.Features.Chess.Converters
{
    /// <summary>
    /// Class responsible to return a double value (0.5) to set the opacity
    /// value of a view to 50% depending on a boolean value.
    /// </summary>
    public class BoolToHalfOpacityConverter : IValueConverter
    {
        /// <summary>
        /// Gets or sets the flag if the converter
        /// should base the conversion on true or false.
        /// </summary>
        public bool IsInverse { get; set; }

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
            if (value is bool flag)
            {
                if (IsInverse)
                {
                    return flag ? 1.0 : 0.5;
                }

                return flag ? 0.5 : 1.0;
            }

            return 1.0;
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
            if (value is not double opacity)
            {
                return false;
            }

            return opacity == 1 ? IsInverse : !IsInverse;
        }
    }
}