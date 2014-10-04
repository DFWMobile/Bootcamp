using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cirrious.CrossCore.Platform;
using DFWMobile.Bootcamp.Common.Models;
using DFWMobile.Bootcamp.Common.Services;
using DFWMobile.Bootcamp.Common.Settings;
using DFWMobile.Bootcamp.Core.Helpers;

namespace DFWMobile.Bootcamp.Core.ViewModels
{
    public class GeoGroupDetailsViewModel
        : GroupDetailsViewModel
    {
        public GeoGroupDetailsViewModel(IAppSettings appSettings, IDataServiceFactory dataServiceFactory, IMvxResourceLoader resourceLoader)
            : base(appSettings, dataServiceFactory, resourceLoader)
        {
            SelectedItem = new GeoItem
            {
                Longitude = -147.9315,
                Latitude = 60.4371
            };
        }


        public async Task Init(string group, string title)
        {
            IsBusy = true;
            var dataSource = DataServiceFactoryHelper.DataSources.FirstOrDefault(ds => ds.ServiceName == group);

            if (dataSource != null)
            {
                DataService = DataServiceFactory.GenerateService(dataSource);
                RaisePropertyChanged(() => GroupName);
                var items = await DataService.GetItems();
                SelectedGroup.Clear();
                SelectedGroup.Add(new Group<Item>(dataSource.ServiceName, items));

                if (!string.IsNullOrWhiteSpace(title))
                {
                    SelectedItem = items.FirstOrDefault(i => i.Title == title);
                }

                if (SelectedItem == null)
                {
                    SelectedItem = items.FirstOrDefault();
                }
                IsEditable = DataService.IsEditable;
                RaisePropertyChanged(() => SelectedGroup);
                RaisePropertyChanged(() => Items);
            }
            IsBusy = false;
        }
        public ObservableCollection<GeoItem> Items
        {
            get
            {
                if (SelectedGroup.Count == 0)
                    return new ObservableCollection<GeoItem>();
                
                return new ObservableCollection<GeoItem>(from item in SelectedGroup.FirstOrDefault()
                                                             select (GeoItem) item);
            }
        }
    }
}
