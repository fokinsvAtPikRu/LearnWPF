using System.Globalization;
using System.Windows.Data;

namespace Lesson6
{
    internal class BooleanToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool visiblity = (bool)value; 
            return visiblity? System.Windows.Visibility.Visible:System.Windows.Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return true;
        }
    }
}
