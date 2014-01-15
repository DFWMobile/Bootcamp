using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DFWMobile.Bootcamp.Common.Models;

namespace DFWMobile.Bootcamp.Common.SampleData
{
    public class SelectedItemSampleData
    {
        public SelectedItemSampleData()
        {
            
        }
        public Group<Item> SelectedGroup { get; set; }
        public Item SelectedItem { get; set; }
    }
}
