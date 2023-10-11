using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewSpecificationLib.ReturnClasses
{
    public class Specification
    {
        [JsonProperty("id")]
        public long Id { get; set; }
        [JsonProperty("disanId")]
        public long DisanId { get; set; } = default(long);
        [JsonProperty("customId")]
        public long CustomId { get; set; } = default(long);
        [JsonProperty("products")]
        public List<Product> Products { get; set; } = new List<Product>();
        [JsonProperty("verified")]
        public bool IsVerified { get; set; } = false;
    }
}
