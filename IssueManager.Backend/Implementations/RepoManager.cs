using System.Text.Json;
using IssueManager.Abstractions.Interfaces;
using IssueManager.Abstractions.Models;

namespace IssueManager.Abstractions.Implementations;

public class RepoManager : IRepoManager{
    
    private IIssueRepository _issueRepository{ get; }
    
    public RepoManager(IIssueRepository issueRepository){
        _issueRepository = issueRepository;
    }

    
    public Task AddIssue(IRepoIDProvider repoModel, NewIssueModel model){
        return _issueRepository.AddIssue(repoModel, model);
    }


    public Task UpdateIssue(IRepoIDProvider repoModel, IssueModel model){
        return _issueRepository.UpdateIssue(repoModel, model);
    }

    public Task CloseIssue(IRepoIDProvider repoModel, int number, bool isOpen){
        return _issueRepository.CloseIssue(repoModel,number);
    }

    public async Task ExportIssue(IRepoIDProvider repoModel, string path){
        var issueList = await _issueRepository.GetIssueList(repoModel);
        var serializedString = JsonSerializer.Serialize(issueList);
        await File.WriteAllTextAsync(path,serializedString) ;
    }

    public async Task ImportIssue(IRepoIDProvider repoModel, string path){
        var issuesString = await File.ReadAllTextAsync(path);
        var issuesDeserialized = JsonSerializer.Deserialize<IssueModel[]>(issuesString);
        foreach (var issue  in issuesDeserialized){
            await _issueRepository.AddIssue(repoModel, issue);
        }
        
    }
}