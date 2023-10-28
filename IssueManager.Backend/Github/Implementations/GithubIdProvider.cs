using IssueManager.Abstractions.Interfaces;

namespace IssueManager.Abstractions.Github.Implementations;

public class GithubIdProvider : IRepoIDProvider {
    public GithubIdProvider(string userName, string repoName) {
        UserName = userName;
        RepoName = repoName;
    }
    public GithubIdProvider(string id) {
        var stringSplited = id.Split("/");
        UserName = stringSplited.First();
        RepoName = stringSplited.ElementAt(1);
    }
    public string UserName { get; set; }

    public string RepoName { get; set; }
    public string GetRepoId => $"{UserName}/{RepoName}";
}