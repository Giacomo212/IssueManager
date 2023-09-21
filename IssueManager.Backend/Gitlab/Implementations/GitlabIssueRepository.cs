using System.Net;
using System.Net.Http.Json;
using IssueManager.Abstractions.Gitlab.Mappings;
using IssueManager.Abstractions.Gitlab.Models;
using IssueManager.Abstractions.Interfaces;
using IssueManager.Abstractions.Models;

namespace IssueManager.Abstractions.Gitlab.Implementations;

public class GitlabIssueRepository : IIssueRepository{
    public GitlabIssueRepository(IHttpClientFactory clientFactory){
        _httpClientFactory = clientFactory;
    }

    private IHttpClientFactory _httpClientFactory{ get; }
    
    public async Task AddIssue(IRepoIDProvider repoModel, NewIssueModel model){
        using var client = _httpClientFactory.CreateClient(CommonNames.GitlabName);
        var uri = new Uri(client.BaseAddress, $"/api/v4/projects/{repoModel.GetRepoId}/issues");
        var mappedissue = IssueMappings.MapGitlab(model);
        var httpRequestTask = client.PostAsJsonAsync(uri, mappedissue);
        var responseMessage = await httpRequestTask;
        if (responseMessage.StatusCode != HttpStatusCode.Created)
            throw new Exception($"Error, code {responseMessage.StatusCode}");
    }

    public async Task CloseIssue(IRepoIDProvider repoModel, int id){
        using var client = _httpClientFactory.CreateClient(CommonNames.GitlabName);
        var uri = new Uri(client.BaseAddress, $"/api/v4/projects/{repoModel.GetRepoId}/issues/{id}");
        var model = new CloseGitlabIssueModel(){
            state_event = "close"
        };
        var httpRequestTask = client.PutAsJsonAsync(uri, model);
        var responseMessage = await httpRequestTask;
        if (responseMessage.StatusCode != HttpStatusCode.OK)
            throw new Exception($"Error, code {responseMessage.StatusCode}");
    }

    public async Task<IEnumerable<NewIssueModel>> GetIssueList(IRepoIDProvider repoModel){
        using var client = _httpClientFactory.CreateClient(CommonNames.GitlabName);
        var uri = new Uri(client.BaseAddress, $"/api/v4/projects/{repoModel.GetRepoId}/issues");
        var httpRequestTask = client.GetAsync(uri);
        var responseMessage = await httpRequestTask;
        var jsonAsync = await responseMessage.Content.ReadFromJsonAsync<IssueModel[]>();
        return jsonAsync;
    }

    public async Task UpdateIssue(IRepoIDProvider repoModel, IssueModel model){
        using var client = _httpClientFactory.CreateClient(CommonNames.GitlabName);
        var uri = new Uri(client.BaseAddress, $"/api/v4/projects/{repoModel.GetRepoId}/issues/{model.number}");
        var mappedissue = IssueMappings.MapGitlab(model);
        var httpRequestTask = client.PutAsJsonAsync(uri, mappedissue);
        var responseMessage = await httpRequestTask;
        if (responseMessage.StatusCode != HttpStatusCode.OK)
            throw new Exception($"Error, code {responseMessage.StatusCode}");
    }
}