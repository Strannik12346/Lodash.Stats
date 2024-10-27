using System.Text.Json.Serialization;

namespace Lodash.Stats
{
    public class GitHubFile
    {
        [JsonPropertyName("download_url")]
        public string DownloadUrl { get; set; }

        [JsonPropertyName("content")]
        public string Content { get; set; }
    }
}
