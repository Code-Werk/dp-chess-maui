using System.Globalization;

namespace DP.Chess.MAUI.Features
{
    /// <summary>
    /// Class responsible to return a double value (0.5) to set the opacity value of a view to 50% depending
    /// on a boolean value.
    /// </summary>
    public class BoolToHalfOpacityConverter : IValueConverter
    {
        public bool IsInverse { get; set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
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
        /// <inheritdoc/>
        /// </summary>
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