using IssueManager.Abstractions.Models;

namespace IssueManager.Abstractions.Interfaces;

public interface IIssueRepository {

    public Task AddIssue(IRepoIDProvider repoModel, NewIssueModel model);
    public Task CloseIssue(IRepoIDProvider repoModel, int id);

    public Task<IEnumerable<NewIssueModel>> GetIssueList(IRepoIDProvider repoModel);

    public Task UpdateIssue(IRepoIDProvider repoModel, IssueModel model);

}