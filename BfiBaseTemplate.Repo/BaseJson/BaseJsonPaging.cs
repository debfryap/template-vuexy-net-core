
using Newtonsoft.Json;

namespace BfiBaseTemplate.Repo.Models.BaseJson
{
    
    public class BaseJsonPaging<T>
    {
        public T Data { get; set; }

        [JsonProperty("total_record")]
        public int TotalRecord { get; set; }
    }
}
