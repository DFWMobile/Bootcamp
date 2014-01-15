using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Cirrious.CrossCore.Platform;
using DFWMobile.Bootcamp.Common.Models;

namespace DFWMobile.Bootcamp.Common.Services
{
    public class RemoteDataService
        : ItemDataService, IDataService
    {
        private HttpClient _httpClient;
        private IAppSettings _appSettings;
        private IDataSource _dataSource;
        public RemoteDataService(IDataSource dataSource, IAppSettings appSettings)
        {
            _appSettings = appSettings;
            _dataSource = dataSource;

            _httpClient = new HttpClient();
        }
        public IDataSource Source
        { 
            get { return _dataSource; }
        }

        public async Task<List<Item>> GetItems()
        {
            var remoteItemsXml = await _httpClient.GetStringAsync(_dataSource.ServiceUri);

            return ParseItems(remoteItemsXml, _dataSource.ServiceName);
        }
    }
}
