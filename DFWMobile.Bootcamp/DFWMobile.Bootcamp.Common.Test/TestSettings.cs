using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Refractored.MvxPlugins.Settings;

namespace DFWMobile.Bootcamp.Common.Test
{
    public class TestSettings
        : Dictionary<string, object>, ISettings
    {
        public T GetValueOrDefault<T>(string key, T defaultValue = default(T))
        {
            if (ContainsKey(key))
            {
                return (T) this[key];
            }
            return defaultValue;
        }

        public bool AddOrUpdateValue(string key, object value)
        {
            this[key] = value;

            return true;
        }

        public void Save() { }
    }
}
