namespace IssueManager.Abstractions.Interfaces;

public interface IRepoFactory {
    public IIssueRepository CreateRepo(string name);
}