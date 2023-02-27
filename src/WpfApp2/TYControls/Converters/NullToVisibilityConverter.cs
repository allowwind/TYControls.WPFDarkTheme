using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace TYControls
{
    public class NullToVisibilityConverter : IValueConverter
    {
        /// <summary>
        /// The visibility value if the argument is null.
        /// </summary>
        public Visibility NullValue { get; set; }

        /// <summary>
        /// Creates a new <see cref="NullToVisibilityConverter" />.
        /// </summary>
        public NullToVisibilityConverter()
        {
            NullValue = Visibility.Visible;
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value == null ?  NullValue : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}
