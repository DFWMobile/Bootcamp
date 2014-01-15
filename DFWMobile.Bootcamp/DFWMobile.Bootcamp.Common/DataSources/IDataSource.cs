using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFWMobile.Bootcamp.Common.DataSources
{
    public interface IDataSource
    {
        string ServiceUri { get; set; }
        string ServiceName { get; set; }
    }
}
