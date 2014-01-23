using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cirrious.CrossCore.Platform;
using Cirrious.MvvmCross.Plugins.File;
using DFWMobile.Bootcamp.Common.DataSources;
using DFWMobile.Bootcamp.Common.Models;

namespace DFWMobile.Bootcamp.Common.Services
{
    public class JsonDataService
        : IDataService
    {
        private IMvxFileStore _fileStore;
        private IMvxJsonConverter _jsonConverter;
        
        public JsonDataService(IDataSource dataSource, IMvxFileStore fileStore, IMvxJsonConverter jsonConverter)
        {
            _items = new List<Item>();
            _fileStore = fileStore;
            _jsonConverter = jsonConverter;
            Source = dataSource;
        }

        private List<Item> _items; 
        public IDataSource Source { get; private set; }
        public async Task<List<Item>> GetItems()
        {
            _items.Clear();

            if (_fileStore.Exists(Source.ServiceUri))
            {
                string contents;
                if (_fileStore.TryReadTextFile(Source.ServiceUri, out contents))
                {
                    _items.AddRange(
                        _jsonConverter.DeserializeObject<List<Item>>(contents));
                }
            }

            return await Task.Factory.StartNew(() => _items)
                .ConfigureAwait(true);
        }

        public async Task<bool> Add(Item item)
        {
            _items.Add(item);

            var result = Save();

            return await Task.Factory.StartNew(() => result)
                .ConfigureAwait(true);
        }

        public bool Save()
        {
            _fileStore.WriteFile(Source.ServiceUri, _jsonConverter.SerializeObject(_items));

            return true;
        }
    }
}
