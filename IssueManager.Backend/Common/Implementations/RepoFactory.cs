using IssueManager.Abstractions.Common.Interfaces;
using IssueManager.Abstractions.Github.Implementations;
using IssueManager.Abstractions.Gitlab.Implementations;

namespace IssueManager.Abstractions.Common.Implementations;

public class RepoFactory : IRepoFactory {
    private readonly ICredentialsProvider _credentialsProvider;

    public RepoFactory(ICredentialsProvider credentialsProvider) {
        _credentialsProvider = credentialsProvider;
    }

    public IIssueRepository CreateRepo(string name) {
        var httpFactory = new HttpClientFactory(_credentialsProvider);
        if (name.ToLower().Trim() == CommonNames.GitlabName.ToLower().Trim())
            return new GitlabIssueRepository(httpFactory);
        if (name.ToLower().Trim() == CommonNames.GithubName.ToLower().Trim())
            return new GithubIssueRepository(httpFactory);
        throw new Exception("unsupported github client type");
    }
}