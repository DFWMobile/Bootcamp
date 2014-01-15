using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;

namespace DFWMobile.Bootcamp.Store.Converters
{
    public class HoneycombConverter
        : IValueConverter
    {
        //0,50 0,139 85,189 170,139 170,50 85,0
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var width = value as double?;
            var height = parameter as double?;
            var points = new PointCollection();

            if (width.HasValue && height.HasValue)
            {
                var halfX = width / 2;
                var sideLength = (double)height * .47;
                var triangleHeight = (double)(height - sideLength) / 2;

                points.Add(new Point((double)halfX, 0));
                points.Add(new Point((double)width, triangleHeight));
                points.Add(new Point((double)width, triangleHeight + sideLength));
                points.Add(new Point((double)halfX, (double)height));
                points.Add(new Point(0, triangleHeight + sideLength));
                points.Add(new Point(0, triangleHeight));
            }

            return points;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
