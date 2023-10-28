namespace IssueManager.Abstractions.Common.Interfaces;

public interface IRepoFactory {
    public IIssueRepository CreateRepo(string name);
}