using IssueManager.Abstractions.Interfaces;
using IssueManager.Abstractions.Models;

namespace IssueManager.Abstractions.Implementations;

public interface IRepoManager{
    public Task AddIssue(IRepoIDProvider repoModel, NewIssueModel model);

    public Task UpdateIssue(IRepoIDProvider repoModel, IssueModel model);

    public Task CloseIssue(IRepoIDProvider repoModel, int number, bool isOpen);

    public Task ExportIssue(IRepoIDProvider repoModel, string path);

    public Task ImportIssue(IRepoIDProvider repoModel, string path);
}