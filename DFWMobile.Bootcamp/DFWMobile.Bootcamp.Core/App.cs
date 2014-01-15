using System.Reflection;
using Cirrious.CrossCore;
using Cirrious.CrossCore.IoC;
using DFWMobile.Bootcamp.Common.Services;

namespace DFWMobile.Bootcamp.Core
{
    public class App : Cirrious.MvvmCross.ViewModels.MvxApplication
    {
        public override void Initialize()
        {
            var type = typeof (IDataServiceFactory);
            var asm = type.AssemblyQualifiedName;
           
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            Mvx.RegisterType(typeof(IAppSettings), typeof(AppSettings));
            Mvx.RegisterType(typeof(IDataServiceFactory), typeof(DataServiceFactory));
				
            RegisterAppStart<ViewModels.FirstViewModel>();
        }
    }
}