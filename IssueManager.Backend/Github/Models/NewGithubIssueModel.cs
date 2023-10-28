using System.Text.Json.Serialization;

namespace IssueManager.Abstractions.Github.Models;

public record NewGithubIssueModel(
    [property: JsonPropertyName("title")] string Title,
    [property: JsonPropertyName("body")] string Body
);