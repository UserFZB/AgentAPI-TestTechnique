using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AgentAPI
{
    public class Agent
    {
        public string Os { get; set; }
        public DateTime LastKeepAlive { get; set; }
        public DateTime DateAdd { get; set; }
        [RegularExpression(@"^(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\.(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\.(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\.(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$", ErrorMessage = "IP not valid.")]
        public string Ip { get; set; }
        public string Name { get; set; }
        public int Id { get; set; }
        public string Version { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Status Status { get; set; }

    }
}
