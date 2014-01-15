using Cirrious.MvvmCross.ViewModels;
using DFWMobile.Bootcamp.Common.Services;

namespace DFWMobile.Bootcamp.Core.ViewModels
{
    public class FirstViewModel 
		: MvxViewModel
    {
        private IDataServiceFactory _dataServiceFactory;
        public FirstViewModel(IDataServiceFactory dataServiceFactory)
        {
            _dataServiceFactory = dataServiceFactory;
        }

		private string _hello = "Hello MvvmCross";
        public string Hello
		{ 
			get { return _hello; }
			set { _hello = value; RaisePropertyChanged(() => Hello); }
		}
    }
}
