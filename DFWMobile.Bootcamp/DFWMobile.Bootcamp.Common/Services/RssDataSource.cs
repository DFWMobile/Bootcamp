using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFWMobile.Bootcamp.Common.Services
{
    public class RssDataSource
        : IDataSource
    {
        public string ServiceUri { get; set; }
        public string ServiceName { get; set; }
    }
}
