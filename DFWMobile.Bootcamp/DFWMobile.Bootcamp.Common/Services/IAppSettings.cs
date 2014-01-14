using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFWMobile.Bootcamp.Common.Services
{
    public interface IAppSettings
    {
        int RssMaxItemsPerFeed { get; }
        bool ForceYoutubeVideosToLoadFullScreen { get; }
        bool AutoPlayYoutubeVideos { get; }
        string DateFormatString { get; set; }
    }
}
