using System.Text.Json;

namespace Lodash.Stats
{
    public class GitHubWrapper
    {
        static GitHubWrapper()
        {
            Http = new HttpClient();

            // GitHub gives 403 Forbidden unless this header is set in a way it is set in the client browser
            Http.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/126.0.0.0 Safari/537.36");
        }

        private static HttpClient Http;

        private const string ListFilesUrl = "http://api.github.com/repos/{0}/{1}/git/trees/main?recursive=42";

        private const string DescribeFileUrl = "http://api.github.com/repos/{0}/{1}/contents/{2}";

        public async Task<List<string>> ListFiles(string owner, string repo)
        {
            var url = string.Format(ListFilesUrl, owner, repo);

            var response = await Http.GetStringAsync(url);

            var model = JsonSerializer.Deserialize<GitHubTreeList>(response.ToString());

            if (model == null || model.Tree == null || model.Tree.Count == 0)
            {
                return new List<string>();
            }

            return model.Tree.Select(x => x.Path).ToList();
        }

        public async Task<string> GetFileContent(string owner, string repo, string path)
        {
            var descibeFileUrl = string.Format(DescribeFileUrl, owner, repo, path);

            var describeResponse = await Http.GetStringAsync(descibeFileUrl);

            var fileDescription = JsonSerializer.Deserialize<GitHubFile>(describeResponse.ToString());

            if (fileDescription == null || string.IsNullOrWhiteSpace(fileDescription.DownloadUrl))
            {
                throw new FileNotFoundException($"Unable to download file, owner = {owner}, repo = {repo}, path = {path}");
            }

            var fileContent = await Http.GetStringAsync(fileDescription.DownloadUrl);

            return fileContent;
        }
    }
}
