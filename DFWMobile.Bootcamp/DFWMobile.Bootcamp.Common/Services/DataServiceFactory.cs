using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFWMobile.Bootcamp.Common.Services
{
    public class DataServiceFactory
        : IDataServiceFactory
    {
        private IAppSettings _appSettings;

        public DataServiceFactory(IAppSettings appSettings)
        {
            _appSettings = appSettings;
        }
        public IDataService GenerateService(IDataSource source)
        {
            IDataService service = null;
            if (source is RssDataSource)
            {
                service = new RssDataService((RssDataSource) source, _appSettings);
            }

            return service;
        }
    }
}
