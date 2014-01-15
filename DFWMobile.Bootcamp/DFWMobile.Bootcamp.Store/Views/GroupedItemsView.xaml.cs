using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.DataTransfer;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ApplicationSettings;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238
using Cirrious.MvvmCross.WindowsStore.Views;
using DFWMobile.Bootcamp.Common.Services;

namespace DFWMobile.Bootcamp.Store.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class GroupedItemsView : MvxStorePage
    {
        public GroupedItemsView()
        {
            this.NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled;
            this.InitializeComponent();
            //DataTransferManager.GetForCurrentView().DataRequested += ShareLinkHandler;
            //Loaded += ItemsShowcaseView_Loaded;

            //Windows.ApplicationModel.Search.SearchPane.GetForCurrentView().QuerySubmitted += searchPane_QuerySubmitted;
            //Windows.ApplicationModel.Search.SearchPane.GetForCurrentView().ShowOnKeyboardInput = true;

            //if (AppSettings.EnableWin8Background == true)
            //    ShowcaseGrid.Background = Application.Current.Resources["WallPaperBrush"] as ImageBrush;
        }
        private void ShareLinkHandler(DataTransferManager sender, DataRequestedEventArgs e)
        {
            DataRequest request = e.Request;
            var deferral = request.GetDeferral();
            //request.Data.Properties.Title = AppSettings.ApplicationName;
            request.Data.SetText("Check out this awesome app in the Windows Store!");
            //request.Data.SetBitmap(RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/Logo.png")));
            deferral.Complete();
        }

        async void ItemsShowcaseView_Loaded(object sender, RoutedEventArgs e)
        {

            //Cache loads so fast if called from constructor that property changed is not fired
            if (groupedItemsViewSource.View != null && groupedItemsViewSource.View.CollectionGroups != null)
                ZoomedOutGroupGridView.ItemsSource = groupedItemsViewSource.View.CollectionGroups;

            //if (!AppState.Windows8ItemsShowcaseViewInitialized)
            //{
            //    ((ItemsShowcaseViewModel) DataContext).PropertyChanged += vm_PropertyChanged;

            //    Windows.ApplicationModel.Search.SearchPane.GetForCurrentView().QuerySubmitted +=
            //        searchPane_QuerySubmitted;
            //    Windows.ApplicationModel.Search.SearchPane.GetForCurrentView().ShowOnKeyboardInput = true;
            //}
        }
    }
}
