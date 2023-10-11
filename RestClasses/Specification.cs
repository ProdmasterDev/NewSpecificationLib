using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace NewSpecificationLib.RestClasses
{
    // Specification myDeserializedClass = JsonConvert.DeserializeObject<List<Specification>>(myJsonResponse);
    public class Specification
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("startsAt")]
        public DateTime StartsAt { get; set; }

        [JsonProperty("expiresAt")]
        public DateTime ExpiresAt { get; set; }

        [JsonProperty("userId")]
        public int UserId { get; set; }

        [JsonProperty("providersName")]
        public string ProvidersName { get; set; }
        [JsonProperty("customId")]
        public int CustomId { get; set; }

        [JsonProperty("inn")]
        public string Inn { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("products")]
        public List<Product> Products { get; set; }

        [JsonProperty("createdAt")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("lastModified")]
        public DateTime LastModified { get; set; }
    }
}
