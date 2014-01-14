using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFWMobile.Bootcamp.Common.Services
{
    public interface IDataServiceFactory
    {
        IDataService GenerateService(IDataSource source);
    }
}
