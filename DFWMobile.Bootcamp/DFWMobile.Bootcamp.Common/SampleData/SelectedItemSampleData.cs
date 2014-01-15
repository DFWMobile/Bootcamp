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
            var items = new List<Item>()
            {
                new Item()
                {
                    Title = "Something Cool",
                    Subtitle = "Something Short",
                    Description = "Something Descriptive",
                    Image = "http://i.imgur.com/bmpyrJZ.jpg",
                    Group = "Dogs"
                },
                new Item()
                {
                    Title = "Something Cool",
                    Subtitle = "Something Short",
                    Description = "Something Descriptive",
                    Image = "http://i.imgur.com/bmpyrJZ.jpg",
                    Group = "Dogs"
                },
                new Item()
                {
                    Title = "Something Cool",
                    Subtitle = "Something Short",
                    Description = "Something Descriptive",
                    Image = "http://i.imgur.com/bmpyrJZ.jpg",
                    Group = "Dogs"
                },
                new Item()
                {
                    Title = "Something Cool",
                    Subtitle = "Something Short",
                    Description = "Something Descriptive",
                    Image = "http://i.imgur.com/bmpyrJZ.jpg",
                    Group = "Dogs"
                },
                new Item()
                {
                    Title = "Something Cool",
                    Subtitle = "Something Short",
                    Description = "Something Descriptive",
                    Image = "http://i.imgur.com/bmpyrJZ.jpg",
                    Group = "Dogs"
                },
            };
            SelectedGroup = new List<Group<Item>>
            {
                new Group<Item>("Dogs", items)
            };

            SelectedItem = items[0];
        }
        public List<Group<Item>> SelectedGroup { get; set; }
        public Item SelectedItem { get; set; }
    }
}
