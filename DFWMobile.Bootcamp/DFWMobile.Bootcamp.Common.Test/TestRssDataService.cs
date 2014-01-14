using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cirrious.MvvmCross.Test.Core;
using DFWMobile.Bootcamp.Common.Services;
using Moq;
using NUnit.Framework;
using Refractored.MvxPlugins.Settings;

namespace DFWMobile.Bootcamp.Common.Test
{
    [TestFixture]
    public class TestRssDataService
        : MvxIoCSupportingTest
    {

        
        private IDataService _dataService;
        [SetUp]
        public void SetupTests()
        {
            ClearAll();

            var settings = new Mock<IAppSettings>();
            settings.SetupProperty(s => s.DateFormatString, "ddd, d MMM yyyy");
            settings.SetupProperty(s => s.AutoPlayYoutubeVideos, true);
            settings.SetupProperty(s => s.ForceYoutubeVideosToLoadFullScreen, true);
            settings.SetupProperty(s => s.RssMaxItemsPerFeed, 30);

            var dataSource = new Mock<IDataSource>();
            dataSource.SetupProperty(ds => ds.ServiceName, "YouTube Playlist");
            dataSource.SetupProperty(ds => ds.ServiceUri, "http://gdata.youtube.com/feeds/api/playlists/PLif6_xhXJh4T8tuU8gxFxhK1H8S40n9HZ?alt=rss&max-results=50&start-index=1");


            _dataService = new RssDataService(dataSource.Object, settings.Object);
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
