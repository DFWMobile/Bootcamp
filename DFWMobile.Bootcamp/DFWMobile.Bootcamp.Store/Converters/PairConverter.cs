using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;
using DFWMobile.Bootcamp.Common.Models;

namespace DFWMobile.Bootcamp.Store.Converters
{
    public class PairConverter
        : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            //var collection = value as ObservableCollection<Item>;

            //var pairs = new ObservableCollection<Pair<Item>>();
            //if (collection != null)
            //{
            //    for (var index = 0; index < collection.Count; index += 2)
            //    {
            //        var pair = new Pair<Item>();
            //        pair.First = collection[index];

            //        if (index + 1 < collection.Count)
            //        {
            //            pair.Second = collection[index + 1];
            //        }
            //        else
            //        {
            //            pair.HasSecond = false;
            //        }

            //        pairs.Add(pair);
            //    }
            //}

            //return pairs;

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
