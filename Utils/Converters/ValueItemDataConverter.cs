using System;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Inchcape.Akeneo.Connector.Utils.Converters
{
    public class ValueItemDataConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(object);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var token = JToken.Load(reader);

            if (reader.TokenType == JsonToken.EndArray)
            {
                return (token.First?.Type) switch
                {
                    JTokenType.String => token.Values<string>(),
                    JTokenType.Object => token.Values<object>(),
                    _ => Array.Empty<object>(),
                };
            }

            return token.Value<object>();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            // Implementation not needed.
            // We only have to read the response data from Akeneo API

            throw new NotImplementedException();
        }
    }
}
