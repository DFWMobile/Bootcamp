using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace DFWMobile.Bootcamp.Store.Controls
{
    public class HoneycombButton
        : Button
    {
        public static readonly DependencyProperty PointsProperty = DependencyProperty.Register("Points",
            typeof (PointCollection), typeof (HoneycombButton), new PropertyMetadata(null));

        public PointCollection Points
        {
            get { return (PointCollection)GetValue(PointsProperty); }
            //get
            //{
            //    var points = new PointCollection();

            //    if (Width > 0 && Height > 0)
            //    {
            //        var halfX = Width / 2;
            //        var sideLength = (double)Height * .47;
            //        var triangleHeight = (double)(Height - sideLength) / 2;

            //        points.Add(new Point((double)halfX, 0));
            //        points.Add(new Point((double)Width, triangleHeight));
            //        points.Add(new Point((double)Width, triangleHeight + sideLength));
            //        points.Add(new Point((double)halfX, (double)Height));
            //        points.Add(new Point(0, triangleHeight + sideLength));
            //        points.Add(new Point(0, triangleHeight));
            //    }

            //    return points;
            //}
            set { SetValue(PointsProperty, value); }
        }

        //    public PointCollection Points
        //    {
        //        get
        //        {
        //            var points = new PointCollection();

        //            if (Width > 0 && Height > 0)
        //            {
        //                var halfX = Width / 2;
        //                var sideLength = (double)Height * .47;
        //                var triangleHeight = (double)(Height - sideLength) / 2;

        //                points.Add(new Point((double)halfX, 0));
        //                points.Add(new Point((double)Width, triangleHeight));
        //                points.Add(new Point((double)Width, triangleHeight + sideLength));
        //                points.Add(new Point((double)halfX, (double)Height));
        //                points.Add(new Point(0, triangleHeight + sideLength));
        //                points.Add(new Point(0, triangleHeight));
        //            }

        //            return points;
        //        }
        //        set { ; }
        //    }
    }
}
