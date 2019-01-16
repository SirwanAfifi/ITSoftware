using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Wpf.converters
{
    public class imageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (targetType != typeof(ImageSource))
                throw new InvalidOperationException("Target type must be System.Windows.Media.ImageSource");

            try
            {
                BitmapImage img = new BitmapImage();
                img.BeginInit();
                img.UriSource = new Uri("/namespace;component/Images/coffee" + value + ".jpg", UriKind.Relative);
                img.EndInit();
                return img;
            }
            catch (Exception ex)
            {
                return DependencyProperty.UnsetValue;
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
