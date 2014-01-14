using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Refractored.MvxPlugins.Settings;

namespace DFWMobile.Bootcamp.Common.Services
{
    public class AppSettings
        : IAppSettings
    {
        private ISettings _settings;

        public AppSettings(ISettings settings)
        {
            _settings = settings;
        }

        public int RssMaxItemsPerFeed
        {
            get { return _settings.GetValueOrDefault<int>("RssMaxItemsPerFeed", 20); }
            set { _settings.AddOrUpdateValue("RssMaxItemsPerFeed", value); _settings.Save(); }
        }

        public bool ForceYoutubeVideosToLoadFullScreen
        {
            get { return _settings.GetValueOrDefault<bool>("ForceYoutubeVideosToLoadFullScreen", true); }
            set { _settings.AddOrUpdateValue("ForceYoutubeVideosToLoadFullScreen", value); _settings.Save(); }
        }

        public bool AutoPlayYoutubeVideos
        {
            get { return _settings.GetValueOrDefault<bool>("AutoPlayYoutubeVideos", true); }
            set { _settings.AddOrUpdateValue("AutoPlayYoutubeVideos", value); _settings.Save(); }
        }

        public string DateFormatString
        {
            get { return _settings.GetValueOrDefault<string>("DateFormatString", "ddd, d MMM yyyy"); }
            set { _settings.AddOrUpdateValue("DateFormatString", value); _settings.Save(); }
        }
    }
}
