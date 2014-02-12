using System.Globalization;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Bing.Maps;
using Cirrious.MvvmCross.WindowsStore.Views;
using DFWMobile.Bootcamp.Core.ViewModels;
using DFWMobile.Bootcamp.Store.Converters;

namespace DFWMobile.Bootcamp.Store.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class GeoGroupDetailsView : MvxStorePage
    {
        public GeoGroupDetailsView()
        {
            this.InitializeComponent();
        }

        //private void GeoGroupDetailsView_OnLoaded(object sender, RoutedEventArgs e)
        //{
        //    var geoLocationConverter = App.Current.Resources["GeoLocationConverter"] as LocationConverter;
        //    var geoGroupDetailsViewModel = ViewModel as GeoGroupDetailsViewModel;
        //    if (geoGroupDetailsViewModel != null)
        //    {

        //        Map.Children.Clear();
        //        foreach (var item in geoGroupDetailsViewModel.Items)
        //        {
        //            var pushPin = new Pushpin();
        //            MapLayer.SetPosition(pushPin,
        //                (Location)
        //                    geoLocationConverter.Convert(item, null, null,
        //                        CultureInfo.CurrentCulture.TwoLetterISOLanguageName));
        //            Map.Children.Add(pushPin);
        //        }
        //        geoGroupDetailsViewModel.PropertyChanged += (o, args) =>
        //        {
        //            if (args.PropertyName == "SelectedGroup")
        //            {
        //                foreach (var item in geoGroupDetailsViewModel.Items)
        //                {
        //                    var location = geoLocationConverter.Convert(item, null, null,
        //                        CultureInfo.CurrentCulture.TwoLetterISOLanguageName) as Location;
        //                    this.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
        //                    {
        //                        var pushPin = new Pushpin();
        //                        MapLayer.SetPosition(pushPin, location);
        //                        Map.Children.Add(pushPin);
        //                    });

        //                }
        //            }
        //        };
        //    }
        //}
    }
}
