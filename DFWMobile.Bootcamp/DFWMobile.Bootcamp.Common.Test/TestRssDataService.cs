using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DFWMobile.Bootcamp.Common.Services;
using NUnit.Framework;
using Refractored.MvxPlugins.Settings;

namespace DFWMobile.Bootcamp.Common.Test
{
    [TestFixture]
    public class TestRssDataService
    {
        private ISettings _settings;
        private IDataService _dataService;
        private RssDataSource _dataSource;
        private IAppSettings _appSettings;
        [SetUp]
        public void Setup()
        {
            _settings = new TestSettings()
            {
                {"RssMaxItemsPerFeed", 20}
            };
            _dataSource = new RssDataSource()
            {
                ServiceName = "YouTube Playlist",
                ServiceUri =
                    "http://gdata.youtube.com/feeds/api/playlists/PLif6_xhXJh4T8tuU8gxFxhK1H8S40n9HZ?alt=rss&max-results=50&start-index=1"
            };

            _appSettings = new AppSettings(_settings);
            _dataService = new RssDataService(_dataSource, _appSettings);
        }

        [Test]
        public async void TestGetItems()
        {
            var items = await _dataService.GetItems();

            Assert.IsNotNull(items);
            Assert.IsTrue(items.Count > 0);

            foreach (var item in items)
            {
                Assert.IsNotNullOrEmpty(item.Title);
                Assert.IsNotNullOrEmpty(item.Image);
                Assert.IsNotNullOrEmpty(item.Description);
                Assert.IsNotNullOrEmpty(item.Group);
            }
        }
    }
}
