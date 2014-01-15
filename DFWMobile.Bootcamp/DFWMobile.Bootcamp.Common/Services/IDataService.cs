using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DFWMobile.Bootcamp.Common.DataSources;
using DFWMobile.Bootcamp.Common.Models;

namespace DFWMobile.Bootcamp.Common.Services
{
    public interface IDataService
    {
        IDataSource Source { get; }
        Task<List<Item>> GetItems();
    }
}
