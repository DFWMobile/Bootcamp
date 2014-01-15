using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DFWMobile.Bootcamp.Common.Models;

namespace DFWMobile.Bootcamp.Common.SampleData
{
    public class GroupedItemsSampleData
    {
        public GroupedItemsSampleData()
        {
            ItemGroups = new List<Group<Item>>()
            {
                new Group<Item>
                    ("Dogs",
                        new List<Item>()
                        {
                            new Item()
                            {
                                Title = "Something Cool",
                                Subtitle = "Something Short",
                                Description = "Something Descriptive",
                                Image= "http://i.imgur.com/bmpyrJZ.jpg",
                                Group = "Dogs"
                            },
                            new Item()
                            {
                                Title = "Something Cool",
                                Subtitle = "Something Short",
                                Description = "Something Descriptive",
                                Image= "http://i.imgur.com/bmpyrJZ.jpg",
                                Group = "Dogs"
                            },
                            new Item()
                            {
                                Title = "Something Cool",
                                Subtitle = "Something Short",
                                Description = "Something Descriptive",
                                Image= "http://i.imgur.com/bmpyrJZ.jpg",
                                Group = "Dogs"
                            },
                            new Item()
                            {
                                Title = "Something Cool",
                                Subtitle = "Something Short",
                                Description = "Something Descriptive",
                                Image= "http://i.imgur.com/bmpyrJZ.jpg",
                                Group = "Dogs"
                            },
                            new Item()
                            {
                                Title = "Something Cool",
                                Subtitle = "Something Short",
                                Description = "Something Descriptive",
                                Image= "http://i.imgur.com/bmpyrJZ.jpg",
                                Group = "Dogs"
                            },
                        }
                     ),
                
                new Group<Item>
                    ("Cats",
                        new List<Item>()
                        {
                            new Item()
                            {
                                Title = "Something Cool",
                                Subtitle = "Something Short",
                                Description = "Something Descriptive",
                                Image = "http://imgur.com/gallery/c3DGrH3",
                                Group = "Cats"
                            },
                            new Item()
                            {
                                Title = "Something Cool",
                                Subtitle = "Something Short",
                                Description = "Something Descriptive",
                                Image = "http://imgur.com/gallery/c3DGrH3",
                                Group = "Cats"
                            },
                            new Item()
                            {
                                Title = "Something Cool",
                                Subtitle = "Something Short",
                                Description = "Something Descriptive",
                                Image = "http://imgur.com/gallery/c3DGrH3",
                                Group = "Cats"
                            },
                            new Item()
                            {
                                Title = "Something Cool",
                                Subtitle = "Something Short",
                                Description = "Something Descriptive",
                                Image = "http://imgur.com/gallery/c3DGrH3",
                                Group = "Cats"
                            },
                            new Item()
                            {
                                Title = "Something Cool",
                                Subtitle = "Something Short",
                                Description = "Something Descriptive",
                                Image = "http://imgur.com/gallery/c3DGrH3",
                                Group = "Cats"
                            },
                            new Item()
                            {
                                Title = "Something Cool",
                                Subtitle = "Something Short",
                                Description = "Something Descriptive",
                                Image = "http://imgur.com/gallery/c3DGrH3",
                                Group = "Cats"
                            },
                            new Item()
                            {
                                Title = "Something Cool",
                                Subtitle = "Something Short",
                                Description = "Something Descriptive",
                                Image = "http://imgur.com/gallery/c3DGrH3",
                                Group = "Cats"
                            },
                            new Item()
                            {
                                Title = "Something Cool",
                                Subtitle = "Something Short",
                                Description = "Something Descriptive",
                                Image = "http://imgur.com/gallery/c3DGrH3",
                                Group = "Cats"
                            },
                            new Item()
                            {
                                Title = "Something Cool",
                                Subtitle = "Something Short",
                                Description = "Something Descriptive",
                                Image = "http://imgur.com/gallery/c3DGrH3",
                                Group = "Cats"
                            },
                            new Item()
                            {
                                Title = "Something Cool",
                                Subtitle = "Something Short",
                                Description = "Something Descriptive",
                                Image = "http://imgur.com/gallery/c3DGrH3",
                                Group = "Cats"
                            },
                            new Item()
                            {
                                Title = "Something Cool",
                                Subtitle = "Something Short",
                                Description = "Something Descriptive",
                                Image = "http://imgur.com/gallery/c3DGrH3",
                                Group = "Cats"
                            },
                            new Item()
                            {
                                Title = "Something Cool",
                                Subtitle = "Something Short",
                                Description = "Something Descriptive",
                                Image = "http://imgur.com/gallery/c3DGrH3",
                                Group = "Cats"
                            },
                            new Item()
                            {
                                Title = "Something Cool",
                                Subtitle = "Something Short",
                                Description = "Something Descriptive",
                                Image = "http://imgur.com/gallery/c3DGrH3",
                                Group = "Cats"
                            },
                            new Item()
                            {
                                Title = "Something Cool",
                                Subtitle = "Something Short",
                                Description = "Something Descriptive",
                                Image = "http://imgur.com/gallery/c3DGrH3",
                                Group = "Cats"
                            },
                        }
                     )
            };
        }
        public List<Group<Item>> ItemGroups { get; set; }
    }
}
