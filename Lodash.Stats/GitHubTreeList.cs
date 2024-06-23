using System.Text.Json.Serialization;

namespace Lodash.Stats
{
    public class GitHubTreeList
    {
        [JsonPropertyName("tree")]
        public List<GitHubTreeItem> Tree { get; set; }
    }
}
