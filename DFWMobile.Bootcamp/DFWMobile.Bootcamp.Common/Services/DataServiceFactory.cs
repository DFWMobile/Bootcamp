using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cirrious.CrossCore.Platform;
using DFWMobile.Bootcamp.Common.DataSources;
using DFWMobile.Bootcamp.Common.Settings;

namespace DFWMobile.Bootcamp.Common.Services
{
    public class DataServiceFactory
        : IDataServiceFactory
    {
        private readonly IAppSettings _appSettings;
        private readonly IMvxResourceLoader _resourceLoader;

        public DataServiceFactory(IAppSettings appSettings, IMvxResourceLoader resourceLoader)
        {
            _appSettings = appSettings;
            _resourceLoader = resourceLoader;
        }
        public IDataService GenerateService(IDataSource source)
        {
            IDataService service = null;
            if (source is RssDataSource)
            {
                service = new RssDataService((RssDataSource) source, _appSettings);
            }
            else if (source is LocalDataSource)
            {
                service = new LocalDataService(source, _appSettings, _resourceLoader);
            }
            else if (source is RemoteDataSource)
            {
                service = new RemoteDataService(source, _appSettings);
            }

            return service;
        }
    }
}
