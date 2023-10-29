using IssueManager.Abstractions.Common.Interfaces;

namespace IssueManager.Abstractions.Github.Implementations;

public class GitlabIdProvider : IRepoIDProvider{
    public GitlabIdProvider(string getRepoId) {
        GetRepoId = getRepoId;
    }

    public string GetRepoId { get; }
}
