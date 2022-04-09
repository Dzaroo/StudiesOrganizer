using System;
using System.Globalization;
using System.Windows.Data;

namespace StudiesOrganizer.Converters
{
    internal class StringToShortConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            short shortValue = (short)value;

            return shortValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
