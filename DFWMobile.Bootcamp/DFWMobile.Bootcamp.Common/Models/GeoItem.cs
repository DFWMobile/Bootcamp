using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DFWMobile.Bootcamp.Common.Models
{
    public class GeoItem
        : Item
    {
        [DataMember(Name = "lat")]
        public double Latitude { get; set; }

        [DataMember(Name = "long")]
        public double Longitude { get; set; }
    }
}
