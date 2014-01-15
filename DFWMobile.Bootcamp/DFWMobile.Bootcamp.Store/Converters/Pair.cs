using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFWMobile.Bootcamp.Store.Converters
{
    public class Pair<T>
    {
        public Pair()
        {
            HasSecond = true;
        }
        public T First { get; set; }
        public T Second { get; set; }

        public bool HasSecond { get; set; }
    }
}
