using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Lesson8.Presentation.Views
{
    public class CategoryIdConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((int)value == 0)
                return "Presentation/Icons/Icon1.png";
            if ((int)value == 0)
                return "Presentation/Icons/Icon2.png";
            return "Presentation/Icons/Icon3.png";
        }
        
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }    
    
}
