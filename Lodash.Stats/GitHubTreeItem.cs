using System.Text.Json.Serialization;

namespace Lodash.Stats
{
    public class GitHubTreeItem
    {
        [JsonPropertyName("path")]
        public string Path { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }
    }
}
