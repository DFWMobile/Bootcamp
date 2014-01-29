using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DFWMobile.Bootcamp.Common.DataSources;
using DFWMobile.Bootcamp.Common.Models;
using Microsoft.WindowsAzure.MobileServices;

namespace DFWMobile.Bootcamp.Common.Services
{
    public class AzureMobileDataService
        : IDataService
    {
        private AzureMobileDataSource _azureDataSource;
        private static MobileServiceClient _mobileServiceClient;
        public AzureMobileDataService(IDataSource dataSource)
        {
            Source = dataSource;
            _azureDataSource = dataSource as AzureMobileDataSource;

            if (_mobileServiceClient == null)
            {
                _mobileServiceClient = new MobileServiceClient(Source.ServiceUri, _azureDataSource.ApplicationKey);
            }

            _itemTable = _mobileServiceClient.GetTable<Item>();
        }

        private readonly IMobileServiceTable<Item> _itemTable;

        public IDataSource Source { get; private set; }
        public async Task<List<Item>> GetItems()
        {
            return await _itemTable.ToListAsync();
        }

        public async Task<bool> Add(Item item)
        {
            await _itemTable.InsertAsync(item);

            return true;
        }

        public async Task<bool> Delete(Item item)
        {
            await _itemTable.DeleteAsync(item);

            return true;
            
        }

        public bool IsEditable { get { return true; } }
    }
}
