using System;
using System.Windows.Data;

namespace StudiesOrganizer.Converters
{
    public class BooleansToBooleanConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {

            if (values.LongLength > 0)
            {
                foreach (var value in values)
                {
                    if (value is bool && (bool)value)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            return new object[] { Binding.DoNothing };
        }
    }
}
