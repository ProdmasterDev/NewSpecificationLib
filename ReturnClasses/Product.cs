using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewSpecificationLib.ReturnClasses
{
    public class Product
    {
        [JsonProperty("id")]
        public long Id { get; set; }
        [JsonProperty("disanId")]
        public long DisanId { get; set; } = default(long);
        [JsonProperty("verified")]
        public bool IsVerified { get; set; } = false;
    }
}
