namespace PremiumCalc.Model
{

    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class QuoteResponse
    {
        [JsonProperty("QuoteNo")]
        public string QuoteNo { get; set; }

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

        [JsonProperty("Premium")]
        public double Premium { get; set; }

        [JsonProperty("Taxes")]
        public double Taxes { get; set; }

        [JsonProperty("ReferenceID")]
       
        public string ReferenceId { get; set; }

        [JsonProperty("TheftCover")]
        public bool TheftCover { get; set; }

        [JsonProperty("ElectronicCover")]
        public bool ElectronicCover { get; set; }

        [JsonProperty("breakdownCover")]
        public bool BreakdownCover { get; set; }
    }

    public partial class QuoteResponse
    {
        public static QuoteResponse FromJson(string json) => JsonConvert.DeserializeObject<QuoteResponse>(json, Converter.Settings);
    }
}
