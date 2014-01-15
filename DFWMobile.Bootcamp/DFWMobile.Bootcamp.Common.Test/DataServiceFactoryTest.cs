﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cirrious.CrossCore.Platform;
using Cirrious.MvvmCross.Test.Core;
using DFWMobile.Bootcamp.Common.DataSources;
using DFWMobile.Bootcamp.Common.Services;
using DFWMobile.Bootcamp.Common.Settings;
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

            var resourceLoader = new Mock<IMvxResourceLoader>();
            resourceLoader.Setup(r => r.GetTextResource(It.IsAny<string>())).Returns("<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?>" +
                                                                                     "<items xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\">" +
                                                                                     "<item>" +
                                                                                     "<title>If you see me, \"LocalItemsFile\" is enabled!</title>" +
                                                                                     "<subtitle>Warning</subtitle>" +
                                                                                     "<description>To disable, set \"EnableLocalItemsFile = false\" in AppSettings.cs &lt;/br&gt;&lt;a href=\"http://bing.com\"&gt;By the way, I am html, click me and I'll take you to Bing&lt;/a&gt;</description>" +
                                                                                     "<image>http://www.irunoninsulin.com/wp-content/uploads/2010/06/green-check-mark.jpg</image>" +
                                                                                     "<group>Local Data</group>" +
                                                                                     "</item>" +
                                                                                     "<item>" +
                                                                                     "<title>Shi Tzu</title>" +
                                                                                     "<subtitle>small</subtitle>" +
                                                                                     "<description>A shih tzu is a toy dog breed weighing 5–7.25 kilograms with long silky hair. The breed originated in China. Shih Tzu were officially recognized by the American Kennel Club in 1969. The name is both singular and plural.</description>" +
                                                                                     "<image>http://us.123rf.com/400wm/400/400/isselee/isselee0906/isselee090600219/5085394-grey-shih-tzu-6-years-old-in-front-of-a-white-background.jpg</image>" +
                                                                                     "<group>Dog</group>" +
                                                                                     "</item>" +
                                                                                     "<item>" +
                                                                                     "<title>HTML Example</title>" +
                                                                                     "<subtitle>This uses JavaScript, too!</subtitle>" +
                                                                                     "<description>&lt;html&gt; &lt;body&gt; &lt;font face = \"Comic Sans MS\"&gt; &lt;font size=5&gt;There are all kinds of &lt;font color=\"blue\"&gt;&lt;i&gt;super fun&lt;/i&gt;&lt;/font&gt; things you can do with HTML in your XML files. &lt;br&gt;&lt;font size=3&gt;You can use http://htmledit.squarefree.com to preview your HTML. Then you can use Notepad++ to condense it all into one line easily. Just select all the text and press Ctrl+J for Join Lines in Notepad++. (It's also in the Edit menu under Line Operations.)&lt;br&gt;&lt;br&gt;  &lt;p id=\"demo\"&gt;Hey, what day is it??&lt;/p&gt; &lt;button onclick=\"myFunction()\"&gt;JavaScript Button&lt;/button&gt; &lt;script&gt; function myFunction() { var d = new Date(); var weekday=new Array(7); weekday[0]=\"It's Sunday\"; weekday[1]=\"It's Monday\"; weekday[2]=\"It's Tuesday\"; weekday[3]=\"It's Wednesday\"; weekday[4]=\"It's Thursday\"; weekday[5]=\"It's Friday\"; weekday[6]=\"It's Saturday\";  var x = document.getElementById(\"demo\"); x.innerHTML=weekday[d.getDay()]; } &lt;/script&gt;  &lt;br&gt;&lt;br&gt;&lt;br&gt; &lt;font face = \"Arial\"&gt; If you want to link to websites within your app, you can add &lt;font color=\"red\"&gt;target=_blank&lt;/font&gt; to your URL links and change the AppSettings.cs file to allow for it. By default, it is disabled. &lt;br&gt;&lt;br&gt; It's also helpful to know that you can use Excel to edit your XML files, but you don't have to. Sometimes Excel just gets in the way and it'd be easier to use something like Notepad++ to edit the code directly. But you have to remember that things need to be converted first. Use this website to convert things:&lt;br&gt;https://sites.google.com/site/infivivek/resourse-centre/online-resources/html-to-xml-converter &lt;br&gt;But if you do use Excel, make sure you copy all the HTML into the one line for the description. It might help to double-click the cell and then paste it. &lt;br&gt;&lt;br&gt; &lt;font face=\"Courier New\"&gt; Also, you can make your own RSS feeds for your website, even free Google sites. Then you can write up your own XML file to upload (much like this file) using this guide:&lt;br&gt;http://www.w3schools.com/rss/rss_tag_image.asp&lt;br&gt;If you use your own RSS feed, make sure there is an image somewhere in the HTML in the description (even if it's at the bottom of the page), and it'll show up in your app (both on the main page and the sub page). &lt;br&gt;&lt;br&gt;&lt;center&gt; You can even make tables. And center them. &lt;table border=\"1\"&gt;   &lt;tr&gt;     &lt;th&gt;Column 1&lt;/th&gt;     &lt;th&gt;Column 2&lt;/th&gt;   &lt;/tr&gt;   &lt;tr&gt;     &lt;td&gt;Row 1&lt;/td&gt;     &lt;td&gt;abcde&lt;/td&gt;   &lt;/tr&gt;   &lt;tr&gt;   &lt;td&gt;Row 2&lt;/td&gt;   &lt;td&gt;fghij&lt;/td&gt;   &lt;/tr&gt; &lt;/table&gt; &lt;/center&gt; &lt;br&gt;&lt;br&gt;  Or you can &lt;a href=\"http://www.dominos.com\" target=_blank&gt;click here&lt;/a&gt; to order Dominos pizza. If you leave default settings on, you'll be ordering the pizza from within the app, but if you change AppSettings.cs like mentioned earlier, it'll open a new window. Or you could just call them at (713) 747-3800.  &lt;br&gt;&lt;br&gt; ...and this is &lt;b&gt;&lt;font color=\"green\"&gt;&lt;font size=5&gt;just the beginning.&lt;/font&gt;&lt;/font&gt;&lt;/b&gt; What else can &lt;b&gt;you&lt;/b&gt; think of to do?&lt;br&gt; &lt;br&gt;&lt;center&gt; &lt;img src=\"http://3.bp.blogspot.com/--P7JWhCCr1A/UecFPgmGWlI/AAAAAAAAGWg/P9Tor4nWi2A/s1600/madden-divider-line.png\" width=\"500\" height=\"15\" alt=\"border\"&gt; &lt;font size=2&gt;&lt;br&gt;If you find an image you like online, you can right-click and copy the URL and also view the image info to see the pixel dimensions--all without downloading it. &lt;/center&gt; &lt;/font&gt; &lt;/body&gt; &lt;/html&gt;</description>" +
                                                                                     "<image>http://101fundraising.org/wp-content/uploads/2013/09/lightbulb.gif</image>" +
                                                                                     "<group>HTML</group>" +
                                                                                     "</item>" +
                                                                                     "</items>");

            _dataServiceFactory = new DataServiceFactory(settings.Object, resourceLoader.Object);
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
                },
                new LocalDataSource()
                {
                    ServiceUri = "/Assets/Items.xml"
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

                if (dataService.Source.ServiceUri == "/Assets/Items.xml")
                {
                    Assert.AreEqual(3, items.Count);
                    Assert.AreEqual("If you see me, \"LocalItemsFile\" is enabled!", items[0].Title);
                    Assert.AreEqual("Warning", items[0].Subtitle);
                    Assert.AreEqual("To disable, set \"EnableLocalItemsFile = false\" in AppSettings.cs </br><a href=\"http://bing.com\">By the way, I am html, click me and I'll take you to Bing</a>", items[0].Description);
                    Assert.AreEqual("http://www.irunoninsulin.com/wp-content/uploads/2010/06/green-check-mark.jpg", items[0].Image);
                    Assert.AreEqual("Local Data", items[0].Group);
                    Assert.AreEqual("Shi Tzu", items[1].Title);
                    Assert.AreEqual("small", items[1].Subtitle);
                    Assert.AreEqual("HTML Example", items[2].Title);
                }
            }
        }
    }
}
