using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DFWMobile.Bootcamp.Common.DataSources;
using DFWMobile.Bootcamp.Common.Services;

namespace DFWMobile.Bootcamp.Core.Helpers
{
    internal class DataServiceFactoryHelper
    {
        private static List<IDataSource> _dataSources; 
        static DataServiceFactoryHelper()
        {
            _dataSources = new List<IDataSource>()
            {
                new JsonDataSource()
                {
                    ServiceUri = "local.json",
                    ServiceName = "Local JSON File"
                },
                new RssDataSource()
                {
                    ServiceUri =
                        "http://gdata.youtube.com/feeds/api/playlists/PLR6WI6W1JdeYSXLbm58jwAKYT7RQR31-W?alt=rss&max-results=50&start-index=1",
                    ServiceName = "Youtube Playlist Example"
                },
                new RssDataSource()
                {
                    ServiceUri = "http://gdata.youtube.com/feeds/base/videos?alt=rss&author=thewindotnet",
                    ServiceName = "Youtube author example"
                },
                new RssDataSource()
                {

                    ServiceUri = "https://www.facebook.com/feeds/page.php?format=rss20&id=487598667939827",
                    ServiceName = "Facebook Example"
                },
                new RssDataSource()
                {
                    ServiceUri = "http://api.flickr.com/services/feeds/photos_public.gne?format=rss&tags=cats",
                    ServiceName = "Flickr Example"

                },
                new RssDataSource()
                {
                    ServiceUri =
                        "http://gdata.youtube.com/feeds/api/playlists/PL976D5FEB096858B1?alt=rss&max-results=50&start-index=1",
                    ServiceName = "Youtube Playlist Example"
                },
                new RssDataSource()
                {
                    ServiceUri = "http://gdata.youtube.com/feeds/base/videos?alt=rss&q=xbox%20one",
                    ServiceName = "Youtube query example"
                },

            };
        }

        public static List<IDataSource> DataSources { get { return _dataSources; } }
    }
}
