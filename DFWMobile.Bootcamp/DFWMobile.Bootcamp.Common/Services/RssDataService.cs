using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using DFWMobile.Bootcamp.Common.Models;
using Refractored.MvxPlugins.Settings;

namespace DFWMobile.Bootcamp.Common.Services
{
    public class RssDataService
        : IDataService
    {
        private const string _userAgent = "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; WOW64; Trident/6.0)";
        private HttpClient _httpClient;
        private IDataSource _dataSource;
        private IAppSettings _appSettings;
        public RssDataService(IDataSource source, IAppSettings appSettings)
        {
            _httpClient = new HttpClient();
            _dataSource = source;
            _appSettings = appSettings;
        }
        public async Task<List<Item>> GetItems()
        {
            var items = await Parse();
            return items.ToList();
        }


        public async Task<IEnumerable<Item>> Parse()
        {
            _httpClient.DefaultRequestHeaders.Add("user-agent", _userAgent);

            var response = await _httpClient.GetStringAsync(_dataSource.ServiceUri);

            XNamespace xmlns = "http://www.w3.org/2005/Atom";
            XNamespace media = "http://search.yahoo.com/mrss/";

            var feed = XDocument.Parse(response);

            string group = _dataSource.ServiceName.Length > 1 ? _dataSource.ServiceName : feed.Descendants("channel").Select(e => (string)e.Element("title").Value).First();

            IEnumerable<Item> items = new List<Item>();

            if (_dataSource.ServiceUri.StartsWith("http://gdata.youtube.com/feeds/api/playlists/"))  //parse Youtube Playlist RSS 
            {
                //0 is link, 1 is image, 2 is title, 3 is description
                string youtubeHtmlTemplate = "<p><a href=\"{0}\"><img src=\"{1}\" alt=\"\" width=300></a></p><p><a style=\"font-size: 15px; font-weight: bold; font-decoration: none;\" href=\"{0}\">{2}</a></p><p>{3}</p>";

                items = from item in feed.Descendants("item")
                        select new Item()
                        {
                            Title = item.Element("title").Value,
                            Subtitle = item.Element("pubDate").Value,
                            Description = item.Descendants(media + "thumbnail").Count() > 0 ? string.Format(youtubeHtmlTemplate, item.Element("link").Value, item.Descendants(media + "thumbnail").Select(e => (string)e.Attribute("url")).FirstOrDefault(), item.Element("title").Value, item.Element("description").Value.Substring(0, Math.Min(580, item.Element("description").Value.Length))) : string.Empty,
                            Image = item.Descendants(media + "thumbnail") != null ? item.Descendants(media + "thumbnail").Select(e => (string)e.Attribute("url")).FirstOrDefault() : string.Empty,
                            Group = @group,
                        };

                items = items.Where(x => x.Description != string.Empty);
            }
            else
            {
                string audio_template = "<audio src=\"{0}\" controls autoplay>Your browser does not support the <code>audio</code> element.<br/><a href=\"{0}\">Link to file</a>.</audio><br/>";
                var feeditems = _appSettings.RssMaxItemsPerFeed < 0
                    ? feed.Descendants("item")
                    : feed.Descendants("item").Take(_appSettings.RssMaxItemsPerFeed);
                items = from item in feeditems
                        select new Item()
                        {
                            Title = item.Element("title") != null ? item.Element("title").Value : string.Empty,
                            Subtitle = item.Element("pubDate") != null ? item.Element("pubDate").Value : string.Empty,
                            Description =
                                // TODO: perhaps this needs to use the url's MIME type to determine the tag for audio, video, PDFs, etc.?
                                  (item.Element("enclosure") != null
                                    ? string.Format(audio_template, (string)(item.Element("enclosure").Attribute("url")))
                                    : string.Empty)
                                + (item.Element("description") != null
                                    ? (string)(item.Element("description").Value)
                                    : string.Empty),
                            Image = item.Descendants(media + "thumbnail") != null ? item.Descendants(media + "thumbnail").Select(e => (string)e.Attribute("url")).FirstOrDefault() : "",
                            Group = @group,
                        };
            }

            if (items.ToList().Count > 0)
            {

                foreach (var item in items)
                {
                    if (item.Image == null) //Attempt to parse an image out of the description if one is not returned in the RSS
                        item.Image = Regex.Match(item.Description, "(https?:)?//?[^'\"<>]+?.(jpg|jpeg|gif|png)").Value;

                    if (item.Image == string.Empty) //Unable to locate any image, so fallback to logo
                        item.Image = "/Assets/Logo.png";

                    //Format dates to look cleaner
                    var dateTimeResult = new DateTime();
                    if (DateTime.TryParse(item.Subtitle, out dateTimeResult))
                        item.Subtitle = dateTimeResult.ToString();

                    if (_appSettings.ForceYoutubeVideosToLoadFullScreen)
                        item.Description = item.Description.Replace("/watch?v=", "/watch_popup?v=");
                };
            }
            else
            {
                throw new Exception("Zero items retrieved from " + _dataSource.ServiceUri + ", Application Error");
            }

            return items;
        }

        /// <summary>
        /// Remove any whitespace or quotes from an RssSource field.
        /// </summary>
        private string cleanField(string strFld)
        {
            return (strFld.Trim().Trim('"'));
        }
    }
}
