using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cirrious.MvvmCross.ViewModels;
using DFWMobile.Bootcamp.Common.Services;

namespace DFWMobile.Bootcamp.Core.ViewModels
{
    public class BaseViewModel
        : MvxViewModel
    {
        private IAppSettings _appSettings;
        public BaseViewModel(IAppSettings appSettings)
        {
            _appSettings = appSettings;
        }

        public string PrivacyPolicyUrl
        {
            get { return _appSettings.PrivacyPolicyUrl; }
        }
    }
}
