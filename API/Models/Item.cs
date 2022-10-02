using Newtonsoft.Json;
using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Models
{
    public class Item
    {
        [JsonProperty(PropertyName = "firstName")]
        public string FirstName { get; set; }

        [JsonProperty(PropertyName = "lastName")]
        public string LastName { get; set; }

        [JsonProperty(PropertyName = "paymentMethod")]
        public string PaymentMethod { get; set; }

        [JsonProperty(PropertyName = "cc-name")]
        public string CC_Name { get; set; }

        [JsonProperty(PropertyName = "cc-number")]
        public string CC_Number { get; set; }

        [JsonProperty(PropertyName = "cc-expiration")]
        public string CC_Expiration { get; set; }

        [JsonProperty(PropertyName = "cc-cvv")]
        public string CC_CVV { get; set; }
    }
}
