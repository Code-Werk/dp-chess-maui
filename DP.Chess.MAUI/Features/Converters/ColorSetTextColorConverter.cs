using DP.Chess.MAUI.Features.Chess;
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

            return colorSet switch
            {
                ColorSet.Black => Colors.White,
                ColorSet.White => Colors.Black,
                _ => throw new ArgumentOutOfRangeException($"color {colorSet} does not exist"),
            };
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}