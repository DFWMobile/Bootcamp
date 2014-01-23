using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using Cirrious.CrossCore.Platform;
using Cirrious.MvvmCross.ViewModels;
using DFWMobile.Bootcamp.Common.Models;
using DFWMobile.Bootcamp.Common.Services;
using DFWMobile.Bootcamp.Common.Settings;
using DFWMobile.Bootcamp.Core.Helpers;

namespace DFWMobile.Bootcamp.Core.ViewModels
{
    public class GroupDetailsViewModel
        : BaseViewModel
    {
        private IDataServiceFactory _dataServiceFactory;
        private IDataService _dataService;
        private readonly IMvxResourceLoader _resourceLoader;
        private readonly ObservableCollection<Group<Item>> _groupedItems; 
        public GroupDetailsViewModel(IAppSettings appSettings, IDataServiceFactory dataServiceFactory, IMvxResourceLoader resourceLoader)
            : base(appSettings)
        {
            _dataServiceFactory = new DataServiceFactory(appSettings, _resourceLoader);
            _resourceLoader = resourceLoader;
            _groupedItems = new ObservableCollection<Group<Item>>();
        }

        public async void Init(string group, string title)
        {
            var dataSource = DataServiceFactoryHelper.DataSources.FirstOrDefault(ds => ds.ServiceName == group);

            if (dataSource != null)
            {
                _dataService = _dataServiceFactory.GenerateService(dataSource);
                var items = await _dataService.GetItems();
                SelectedGroup.Add(new Group<Item>(dataSource.ServiceName, items));

                if (!string.IsNullOrWhiteSpace(title))
                {
                    SelectedItem = items.FirstOrDefault(i => i.Title == title);
                }

                if (SelectedItem == null)
                {
                    SelectedItem = items.FirstOrDefault();
                }
            }
        }
        public ObservableCollection<Group<Item>> SelectedGroup
        {
            get { return _groupedItems; }
        }

        private Item _selectedItem;
        public Item SelectedItem
        {
            get { return _selectedItem; }
            set { _selectedItem = value; RaisePropertyChanged(() => SelectedItem); }
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

        private ICommand _addItemCommand;

        public ICommand AddItemCommand
        {
            get
            {
                return (_addItemCommand = _addItemCommand ??
                    new MvxCommand(() => ShowViewModel<AddItemViewModel>()));
            }
        }

        private void GoToGroupDetails(Item item)
        {
            ShowViewModel<GroupDetailsViewModel>(new { group = item.Group, title = item.Title });
        }
    }
}
