using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cirrious.MvvmCross.Test.Core;
using DFWMobile.Bootcamp.Common.Services;
using Moq;
using NUnit.Framework;

namespace DFWMobile.Bootcamp.Common.Test
{
    public class DataServiceFactoryTest
        : MvxIoCSupportingTest
    {
        private IDataServiceFactory _dataServiceFactory;
        [SetUp]
        public void SetupTests()
        {
            ClearAll();

            var settings = new Mock<IAppSettings>();
            settings.SetupProperty(s => s.DateFormatString, "ddd, d MMM yyyy");
            settings.SetupProperty(s => s.AutoPlayYoutubeVideos, true);
            settings.SetupProperty(s => s.ForceYoutubeVideosToLoadFullScreen, true);
            settings.SetupProperty(s => s.RssMaxItemsPerFeed, 30);

            _dataServiceFactory = new DataServiceFactory(settings.Object);
        }

        [Test]
        public void TestGenerateService()
        {
            var rssDataSource = new RssDataSource()
            {
                ServiceName =  "YouTube Playlist",
                ServiceUri = "http://gdata.youtube.com/feeds/api/playlists/PLif6_xhXJh4T8tuU8gxFxhK1H8S40n9HZ?alt=rss&max-results=50&start-index=1"
            };
            var dataService = _dataServiceFactory.GenerateService(rssDataSource);

            Assert.IsNotNull(dataService);
            Assert.IsAssignableFrom<RssDataService>(dataService);
        }

        [Test]
        public async void TestUsingGeneratedServices()
        {
            var dataSources = new List<IDataSource>()
            { 
                new RssDataSource()
                {
                    ServiceName = "YouTube Playlist",
                    ServiceUri = "http://gdata.youtube.com/feeds/api/playlists/PLif6_xhXJh4T8tuU8gxFxhK1H8S40n9HZ?alt=rss&max-results=50&start-index=1"
                },
                new RssDataSource()
                {
                    ServiceName = "YouTube Query",
                    ServiceUri = "http://gdata.youtube.com/feeds/base/videos?alt=rss&q=xbox%20one"
                },
                new RssDataSource()
                {
                    ServiceName = "Facebook Group",
                    ServiceUri = "https://www.facebook.com/feeds/page.php?format=rss20&id=487598667939827"
                }
            };

            var dataServices = new List<IDataService>();

            foreach (var source in dataSources)
            {
                dataServices.Add(_dataServiceFactory.GenerateService(source));
            }

            foreach (var dataService in dataServices)
            {
                var items = await dataService.GetItems();

                Assert.IsNotNull(items, "Service: {0} Failed", dataService.Source.ServiceName);
                Assert.IsTrue(items.Count > 0);

                foreach (var item in items)
                {
                    Assert.IsNotNullOrEmpty(item.Title, "Service: {0} Title Failed", dataService.Source.ServiceName);
                    Assert.IsNotNullOrEmpty(item.Description, "Service: {0} Description Failed", dataService.Source.ServiceName);
                    Assert.IsNotNullOrEmpty(item.Group, "Service: {0} Group Failed", dataService.Source.ServiceName);

                    // YouTube Queries don't have images for some reason?
                    // Neither does facebook?
                    if (dataService.Source.ServiceName != "YouTube Query" && dataService.Source.ServiceName != "Facebook Group")
                        Assert.IsNotNullOrEmpty(item.Image, "Service: {0} Image Failed", dataService.Source.ServiceName);
                }
                
            }
        }
    }
}
