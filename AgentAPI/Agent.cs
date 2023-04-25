using System.Text.Json.Serialization;

namespace AgentAPI
{
    public class Agent
    {
        public string Os { get; set; }
        public DateTime LastKeepAlive { get; set; }
        public DateTime DateAdd { get; set; }
        public string Ip { get; set; }
        public string Name { get; set; }
        public int Id { get; set; }
        public string Version { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Status Status { get; set; }

    }
}
