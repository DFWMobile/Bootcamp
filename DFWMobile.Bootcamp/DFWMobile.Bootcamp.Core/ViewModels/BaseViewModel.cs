using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Cirrious.MvvmCross.ViewModels;
using DFWMobile.Bootcamp.Common.Services;
using DFWMobile.Bootcamp.Common.Settings;

namespace DFWMobile.Bootcamp.Core.ViewModels
{
    public abstract class BaseViewModel
        : MvxViewModel
    {
        private IAppSettings _appSettings;
        public BaseViewModel(IAppSettings appSettings)
        {
            _appSettings = appSettings;
        }

        private ICommand _goBackCommand = null;
        private bool _isBusy = false;

        public ICommand GoBackCommand
        {
            get { return (_goBackCommand = _goBackCommand ?? new MvxCommand(() => this.Close(this))); }
        }

        public bool IsBusy
        {
            get { return _isBusy; }
            set { _isBusy = value; RaisePropertyChanged(() => IsBusy); }
        }
    }
}
