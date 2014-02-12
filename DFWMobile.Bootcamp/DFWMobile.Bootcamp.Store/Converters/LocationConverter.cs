using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;
using Bing.Maps;
using DFWMobile.Bootcamp.Common.Models;

namespace DFWMobile.Bootcamp.Store.Converters
{
    public class LocationConverter
        : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var geoItem = value as GeoItem;
            if (geoItem != null)
            {
                return new Location(geoItem.Latitude, geoItem.Longitude);
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
