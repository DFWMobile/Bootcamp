using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Cirrious.CrossCore.Platform;
using Cirrious.MvvmCross.ViewModels;
using DFWMobile.Bootcamp.Common.DataSources;
using DFWMobile.Bootcamp.Common.Models;
using DFWMobile.Bootcamp.Common.Services;
using DFWMobile.Bootcamp.Common.Settings;
using DFWMobile.Bootcamp.Core.Helpers;

namespace DFWMobile.Bootcamp.Core.ViewModels
{
    public class GroupedItemsViewModel
        : BaseViewModel
    {
        private IDataServiceFactory _dataServiceFactory;
        private readonly List<IDataService> _dataServices;
        private readonly IMvxResourceLoader _resourceLoader;
        private readonly ObservableCollection<Group<Item>> _groupedItems; 
        public GroupedItemsViewModel(IAppSettings appSettings, IDataServiceFactory dataServiceFactory, IMvxResourceLoader resourceLoader)
            : base(appSettings)
        {
            _dataServiceFactory = dataServiceFactory;
            _resourceLoader = resourceLoader;

            _dataServices = new List<IDataService>();
            foreach (var source in DataServiceFactoryHelper.DataSources)
            {
                _dataServices.Add(_dataServiceFactory.GenerateService(source));
            }

            _groupedItems = new ObservableCollection<Group<Item>>();
        }

        public async void Init()
        {
            IsBusy = true;
            foreach (var service in _dataServices)
            {
                var items = await service.GetItems();

                if (items != null && items.Count > 0)
                {
                    var group = new Group<Item>(items[0].Group, items);

                    _groupedItems.Add(group);
                }
            }
            IsBusy = false;
        }

        private bool _isBusy = false;

        public bool IsBusy
        {
            get { return _isBusy; }
            set { _isBusy = value; RaisePropertyChanged(() => IsBusy); }
        }

        public ObservableCollection<Group<Item>> ItemGroups
        {
            get { return _groupedItems; }
        }

        private ICommand _goToGroupCommand;

        public ICommand GoToGroupCommand
        {
            get
            {
                return (_goToGroupCommand = _goToGroupCommand ??
                                            new MvxCommand<Item>(
                                                (item) => GoToGroupDetails(item)));
            }
        }

        private ICommand _goToItemCommand;

        public ICommand GoToItemCommand
        {
            get
            {
                return (_goToItemCommand = _goToItemCommand ??
                                            new MvxCommand<Item>(
                                                (group) => ShowViewModel<GroupDetailsViewModel>(new { group = group })));
            }
        }

        private void GoToGroupDetails(Item item)
        {
            ShowViewModel<GroupDetailsViewModel>(new { group = item.Group, title = item.Title });
        }
    }
}
