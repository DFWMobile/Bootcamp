using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFWMobile.Bootcamp.Common.Services
{
    public interface IAppSettings
    {
        int RssMaxItemsPerFeed { get; set; }
        bool ForceYoutubeVideosToLoadFullScreen { get; set; }
        bool AutoPlayYoutubeVideos { get; set; }
        string DateFormatString { get; set; }
    }
}
