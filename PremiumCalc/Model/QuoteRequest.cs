namespace PremiumCalc.Model
{
   
        using System;
        using System.Collections.Generic;

        using System.Globalization;
        using Newtonsoft.Json;
        using Newtonsoft.Json.Converters;

        public partial class QuoteRequest
        {
            [JsonProperty("Product")]
            public string Product { get; set; }

            [JsonProperty("CustomerName")]
            public string CustomerName { get; set; }

            [JsonProperty("Mobile")]
            public string Mobile { get; set; }

            [JsonProperty("Email")]
            public string Email { get; set; }

            [JsonProperty("IDV")]
            public double Idv { get; set; }

            [JsonProperty("TheftCover")]
            public bool TheftCover { get; set; }

            [JsonProperty("ElectronicCover")]
            public bool ElectronicCover { get; set; }

            [JsonProperty("breakdownCover")]
            public bool BreakdownCover { get; set; }

            [JsonProperty("ReferenceID")]
            public string ReferenceId { get; set; }
        }

        public partial class QuoteRequest
        {
            public static QuoteRequest FromJson(string json) => JsonConvert.DeserializeObject<QuoteRequest>(json, Converter.Settings);
        }

        public static class Serialize
        {
            public static string ToJson<T>(this T self) => JsonConvert.SerializeObject(self, Converter.Settings);
        }

        internal static class Converter
        {
            public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
            {
                MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
                DateParseHandling = DateParseHandling.None,
                Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
            };
        }

        internal class ParseStringConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(long) || t == typeof(long?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null) return null;
                var value = serializer.Deserialize<string>(reader);
                long l;
                if (Int64.TryParse(value, out l))
                {
                    return l;
                }
                throw new Exception("Cannot unmarshal type long");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                if (untypedValue == null)
                {
                    serializer.Serialize(writer, null);
                    return;
                }
                var value = (long)untypedValue;
                serializer.Serialize(writer, value.ToString());
                return;
            }

            public static readonly ParseStringConverter Singleton = new ParseStringConverter();
        }
    }

