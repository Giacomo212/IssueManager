using IssueManager.Abstractions.Github.Implementations;
using IssueManager.Abstractions.Gitlab.Implementations;
using IssueManager.Abstractions.Interfaces;

namespace IssueManager.Abstractions.Implementations;

public class RepoFactory : IRepoFactory{
    public IIssueRepository CreateRepo(string name){
        var httpfactory = new HttpClientFactory();
        if (name.ToLower().Trim() == CommonNames.GitlabName.ToLower().Trim())
            return new GitlabIssueRepository(httpfactory);
        if (name.ToLower().Trim() == CommonNames.GithubName.ToLower().Trim())
            return new GithubIssueRepository(httpfactory);
        throw new Exception("unsupported github client type");
    }
}