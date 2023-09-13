using Newtonsoft.Json;
using System;

namespace NewSpecificationLib.RestClasses
{
    public class Product
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("disanId")]
        public int? DisanId { get; set; }

        [JsonProperty("price")]
        public double Price { get; set; }

        [JsonProperty("quantity")]
        public double Quantity { get; set; }

        [JsonProperty("standartId")]
        public int StandartId { get; set; }

        [JsonProperty("manufacturerId")]
        public int? ManufacturerId { get; set; }

        [JsonProperty("manufacturerName")]
        public string ManufacturerName { get; set; }

        [JsonProperty("vendorCode")]
        public int VendorCode { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("countryId")]
        public int? CountryId { get; set; }

        [JsonProperty("brand")]
        public string Brand { get; set; }

        [JsonProperty("note")]
        public string Note { get; set; }

        [JsonProperty("createdAt")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("lastModified")]
        public DateTime LastModified { get; set; }
    }
}
