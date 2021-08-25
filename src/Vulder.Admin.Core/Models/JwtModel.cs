using Newtonsoft.Json;

namespace Vulder.Admin.Core.Models
{
    public class JwtModel
    {
        [JsonProperty("jti")]
        public string Id { get; set; }
        
        [JsonProperty("address")]
        public string Email { get; set; }
        
        [JsonProperty("exp")]
        public long Expire { get; set; }
    }
}