using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cirrious.CrossCore.Platform;
using Cirrious.MvvmCross.ViewModels;
using DFWMobile.Bootcamp.Common.Models;
using DFWMobile.Bootcamp.Common.Services;
using DFWMobile.Bootcamp.Common.Settings;

namespace DFWMobile.Bootcamp.Core.ViewModels
{
    public class AddItemViewModel
        : BaseViewModel
    {
        private IDataServiceFactory _dataServiceFactory;
        private IDataService _dataService;
        public AddItemViewModel(IAppSettings appSettings, IDataServiceFactory dataServiceFactory, IMvxResourceLoader resourceLoader)
            : base(appSettings)
        {
            _dataServiceFactory = new DataServiceFactory(appSettings, resourceLoader);
            _item = new Item();
        }

        private Item _item;

        public void Init()
        {
        }

        public string Title
        {
            get { return _item.Title; }
            set { _item.Title = value; RaisePropertyChanged(() => Title); }
        }

        public string Subtitle
        {
            get { return _item.Subtitle; }
            set { _item.Subtitle = value; RaisePropertyChanged(() => Subtitle); }
        }

        public string Description
        {
            get { return _item.Description; }
            set { _item.Description = value; RaisePropertyChanged(() => Description); }
        }

        public string Image
        {
            get { return _item.Image; }
            set { _item.Image = value; RaisePropertyChanged(() => Image); }
        }

        public string Group
        {
            get { return _item.Group; }
            set { _item.Group = value; RaisePropertyChanged(() => Group); }
        }
    }
}
