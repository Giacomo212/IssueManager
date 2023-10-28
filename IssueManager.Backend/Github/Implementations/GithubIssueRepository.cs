using IssueManager.Abstractions.Common.Interfaces;
using IssueManager.Abstractions.Github.Mappings;
using IssueManager.Abstractions.Github.Models;
using IssueManager.Abstractions.Models;
using System.Net;
using System.Net.Http.Json;

namespace IssueManager.Abstractions.Github.Implementations;

public class GithubIssueRepository : IIssueRepository {
    private readonly IHttpClientFactory _httpClientFactory;

    public GithubIssueRepository(IHttpClientFactory httpClientFactory) {
        _httpClientFactory = httpClientFactory;
    }

    public async Task AddIssue(IRepoIDProvider repoModel, NewIssueModel model) {
        using var client = _httpClientFactory.CreateClient(CommonNames.GithubName);
        var uri = new Uri(client.BaseAddress, $"/repos/{repoModel.GetRepoId}/issues");
        var mappedIssue = IssueMappings.MapGithub(model);
        var httpRequestTask = client.PostAsJsonAsync<NewGithubIssueModel>(uri, mappedIssue);
        var res = await httpRequestTask;
        if (res.StatusCode != HttpStatusCode.Created)
            throw new Exception($"Error, code {res.StatusCode}");
    }

    public async Task CloseIssue(IRepoIDProvider repoModel, int id) {
        using var client = _httpClientFactory.CreateClient(CommonNames.GithubName);
        var uri = new Uri(client.BaseAddress, $"/repos/{repoModel.GetRepoId}/issues/{id}");
        var closedModel = new CloseGithubModel() {
            state = "close"
        };
        var httpRequestTask = client.PatchAsJsonAsync<CloseGithubModel>(uri, closedModel);
        var res = await httpRequestTask;
        if (res.StatusCode != HttpStatusCode.OK)
            throw new Exception($"Error, code {res.StatusCode}");
    }

    public async Task<IEnumerable<NewIssueModel>> GetIssueList(IRepoIDProvider repoModel) {
        using var client = _httpClientFactory.CreateClient(CommonNames.GithubName);
        var uri = new Uri(client.BaseAddress, $"/repos/{repoModel.GetRepoId}/issues");
        var httpRequestTask = client.GetAsync(uri);
        var responseMessage = await httpRequestTask;
        var jsonAsync = await responseMessage.Content.ReadFromJsonAsync<NewIssueModel[]>();
        return jsonAsync;
    }

    public async Task UpdateIssue(IRepoIDProvider repoModel, IssueModel model) {
        using var client = _httpClientFactory.CreateClient(CommonNames.GithubName);
        var uri = new Uri(client.BaseAddress, $"/repos/{repoModel.GetRepoId}/issues/{model.number}");
        var mappedIssue = IssueMappings.MapGithub(model);
        var httpRequestTask = client.PatchAsJsonAsync(uri, mappedIssue);
        var res = await httpRequestTask;
        if (res.StatusCode != HttpStatusCode.OK)
            throw new Exception($"response {res.StatusCode}");
    }
}