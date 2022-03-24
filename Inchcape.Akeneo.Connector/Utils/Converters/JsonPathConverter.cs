using System;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Inchcape.Akeneo.Connector.Utils.Converters
{
    public class JsonPathConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return false;
        }

        public override void WriteJson(JsonWriter writer, object value, Newtonsoft.Json.JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, Newtonsoft.Json.JsonSerializer serializer)
        {
            var jo = JObject.Load(reader);
            var targetObj = Activator.CreateInstance(objectType);

            foreach (var prop in objectType.GetProperties().Where(p => p.CanRead && p.CanWrite))
            {
                var att = prop.GetCustomAttributes(true).OfType<JsonPropertyAttribute>().FirstOrDefault();

                var jsonPath = (att != null ? att.PropertyName : prop.Name);

                var token = jo.SelectToken(jsonPath);

                if (token != null && token.Type != JTokenType.Null)
                {
                    object value = token.ToObject(prop.PropertyType, serializer);

                    prop.SetValue(targetObj, value, null);
                }
            }

            return targetObj;
        }
    }
}
