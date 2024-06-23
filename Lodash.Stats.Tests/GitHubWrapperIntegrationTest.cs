using FluentAssertions;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Lodash.Stats.Tests
{
    // TODO: more tests, though not sure how stable lodash/lodash code base is
    public class GitHubWrapperIntegrationTest
    {
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public async Task TestListFiles_ShouldReturnResult()
        {
            var wrapper = new GitHubWrapper();

            var result = await wrapper.ListFiles("lodash", "lodash");

            result.Should().NotBeEmpty();
        }

        [Test]
        public async Task TestGetFile_ShouldReturnResult()
        {
            var wrapper = new GitHubWrapper();

            var result = await wrapper.GetFileContent("lodash", "lodash", "src/.internal/initCloneObject.ts");

            result.Should().NotBeEmpty();
        }
    }
}