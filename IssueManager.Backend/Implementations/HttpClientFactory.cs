using System.Net.Http.Headers;

namespace IssueManager.Abstractions.Implementations;

public class HttpClientFactory : IHttpClientFactory{
    public HttpClient CreateClient(string name){
        if (name == CommonNames.GithubName)
            return CreateGithubClient();
        if (name == CommonNames.GitlabName)
            return CreateGitlabClient();
        throw new Exception("unsupported http client type");
    }

    private HttpClient CreateGitlabClient(){
        var http = new HttpClient();
        http.DefaultRequestHeaders.Add("PRIVATE-TOKEN",Secrets.GitlabKey);
        http.BaseAddress = new Uri("https://gitlab.com");
        return http;
    }

    private HttpClient CreateGithubClient(){
        var http = new HttpClient();
        http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Secrets.GithubKey);
        http.BaseAddress = new Uri("https://api.github.com");
        http.DefaultRequestHeaders.Add("X-GitHub-Api-Version","2022-11-28");
        http.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("IssueManager", "1.0"));
        return http;
    }
}