using System;
using System.Collections.Generic;
using System.Linq;

namespace Inchcape.Akeneo.Connector.Models
{
    public class ValuesDictionary : Dictionary<string, ValueItem[]>
    {
        public object GetPropertyNameValue(string property, Type type, object fallbackValue = null, string locale = "en_AU")
        {
            try
            {
                if (!ContainsKey(property)) return fallbackValue;

                var value = 
                    this[property]?.FirstOrDefault(x => x.Locale == locale) ?? 
                    this[property]?.FirstOrDefault();
                
                return value?.Data.ToObject(type);
            }
            catch
            {
                return fallbackValue;
            }
        }
        
        public string GetDownloadLink(string property, string locale = "en_AU")
        {
            if (!ContainsKey(property)) return string.Empty;

            var value = 
                this[property]?.FirstOrDefault(x => x.Locale == locale) ?? 
                this[property]?.FirstOrDefault();
            
            return value?.Links["download"]?["href"]?.ToString();
        }
    }
}
