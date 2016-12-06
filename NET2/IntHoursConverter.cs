using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace NET2
{
    [ValueConversion(typeof(int), typeof(string))]
    class IntHoursConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (value.ToString() + "ч.");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string val = (string)value;
            val.Remove(val.Length - 2, 2);
            int res = 0;
            int.TryParse(val, out res);
            return res;
        }
    }
}
