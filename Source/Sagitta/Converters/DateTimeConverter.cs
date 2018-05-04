using System;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Sagitta.Converters
{
    internal class DateTimeConverter : DateTimeConverterBase
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var value = reader.Value as string;
            if (string.IsNullOrWhiteSpace(value))
                return null;
            return DateTime.Parse(value);
        }
    }
}