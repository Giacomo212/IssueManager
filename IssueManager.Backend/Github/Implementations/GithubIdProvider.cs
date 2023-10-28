using IssueManager.Abstractions.Common.Interfaces;

namespace IssueManager.Abstractions.Github.Implementations;

public class GithubIdProvider : IRepoIDProvider {
    public GithubIdProvider(string userName, string repoName) {
        UserName = userName;
        RepoName = repoName;
    }
    public GithubIdProvider(string id) {
        var stringSplitted = id.Split("/");
        UserName = stringSplitted.First();
        RepoName = stringSplitted.ElementAt(1);
    }
    public string UserName { get; set; }

    public string RepoName { get; set; }
    public string GetRepoId => $"{UserName}/{RepoName}";
}