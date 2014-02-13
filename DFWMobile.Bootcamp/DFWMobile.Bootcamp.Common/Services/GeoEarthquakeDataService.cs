using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using Cirrious.CrossCore.Platform;
using DFWMobile.Bootcamp.Common.DataSources;
using DFWMobile.Bootcamp.Common.Models;
using DFWMobile.Bootcamp.Common.Settings;

namespace DFWMobile.Bootcamp.Common.Services
{
    public class GeoEarthquakeDataService
        : IDataService
    {
        private const string _userAgent = "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; WOW64; Trident/6.0)";
        private HttpClient _httpClient;
        private IDataSource _dataSource;
        private IAppSettings _appSettings;
        private IMvxJsonConverter _jsonConverter;
        public GeoEarthquakeDataService(IDataSource source, IAppSettings appSettings, IMvxJsonConverter jsonConverter)
        {
            _httpClient = new HttpClient();
            _dataSource = source;
            _appSettings = appSettings;
            _jsonConverter = jsonConverter;
        }

        public IDataSource Source
        {
            get { return _dataSource; }
        }
        public async Task<List<Item>> GetItems()
        {
            var items = new List<Item>();
            var jsonContent = await _httpClient.GetStringAsync(Source.ServiceUri);

            var earthquakes = _jsonConverter.DeserializeObject<Earthquakes>(jsonContent);

            foreach(var earthquake in earthquakes.Features)
            {
                items.Add(new GeoItem
                {
                    Title = earthquake.Properties.Title != null ? earthquake.Properties.Title.Remove(0, 2) : earthquake.Properties.Title,
                    Subtitle = earthquake.Properties.Place,
                    Description = earthquake.Properties.Place,
                    Group = Source.ServiceName,
                    Id = earthquake.Id,
                    Latitude = earthquake.Geometry.Coordinates[1],
                    Longitude = earthquake.Geometry.Coordinates[0],
                    Image = "/Assets/USGS.jpg"
                });
            }

            return items;
        }

        public Task<bool> Add(Item item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(Item item)
        {
            throw new NotImplementedException();
        }

        public bool IsEditable
        {
            get { return false; }
        }
    }

    public class Earthquakes
    {
        [DataMember(Name = "bbox")]
        public List<string> BBox { get; set; }


        [DataMember(Name = "metadata")]
        public Metadata Metadata { get; set; }

        [DataMember(Name = "features")]
        public List<Feature> Features { get; set; } 
    }

    public class Metadata
    {
        [DataMember(Name = "title")]
        public string Title { get; set; }
    }

    public class Feature
        : EarthquakeBase
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "geometry")]
        public Geometry Geometry { get; set; }

        [DataMember(Name = "properties")]
        public Properties Properties { get; set; }
    }

    public class Properties
        : EarthquakeBase
    {
        [DataMember(Name = "place")]
        public string Place { get; set; }

        [DataMember(Name = "title")]
        public string Title { get; set; }
    }

    public class Geometry
        : EarthquakeBase
    {
        [DataMember(Name = "coordinates")]
        public List<double> Coordinates { get; set; }
    }

    public class EarthquakeBase
    {
        [DataMember(Name = "type")]
        public string Type { get; set; }
    }
}
