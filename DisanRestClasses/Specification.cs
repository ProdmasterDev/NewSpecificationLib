using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace NewSpecificationLib.DisanRestClasses
{

    // Specification myDeserializedClass = JsonConvert.DeserializeObject<List<Specification>>(myJsonResponse);
    [ClassInterface(ClassInterfaceType.None)]
    [Guid("5A5100CD-B097-420F-B702-AD4E99BD54D2")]
    [ProgId("NewSpecificationLib.DisanRestClasses.Specification")]
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

        [JsonProperty("inn")]
        public string Inn { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("products")]
        public ArrayList Products { get; set; }

        [JsonProperty("createdAt")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("lastModified")]
        public DateTime LastModified { get; set; }
    }
}
