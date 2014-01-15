using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cirrious.CrossCore.Platform;
using DFWMobile.Bootcamp.Common.DataSources;
using DFWMobile.Bootcamp.Common.Models;
using DFWMobile.Bootcamp.Common.Services;
using DFWMobile.Bootcamp.Common.Settings;

namespace DFWMobile.Bootcamp.Core.ViewModels
{
    public class GroupedItemsViewModel
        : BaseViewModel
    {
        private IDataServiceFactory _dataServiceFactory;
        private readonly List<IDataService> _dataServices;
        private readonly IMvxResourceLoader _resourceLoader;
        private readonly ObservableCollection<Group<Item>> _groupedItems; 
        public GroupedItemsViewModel(IAppSettings appSettings, IDataServiceFactory dataServiceFactory, IMvxResourceLoader resourceLoader)
            : base(appSettings)
        {
            _dataServiceFactory = new DataServiceFactory(appSettings, _resourceLoader);
            _resourceLoader = resourceLoader;

            _dataServices = new List<IDataService>()
            {
                _dataServiceFactory.GenerateService(new RssDataSource()
                {
                    ServiceUri = "http://gdata.youtube.com/feeds/base/videos?alt=rss&author=thewindotnet",
                    ServiceName = "Youtube author example"
                }),
                _dataServiceFactory.GenerateService(new RssDataSource()
                {

                    ServiceUri = "https://www.facebook.com/feeds/page.php?format=rss20&id=487598667939827",
                    ServiceName = "Facebook Example"
                }),
                _dataServiceFactory.GenerateService(new RssDataSource()
                {
                    ServiceUri = "http://api.flickr.com/services/feeds/photos_public.gne?format=rss&tags=cats",
                    ServiceName = "Flickr Example"

                }),
                _dataServiceFactory.GenerateService(new RssDataSource()
                {
                    ServiceUri =
                        "http://gdata.youtube.com/feeds/api/playlists/PL976D5FEB096858B1?alt=rss&max-results=50&start-index=1",
                    ServiceName = "Youtube Playlist Example"
                }),
                _dataServiceFactory.GenerateService(new RssDataSource()
                {
                    ServiceUri = "http://gdata.youtube.com/feeds/base/videos?alt=rss&q=xbox%20one",
                    ServiceName = "Youtube query example"
                }),

            };

            _groupedItems = new ObservableCollection<Group<Item>>();
        }

        public async void Init()
        {
            foreach (var service in _dataServices)
            {
                var items = await service.GetItems();

                if (items != null && items.Count > 0)
                {
                    var group = new Group<Item>(items[0].Group, items);

                    _groupedItems.Add(group);
                }
            }
        }

        public ObservableCollection<Group<Item>> ItemGroups
        {
            get { return _groupedItems; }
        }
    }
}
