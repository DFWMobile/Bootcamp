using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cirrious.CrossCore.Platform;
using DFWMobile.Bootcamp.Common.DataSources;
using DFWMobile.Bootcamp.Common.Models;
using DFWMobile.Bootcamp.Common.Settings;

namespace DFWMobile.Bootcamp.Common.Services
{
    public class LocalDataService
        : ItemDataService, IDataService
    {
        private IAppSettings _appSettings;
        private readonly IMvxResourceLoader _resourceLoader;
        private readonly IDataSource _dataSource;
        public LocalDataService(IDataSource dataSource, IAppSettings appSettings, IMvxResourceLoader resourceLoader)
        {
            _appSettings = appSettings;
            _resourceLoader = resourceLoader;
            _dataSource = dataSource;
        }
        public IDataSource Source
        { 
            get { return _dataSource; }
        }

        public async Task<List<Item>> GetItems()
        {
            return await Task.Factory.StartNew(() => Parse())
                .ConfigureAwait(true);
        }

        public Task<bool> Add(Item item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(Item item)
        {
            throw new NotImplementedException();
        }

        public bool IsEditable { get { return false; } }

        public List<Item> Parse()
        {
            var localItemsXml = _resourceLoader.GetTextResource(_dataSource.ServiceUri);

            return ParseItems(localItemsXml, _dataSource.ServiceName);
        }
    }
}
