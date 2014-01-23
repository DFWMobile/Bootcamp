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
        public JsonDataService(IMvxFileStore fileStore, IMvxJsonConverter jsonConverter)
        {
            _fileStore = fileStore;
            _jsonConverter = jsonConverter;
        }

        public IDataSource Source { get; private set; }
        public async Task<List<Item>> GetItems()
        {
            var items = new List<Item>();

            if (_fileStore.Exists(Source.ServiceUri))
            {
                string contents;
                if (_fileStore.TryReadTextFile(Source.ServiceUri, out contents))
                {
                    _jsonConverter.DeserializeObject<List<Item>>(contents);
                }
            }

            return await Task.Factory.StartNew(() => items)
                .ConfigureAwait(true);
        }
    }
}
