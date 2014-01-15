using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DFWMobile.Bootcamp.Common.Models;

namespace DFWMobile.Bootcamp.Common.Services
{
    public abstract class ItemDataService
    {
        protected List<Item> ParseItems(string xml, string groupName)
        {
            var feed = XDocument.Parse(xml);

            var items = from item in feed.Descendants("item")
                        select new Item()
                        {
                            Title = item.Element("title") != null ? item.Element("title").Value : string.Empty,
                            Subtitle = item.Element("subtitle") != null ? item.Element("subtitle").Value : string.Empty,
                            Description = item.Element("description") != null ? item.Element("description").Value : string.Empty,
                            Image = item.Element("image") != null ? item.Element("image").Value : string.Empty,
                            Group = (groupName ?? (item.Element("group") != null ? item.Element("group").Value : string.Empty)),
                        };

            return items.ToList();
        }
    }
}
