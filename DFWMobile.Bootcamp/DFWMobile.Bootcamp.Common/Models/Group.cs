using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFWMobile.Bootcamp.Common.Models
{
    public class Group<T> : ObservableCollection<T>
    {
        public Group(string name, IEnumerable<T> items)
            : base(items)
        {
            this.Key = name;
        }

        public Group()
        {
        }

        public string Key { get; set; }
    }
}
