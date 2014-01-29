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

        public GroupDetailsViewModel(IAppSettings appSettings, IDataServiceFactory dataServiceFactory,
            IMvxResourceLoader resourceLoader)
            : base(appSettings)
        {
            _dataServiceFactory = dataServiceFactory;
            _resourceLoader = resourceLoader;
            _groupedItems = new ObservableCollection<Group<Item>>();
        }

        public async void Init(string group, string title)
        {
            IsBusy = true;
            var dataSource = DataServiceFactoryHelper.DataSources.FirstOrDefault(ds => ds.ServiceName == group);

            if (dataSource != null)
            {
                _dataService = _dataServiceFactory.GenerateService(dataSource);
                RaisePropertyChanged(() => GroupName);
                var items = await _dataService.GetItems();
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
                IsEditable = _dataService.IsEditable;
            }
            IsBusy = false;
        }

        public ObservableCollection<Group<Item>> SelectedGroup
        {
            get { return _groupedItems; }
        }

        public string GroupName
        {
            get { return _dataService.Source.ServiceName; }
        }

        private Item _selectedItem;

        public Item SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                RaisePropertyChanged(() => SelectedItem);
            }
        }

        private ICommand _goToItemCommand;

        public ICommand GoToItemCommand
        {
            get
            {
                return (_goToItemCommand = _goToItemCommand ??
                                            new MvxCommand<Item>(
                                                (item) => SelectedItem = item));
            }
        }

        private ICommand _addItemCommand;

        public ICommand AddItemCommand
        {
            get
            {
                return (_addItemCommand = _addItemCommand ??
                                          new MvxCommand(
                                              () =>
                                                  ShowViewModel<AddItemViewModel>(
                                                      new {group = _dataService.Source.ServiceName})));
            }
        }

        private ICommand _deleteItemCommand;

        public ICommand DeleteItemCommand
        {
            get
            {
                return (_deleteItemCommand = _deleteItemCommand ??
                                             new MvxCommand(() => _dataService.Delete(SelectedItem)));
            }
        }

        private void GoToGroupDetails(Item item)
        {
            ShowViewModel<GroupDetailsViewModel>(new {group = item.Group, title = item.Title});
        }

        private ICommand _refreshCommand;

        public ICommand RefreshCommand
        {
            get { return (_refreshCommand = _refreshCommand ?? new MvxCommand(() => Init(SelectedItem.Group, null))); }
        }

        private bool _isEditable = false;
        public bool IsEditable
        {
            get { return _isEditable; }
            set { _isEditable = value; RaisePropertyChanged(() => IsEditable); }
        }
    }
}
